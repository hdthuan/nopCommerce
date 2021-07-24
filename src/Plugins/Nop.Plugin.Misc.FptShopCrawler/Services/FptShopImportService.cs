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
using Nop.Services.Media;

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
        public FptShopImportService(
            IProductService productService,
            IRepository<Core.Domain.Catalog.Category> categoryRepository,
            ICategoryService categoryService,
            IRepository<Core.Domain.Catalog.Manufacturer> manufactureRepository,
            IManufacturerService manufacturerService,
            IPictureService pictureService,
            IRepository<Core.Domain.Media.Picture> pictureRepository
            )
        {
            _productService = productService;
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
            _manufactureReposity = manufactureRepository;
            _manufacturerService = manufacturerService;
            _pictureService = pictureService;
            _pictureRepository = pictureRepository;
        }

        public async Task<Nop.Core.Domain.Catalog.Product> ImportAsync(string json)
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
                AllowCustomerReviews = true
            };

            await _productService.InsertProductAsync(productEntity);
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
            var pictureEntities = await GetOrCreatePicturesAsync(listPictureModels);
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
            // TODO: mapping specificAttributes
            //
            return productEntity;
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

        private async Task<List<Core.Domain.Media.Picture>> GetOrCreatePicturesAsync(List<Picture> pictures)
        {
            var getOrCreateTasks = pictures.Select(async r => await GetOrCreatePictureAsync("tmp/import/images", r)).ToList();
            return (await Task.WhenAll(getOrCreateTasks)).ToList();
        }

        private async Task<Core.Domain.Media.Picture> GetOrCreatePictureAsync(string folder, Picture picture)
        {
            var existing = await _pictureRepository.Table.FirstOrDefaultAsync(r => r.SeoFilename == picture.Name);
            if (existing != null)
                return existing;
            byte[] imageAsBinaries = await ReadImageFileToBytesAsync(folder, picture.Name);
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
            if (!fileInfo.Exists)
            {
                fileInfo = new FileInfo($"{folder}/fallback.jpg");
            }
            // The byte[] to save the data in
            var data = new byte[fileInfo.Length];

            // Load a filestream and put its content into the byte[]
            using (FileStream fs = fileInfo.OpenRead())
            {
                await fs.ReadAsync(data, 0, data.Length);
            }

            return data;
        }
    }
}
