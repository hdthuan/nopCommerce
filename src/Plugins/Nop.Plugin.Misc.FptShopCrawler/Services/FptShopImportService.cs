using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Data;
using Nop.Plugin.Misc.FptShopCrawler.Models;
using Nop.Services.Catalog;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Seo;

namespace Nop.Plugin.Misc.FptShopCrawler.Services
{
    public class FptShopImportService : IFptShopImportService
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IRepository<Core.Domain.Catalog.Category> _categoryRepository;
        private readonly IRepository<Core.Domain.Catalog.Manufacturer> _manufactureReposity;
        private readonly IManufacturerService _manufacturerService;
        private readonly IPictureService _pictureService;
        private readonly IRepository<Core.Domain.Media.Picture> _pictureRepository;
        private readonly IRepository<Core.Domain.Catalog.SpecificationAttributeGroup> _specificationAttributeGroupRepository;
        private readonly IRepository<Core.Domain.Catalog.SpecificationAttribute> _specificationAttributeRepository;
        private readonly IRepository<Core.Domain.Catalog.SpecificationAttributeOption> _specificationAttributeOptionRepository;
        private readonly IRepository<Core.Domain.Catalog.ProductSpecificationAttribute> _productSpecificationAttributeRepository;
        private readonly IUrlRecordService _urlRecordService;
        private readonly ILogger _logger;
        public FptShopImportService(
            IProductService productService,
            IRepository<Core.Domain.Catalog.Category> categoryRepository,
            ICategoryService categoryService,
            IRepository<Core.Domain.Catalog.Manufacturer> manufactureRepository,
            IManufacturerService manufacturerService,
            IPictureService pictureService,
            IRepository<Core.Domain.Media.Picture> pictureRepository,
            IRepository<Core.Domain.Catalog.SpecificationAttributeGroup> specificationAttributeGroupRepository,
            IRepository<Core.Domain.Catalog.SpecificationAttribute> specificationAttributeRepository,
            IRepository<Core.Domain.Catalog.SpecificationAttributeOption> specificationAttributeOptionRepository,
            IRepository<Core.Domain.Catalog.ProductSpecificationAttribute> productSpecificationAttributeRepository,
            IUrlRecordService urlRecordService,
            ILogger logger
            )
        {
            _productService = productService;
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
            _manufactureReposity = manufactureRepository;
            _manufacturerService = manufacturerService;
            _pictureService = pictureService;
            _pictureRepository = pictureRepository;
            _specificationAttributeGroupRepository = specificationAttributeGroupRepository;
            _specificationAttributeRepository = specificationAttributeRepository;
            _specificationAttributeOptionRepository = specificationAttributeOptionRepository;
            _productSpecificationAttributeRepository = productSpecificationAttributeRepository;
            _urlRecordService = urlRecordService;
            _logger = logger;
        }

        public async Task<Nop.Core.Domain.Catalog.Product> ImportAsync(string json, string imageFolder = "")
        {
            var root = JsonConvert.DeserializeObject<Root>(json);

            var productModel = root.Datas.Model.Product;
            var productEntity = new Core.Domain.Catalog.Product()
            {
                Name = productModel.Name,
                ShortDescription = productModel.Description,
                FullDescription = productModel.Details,
                Sku = productModel.Sku,
                AdminComment = productModel.NameAscii,
                OldPrice = productModel.ProductVariant.PriceMarket,
                Price = productModel.ProductVariant.Price,
                Published = true,
                ProductType = Core.Domain.Catalog.ProductType.SimpleProduct,
                AllowCustomerReviews = true,
                VisibleIndividually = true,
            };

            await _productService.InsertProductAsync(productEntity);

            //search engine name
            var seName = await _urlRecordService.ValidateSeNameAsync(productEntity, "", productEntity.Name, true);
            await _urlRecordService.SaveSlugAsync(productEntity, seName, 0);

            // mapping product categories
            var categoryEnity = await GetOrCreateCategoryAsync(productModel.ProductType);
            await _categoryService.InsertProductCategoryAsync(new Core.Domain.Catalog.ProductCategory()
            {
                CategoryId = categoryEnity.Id,
                ProductId = productEntity.Id,
            });

            // mapping product manufacture
            var manufactureEntity = await GetOrCreateManufactureAsync(productModel.Brand);
            await _manufacturerService.InsertProductManufacturerAsync(new Core.Domain.Catalog.ProductManufacturer()
            {
                ManufacturerId = manufactureEntity.Id,
                ProductId = productEntity.Id
            });
            // TODO: mapping product tags
            // mapping product pictures
            var listPictureModels = new List<Picture>();
            if (productModel.ListPictureSlide != null && productModel.ListPictureSlide.Count > 0)
            {
                listPictureModels.AddRange(productModel.ListPictureSlide);
            }
            if (productModel.ListPictureGallery != null && productModel.ListPictureGallery.Count > 0)
            {
                listPictureModels.AddRange(productModel.ListPictureGallery);
            }
            if (string.IsNullOrEmpty(imageFolder))
            {
                imageFolder = $"tmp/import/{productModel.NameAscii}";
            }
            var pictureEntities = await GetOrCreatePicturesAsync(imageFolder, listPictureModels);
            foreach (var pictureModel in listPictureModels)
            {
                var pictureEntity = pictureEntities.FirstOrDefault(r => r.SeoFilename == pictureModel.Name);
                if (pictureEntity != null)
                {
                    await _productService.InsertProductPictureAsync(new Core.Domain.Catalog.ProductPicture()
                    {
                        PictureId = pictureEntity.Id,
                        ProductId = productEntity.Id
                    });
                }
            }
            // mapping specificAttributes
            var specificationAttributeModels = productModel.ProductAttributes;
            foreach (var specificationAttributeModel in specificationAttributeModels)
            {
                var specificationAttributeOptionEntity = await GetOrCreateSpecificationAttributeOptionAsync(specificationAttributeModel);
                var specEntity = new Core.Domain.Catalog.ProductSpecificationAttribute()
                {
                    AllowFiltering = specificationAttributeModel.IsAllowFilter,
                    AttributeType = Core.Domain.Catalog.SpecificationAttributeType.Option,
                    DisplayOrder = specificationAttributeModel.DisplayOrder,
                    ProductId = productEntity.Id,
                    SpecificationAttributeOptionId = specificationAttributeOptionEntity.Id,
                    ShowOnProductPage = true
                };
                await _productSpecificationAttributeRepository.InsertAsync(specEntity);
            }
            return productEntity;
        }

        public async Task ImportBackgroundAsync()
        {
            var pendingFolder = "tmp/import";
            var doneFolder = "tmp/imported";
            var failedFolder = "tmp/failed";
            while (true)
            {
                var info = new DirectoryInfo(pendingFolder);
                var files = info.GetFiles("*.json").OrderBy(p => p.CreationTime).ToArray();

                var firstFile = files.FirstOrDefault();
                if (firstFile == null)
                {
                    break;
                }
                var imageFolder = info.GetDirectories(Path.GetFileNameWithoutExtension(firstFile.Name), SearchOption.TopDirectoryOnly).FirstOrDefault();
                var imageFolderPath = imageFolder.FullName;
                try
                {
                    var json = await OpenFileAndReadJson(firstFile);
                    await ImportAsync(json, imageFolderPath);
                    await _logger.InformationAsync($"FptShopCrawler: import file: {firstFile.FullName}");
                    firstFile.MoveTo($"{doneFolder}/{firstFile.Name}");
                    imageFolder.MoveTo($"{doneFolder}/{imageFolder.Name}");
                }
                catch (Exception e)
                {
                    await _logger.ErrorAsync($"FptShopCrawler: import failed file: {firstFile.FullName}", e);
                    firstFile.MoveTo($"{failedFolder}/{firstFile.Name}");
                    imageFolder.MoveTo($"{failedFolder}/{imageFolder.Name}");
                }
            }
        }

        private async Task<Core.Domain.Catalog.Category> GetOrCreateCategoryAsync(ProductType category)
        {
            var existing = await _categoryRepository.Table.Where(r => r.Name == category.Name).FirstOrDefaultAsync();
            if (existing != null)
            {
                return existing;
            }
            existing = new Core.Domain.Catalog.Category()
            {
                Name = category.Name,
            };
            await _categoryRepository.InsertAsync(existing);
            return existing;
        }

        private async Task<Core.Domain.Catalog.Manufacturer> GetOrCreateManufactureAsync(Brand brand)
        {
            var existing = await _manufactureReposity.Table.FirstOrDefaultAsync(r => r.Name == brand.Name);
            if (existing != null)
                return existing;

            var entity = new Core.Domain.Catalog.Manufacturer()
            {
                Name = brand.Name
            };
            await _manufacturerService.InsertManufacturerAsync(entity);
            return entity;
        }

        private async Task<List<Core.Domain.Media.Picture>> GetOrCreatePicturesAsync(string imageFolder, List<Picture> pictures)
        {
            var getOrCreateTasks = pictures.Select(async r => await GetOrCreatePictureAsync(imageFolder, r)).ToList();
            return (await Task.WhenAll(getOrCreateTasks)).ToList();
        }

        private async Task<Core.Domain.Media.Picture> GetOrCreatePictureAsync(string folder, Picture picture)
        {
            var existing = await _pictureRepository.Table.FirstOrDefaultAsync(r => r.SeoFilename == picture.Name);
            if (existing != null)
                return existing;
            var imageAsBinaries = await ReadImageFileToBytesAsync(folder, picture.Name);
            var pictureEntity = await _pictureService.InsertPictureAsync(
                imageAsBinaries,
                MimeTypes.ImageJpeg,
                picture.Name,
                picture.Description,
                picture.Title);
            return pictureEntity;
        }

        private static async Task<byte[]> ReadImageFileToBytesAsync(string folder, string fileName)
        {
            // Load file meta data with FileInfo
            var fileInfo = new FileInfo($"{folder}/{fileName}.jpg");
            //if (!fileInfo.Exists)
            //{
            //    fileInfo = new FileInfo($"{folder}/fallback.jpg");
            //}
            // The byte[] to save the data in
            var data = new byte[fileInfo.Length];

            // Load a filestream and put its content into the byte[]
            using (var fs = fileInfo.OpenRead())
            {
                await fs.ReadAsync(data, 0, data.Length);
            }

            return data;
        }

        #region For specific attributes
        private async Task<Core.Domain.Catalog.SpecificationAttributeGroup> GetOrCreateSpecificationAttributeGroupAsync(string groupName)
        {
            var existing = await _specificationAttributeGroupRepository.Table.FirstOrDefaultAsync(r => r.Name == groupName);
            if (existing != null)
                return existing;
            var entity = new Core.Domain.Catalog.SpecificationAttributeGroup()
            {
                Name = groupName
            };
            await _specificationAttributeGroupRepository.InsertAsync(entity);
            return entity;
        }
        private async Task<Core.Domain.Catalog.SpecificationAttribute> GetOrCreateSpecificationAttributeAsync(string groupName, string name)
        {
            var group = await GetOrCreateSpecificationAttributeGroupAsync(groupName);
            var existing = await _specificationAttributeRepository.Table.FirstOrDefaultAsync(r => r.SpecificationAttributeGroupId == group.Id && r.Name == name);
            if (existing != null)
                return existing;
            var entity = new Core.Domain.Catalog.SpecificationAttribute()
            {
                Name = name,
                SpecificationAttributeGroupId = group.Id
            };
            await _specificationAttributeRepository.InsertAsync(entity);
            return entity;
        }
        private async Task<Core.Domain.Catalog.SpecificationAttributeOption> GetOrCreateSpecificationAttributeOptionAsync(ProductAttribute productAttribute)
        {
            var groupName = productAttribute.GroupName;
            var name = productAttribute.AttributeName;
            var optionName = productAttribute.SpecName;
            var attribute = await GetOrCreateSpecificationAttributeAsync(groupName, name);
            var existing = await _specificationAttributeOptionRepository.Table.FirstOrDefaultAsync(r => r.SpecificationAttributeId == attribute.Id && r.Name == optionName);

            if (existing != null)
                return existing;

            var entity = new Core.Domain.Catalog.SpecificationAttributeOption()
            {
                Name = optionName,
                SpecificationAttributeId = attribute.Id
            };
            await _specificationAttributeOptionRepository.InsertAsync(entity);
            return entity;
        }
        #endregion

        private async Task<string> OpenFileAndReadJson(FileInfo file)
        {
            var text = await File.ReadAllTextAsync(file.FullName);
            return text;
        }
    }
}
