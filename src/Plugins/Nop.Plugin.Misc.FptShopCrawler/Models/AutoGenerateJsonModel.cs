using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nop.Plugin.Misc.FptShopCrawler.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ListGallery
    {
        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("folder")]
        public string Folder { get; set; }

        [JsonProperty("displayOrder")]
        public object DisplayOrder { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class ProductVariant
    {
        [JsonProperty("productID")]
        public int ProductID { get; set; }

        [JsonProperty("colorID")]
        public int ColorID { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("isRecurring")]
        public bool IsRecurring { get; set; }

        [JsonProperty("stockQuantity")]
        public int StockQuantity { get; set; }

        [JsonProperty("disableBuyButton")]
        public bool DisableBuyButton { get; set; }

        [JsonProperty("availableForPreOrder")]
        public bool AvailableForPreOrder { get; set; }

        [JsonProperty("callForPrice")]
        public bool CallForPrice { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("priceBeforeTax")]
        public int PriceBeforeTax { get; set; }

        [JsonProperty("priceOnline")]
        public int PriceOnline { get; set; }

        [JsonProperty("priceMarket")]
        public int PriceMarket { get; set; }

        [JsonProperty("isAllowOrderOutStock")]
        public bool IsAllowOrderOutStock { get; set; }

        [JsonProperty("isApplyDiscount")]
        public object IsApplyDiscount { get; set; }

        [JsonProperty("colorName")]
        public string ColorName { get; set; }

        [JsonProperty("isApplyDiscountSpecial")]
        public object IsApplyDiscountSpecial { get; set; }

        [JsonProperty("isApplyDiscountCrossell")]
        public object IsApplyDiscountCrossell { get; set; }

        [JsonProperty("isApplyDiscountShoppingCart")]
        public object IsApplyDiscountShoppingCart { get; set; }

        [JsonProperty("amountDiscountOnline")]
        public int AmountDiscountOnline { get; set; }

        [JsonProperty("color")]
        public object Color { get; set; }

        [JsonProperty("gallery")]
        public object Gallery { get; set; }

        [JsonProperty("listGallery")]
        public List<ListGallery> ListGallery { get; set; }

        [JsonProperty("promotionText")]
        public object PromotionText { get; set; }

        [JsonProperty("promotionAdmin")]
        public object PromotionAdmin { get; set; }

        [JsonProperty("promotionSummary")]
        public object PromotionSummary { get; set; }

        [JsonProperty("minDeposit")]
        public int MinDeposit { get; set; }

        [JsonProperty("showBuyButton")]
        public bool ShowBuyButton { get; set; }

        [JsonProperty("currentPrice")]
        public object CurrentPrice { get; set; }

        [JsonProperty("urlPicture")]
        public object UrlPicture { get; set; }

        [JsonProperty("priceAfterPromotion")]
        public object PriceAfterPromotion { get; set; }

        [JsonProperty("priceOnlineAfterPromotion")]
        public object PriceOnlineAfterPromotion { get; set; }

        [JsonProperty("typePrice")]
        public object TypePrice { get; set; }

        [JsonProperty("colorImageUrl")]
        public object ColorImageUrl { get; set; }

        [JsonProperty("labelInst")]
        public object LabelInst { get; set; }

        [JsonProperty("priceProSaleMin")]
        public object PriceProSaleMin { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class ProductType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameAscii")]
        public string NameAscii { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class Brand
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameAscii")]
        public string NameAscii { get; set; }

        [JsonProperty("link")]
        public object Link { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("isShow")]
        public bool IsShow { get; set; }

        [JsonProperty("pictureID")]
        public int PictureID { get; set; }

        [JsonProperty("logoPictureID")]
        public int LogoPictureID { get; set; }

        [JsonProperty("brandTotalProduct")]
        public int BrandTotalProduct { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class Color
    {
        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("isShow")]
        public bool IsShow { get; set; }

        [JsonProperty("totalProduct")]
        public int TotalProduct { get; set; }

        [JsonProperty("borderColor")]
        public object BorderColor { get; set; }

        [JsonProperty("stockQuantity")]
        public object StockQuantity { get; set; }

        [JsonProperty("variantId")]
        public int VariantId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class Gallery
    {
        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("folder")]
        public object Folder { get; set; }

        [JsonProperty("displayOrder")]
        public object DisplayOrder { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class ListProductVariant
    {
        [JsonProperty("productID")]
        public int ProductID { get; set; }

        [JsonProperty("colorID")]
        public int ColorID { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("isRecurring")]
        public bool IsRecurring { get; set; }

        [JsonProperty("stockQuantity")]
        public int StockQuantity { get; set; }

        [JsonProperty("disableBuyButton")]
        public bool DisableBuyButton { get; set; }

        [JsonProperty("availableForPreOrder")]
        public bool AvailableForPreOrder { get; set; }

        [JsonProperty("callForPrice")]
        public bool CallForPrice { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("priceBeforeTax")]
        public int PriceBeforeTax { get; set; }

        [JsonProperty("priceOnline")]
        public int PriceOnline { get; set; }

        [JsonProperty("priceMarket")]
        public int PriceMarket { get; set; }

        [JsonProperty("isAllowOrderOutStock")]
        public bool IsAllowOrderOutStock { get; set; }

        [JsonProperty("isApplyDiscount")]
        public bool IsApplyDiscount { get; set; }

        [JsonProperty("colorName")]
        public string ColorName { get; set; }

        [JsonProperty("isApplyDiscountSpecial")]
        public bool IsApplyDiscountSpecial { get; set; }

        [JsonProperty("isApplyDiscountCrossell")]
        public bool IsApplyDiscountCrossell { get; set; }

        [JsonProperty("isApplyDiscountShoppingCart")]
        public bool IsApplyDiscountShoppingCart { get; set; }

        [JsonProperty("amountDiscountOnline")]
        public int AmountDiscountOnline { get; set; }

        [JsonProperty("color")]
        public Color Color { get; set; }

        [JsonProperty("gallery")]
        public Gallery Gallery { get; set; }

        [JsonProperty("listGallery")]
        public object ListGallery { get; set; }

        [JsonProperty("promotionText")]
        public object PromotionText { get; set; }

        [JsonProperty("promotionAdmin")]
        public object PromotionAdmin { get; set; }

        [JsonProperty("promotionSummary")]
        public object PromotionSummary { get; set; }

        [JsonProperty("minDeposit")]
        public int MinDeposit { get; set; }

        [JsonProperty("showBuyButton")]
        public bool ShowBuyButton { get; set; }

        [JsonProperty("currentPrice")]
        public object CurrentPrice { get; set; }

        [JsonProperty("urlPicture")]
        public object UrlPicture { get; set; }

        [JsonProperty("priceAfterPromotion")]
        public object PriceAfterPromotion { get; set; }

        [JsonProperty("priceOnlineAfterPromotion")]
        public object PriceOnlineAfterPromotion { get; set; }

        [JsonProperty("typePrice")]
        public object TypePrice { get; set; }

        [JsonProperty("colorImageUrl")]
        public string ColorImageUrl { get; set; }

        [JsonProperty("labelInst")]
        public string LabelInst { get; set; }

        [JsonProperty("priceProSaleMin")]
        public object PriceProSaleMin { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class ListPicture360
    {
        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("folder")]
        public string Folder { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class Picture
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("folder")]
        public string Folder { get; set; }

        [JsonProperty("displayOrder")]
        public object DisplayOrder { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class ProductAttribute
    {
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("attributeID")]
        public int AttributeID { get; set; }

        [JsonProperty("groupId")]
        public object GroupId { get; set; }

        [JsonProperty("attributeName")]
        public string AttributeName { get; set; }

        [JsonProperty("isAllowFilter")]
        public bool IsAllowFilter { get; set; }

        [JsonProperty("specID")]
        public int SpecID { get; set; }

        [JsonProperty("specName")]
        public string SpecName { get; set; }

        [JsonProperty("specDetail")]
        public object SpecDetail { get; set; }

        [JsonProperty("productID")]
        public int ProductID { get; set; }

        [JsonProperty("idGroup")]
        public int IdGroup { get; set; }

        [JsonProperty("specLink")]
        public string SpecLink { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("isShowDetailSort")]
        public bool IsShowDetailSort { get; set; }

        [JsonProperty("isShowDetail")]
        public bool IsShowDetail { get; set; }

        [JsonProperty("displayOrderDetailSort")]
        public int DisplayOrderDetailSort { get; set; }

        [JsonProperty("displayOrderDetailPopup")]
        public int DisplayOrderDetailPopup { get; set; }

        [JsonProperty("strDetailSort")]
        public string StrDetailSort { get; set; }

        [JsonProperty("displayOrderGroupDetailSort")]
        public int? DisplayOrderGroupDetailSort { get; set; }

        [JsonProperty("strDetailPopup")]
        public string StrDetailPopup { get; set; }

        [JsonProperty("attributeName2")]
        public string AttributeName2 { get; set; }

        [JsonProperty("customGroupDetail")]
        public string CustomGroupDetail { get; set; }

        [JsonProperty("isShowInList")]
        public bool IsShowInList { get; set; }

        [JsonProperty("cssClass")]
        public string CssClass { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("isShowIconDetail")]
        public bool? IsShowIconDetail { get; set; }

        [JsonProperty("iconDetailOrder")]
        public string IconDetailOrder { get; set; }

        [JsonProperty("typeShowPopup")]
        public int TypeShowPopup { get; set; }

        [JsonProperty("attributeLink")]
        public object AttributeLink { get; set; }
    }

    public class ListPictureBreakBox
    {
        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("folder")]
        public string Folder { get; set; }

        [JsonProperty("displayOrder")]
        public object DisplayOrder { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class Product
    {
        [JsonProperty("labelID")]
        public int LabelID { get; set; }

        [JsonProperty("brandID")]
        public int BrandID { get; set; }

        [JsonProperty("brandName")]
        public object BrandName { get; set; }

        [JsonProperty("pictureID")]
        public int PictureID { get; set; }

        [JsonProperty("statusID")]
        public int StatusID { get; set; }

        [JsonProperty("productTypeID")]
        public int ProductTypeID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameAscii")]
        public string NameAscii { get; set; }

        [JsonProperty("nameExt")]
        public string NameExt { get; set; }

        [JsonProperty("nameCate")]
        public string NameCate { get; set; }

        [JsonProperty("code")]
        public object Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("includeInfo")]
        public string IncludeInfo { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("sizeWidth")]
        public int SizeWidth { get; set; }

        [JsonProperty("warranty")]
        public string Warranty { get; set; }

        [JsonProperty("isHot")]
        public bool IsHot { get; set; }

        [JsonProperty("isPreOrder")]
        public bool IsPreOrder { get; set; }

        [JsonProperty("isAllowComment")]
        public bool IsAllowComment { get; set; }

        [JsonProperty("createBy")]
        public object CreateBy { get; set; }

        [JsonProperty("urlPicture")]
        public string UrlPicture { get; set; }

        [JsonProperty("displayDiscount")]
        public string DisplayDiscount { get; set; }

        [JsonProperty("seoTitle")]
        public string SeoTitle { get; set; }

        [JsonProperty("seoDescription")]
        public string SeoDescription { get; set; }

        [JsonProperty("seoKeyword")]
        public object SeoKeyword { get; set; }

        [JsonProperty("comingSoonInfo")]
        public object ComingSoonInfo { get; set; }

        [JsonProperty("linkApp")]
        public object LinkApp { get; set; }

        [JsonProperty("policy")]
        public object Policy { get; set; }

        [JsonProperty("isShowFormIdea")]
        public bool IsShowFormIdea { get; set; }

        [JsonProperty("isApplyNewTemplate")]
        public bool IsApplyNewTemplate { get; set; }

        [JsonProperty("urlLabelPicture")]
        public object UrlLabelPicture { get; set; }

        [JsonProperty("labelName")]
        public string LabelName { get; set; }

        [JsonProperty("labelInst")]
        public object LabelInst { get; set; }

        [JsonProperty("labelFlashSale")]
        public object LabelFlashSale { get; set; }

        [JsonProperty("urlLabelPictureMobile")]
        public object UrlLabelPictureMobile { get; set; }

        [JsonProperty("urlArticlePicture")]
        public object UrlArticlePicture { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("overviewVideo")]
        public string OverviewVideo { get; set; }

        [JsonProperty("overview360")]
        public string Overview360 { get; set; }

        [JsonProperty("videoDetail")]
        public string VideoDetail { get; set; }

        [JsonProperty("videoRating")]
        public object VideoRating { get; set; }

        [JsonProperty("hightlightsShortDes")]
        public string HightlightsShortDes { get; set; }

        [JsonProperty("attachedAccessories")]
        public string AttachedAccessories { get; set; }

        [JsonProperty("guide")]
        public string Guide { get; set; }

        [JsonProperty("productVariant")]
        public ProductVariant ProductVariant { get; set; }

        [JsonProperty("productType")]
        public ProductType ProductType { get; set; }

        [JsonProperty("brand")]
        public Brand Brand { get; set; }

        [JsonProperty("listProductVariant")]
        public List<ListProductVariant> ListProductVariant { get; set; }

        [JsonProperty("listPicture360")]
        public List<ListPicture360> ListPicture360 { get; set; }

        [JsonProperty("listPictureSlide")]
        public List<Picture> ListPictureSlide { get; set; }

        [JsonProperty("listPictureGallery")]
        public List<Picture> ListPictureGallery { get; set; }

        [JsonProperty("listPictureGalleryGuideSlide")]
        public object ListPictureGalleryGuideSlide { get; set; }

        [JsonProperty("listPictureInBox")]
        public List<object> ListPictureInBox { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("hightlightsDes")]
        public string HightlightsDes { get; set; }

        [JsonProperty("urlHotPicture")]
        public string UrlHotPicture { get; set; }

        [JsonProperty("infoDriver")]
        public object InfoDriver { get; set; }

        [JsonProperty("isComingSoon")]
        public bool IsComingSoon { get; set; }

        [JsonProperty("productAttributes")]
        public List<ProductAttribute> ProductAttributes { get; set; }

        [JsonProperty("listProductCompare")]
        public object ListProductCompare { get; set; }

        [JsonProperty("isOrderLanding")]
        public bool IsOrderLanding { get; set; }

        [JsonProperty("bestPriceCampaign")]
        public object BestPriceCampaign { get; set; }

        [JsonProperty("isBestSeller")]
        public bool IsBestSeller { get; set; }

        [JsonProperty("isGetBestsellerPhone")]
        public object IsGetBestsellerPhone { get; set; }

        [JsonProperty("headerPopupGetPhone")]
        public object HeaderPopupGetPhone { get; set; }

        [JsonProperty("contentPopupGetPhone")]
        public object ContentPopupGetPhone { get; set; }

        [JsonProperty("linkLanding")]
        public object LinkLanding { get; set; }

        [JsonProperty("isAllowLanding")]
        public bool IsAllowLanding { get; set; }

        [JsonProperty("totalRating")]
        public int TotalRating { get; set; }

        [JsonProperty("advRating")]
        public int AdvRating { get; set; }

        [JsonProperty("interestRate")]
        public int InterestRate { get; set; }

        [JsonProperty("hightlights")]
        public object Hightlights { get; set; }

        [JsonProperty("isPaymentOnline")]
        public object IsPaymentOnline { get; set; }

        [JsonProperty("isNotBusiness")]
        public bool IsNotBusiness { get; set; }

        [JsonProperty("isDeals")]
        public bool IsDeals { get; set; }

        [JsonProperty("isShowPreOrder")]
        public bool IsShowPreOrder { get; set; }

        [JsonProperty("preOrderDateStart")]
        public object PreOrderDateStart { get; set; }

        [JsonProperty("preOrderDateEnd")]
        public object PreOrderDateEnd { get; set; }

        [JsonProperty("listCampaignShortItem")]
        public object ListCampaignShortItem { get; set; }

        [JsonProperty("isGetPhoneGirl")]
        public object IsGetPhoneGirl { get; set; }

        [JsonProperty("hotRepayment")]
        public object HotRepayment { get; set; }

        [JsonProperty("totalOrder")]
        public int TotalOrder { get; set; }

        [JsonProperty("totaView")]
        public int TotaView { get; set; }

        [JsonProperty("urlPictureHotCateLaptop")]
        public object UrlPictureHotCateLaptop { get; set; }

        [JsonProperty("isUseOrderPage")]
        public bool IsUseOrderPage { get; set; }

        [JsonProperty("isAllowRedirect")]
        public bool IsAllowRedirect { get; set; }

        [JsonProperty("linkRedirect")]
        public object LinkRedirect { get; set; }

        [JsonProperty("listProductSame")]
        public object ListProductSame { get; set; }

        [JsonProperty("productTypeNameAscii")]
        public object ProductTypeNameAscii { get; set; }

        [JsonProperty("listPictureFromCamera")]
        public List<object> ListPictureFromCamera { get; set; }

        [JsonProperty("isNeverBusiness")]
        public bool IsNeverBusiness { get; set; }

        [JsonProperty("listProductCapacityGroup")]
        public object ListProductCapacityGroup { get; set; }

        [JsonProperty("listPictureBreakBox")]
        public List<ListPictureBreakBox> ListPictureBreakBox { get; set; }

        [JsonProperty("promotionName")]
        public object PromotionName { get; set; }

        [JsonProperty("promotionUrlImage")]
        public object PromotionUrlImage { get; set; }

        [JsonProperty("priceShockDiscount")]
        public object PriceShockDiscount { get; set; }

        [JsonProperty("isAutoUpdateLabel")]
        public object IsAutoUpdateLabel { get; set; }

        [JsonProperty("labelLeftID")]
        public object LabelLeftID { get; set; }

        [JsonProperty("labelLeftName")]
        public object LabelLeftName { get; set; }

        [JsonProperty("urlLabelLeftPicture")]
        public object UrlLabelLeftPicture { get; set; }

        [JsonProperty("urlPictureLabelPd")]
        public object UrlPictureLabelPd { get; set; }

        [JsonProperty("productGroupId")]
        public object ProductGroupId { get; set; }

        [JsonProperty("displayType")]
        public object DisplayType { get; set; }

        [JsonProperty("saleActiveDate")]
        public object SaleActiveDate { get; set; }

        [JsonProperty("listProductGroupDetail")]
        public List<object> ListProductGroupDetail { get; set; }

        [JsonProperty("pricePreOrder")]
        public int PricePreOrder { get; set; }

        [JsonProperty("skuFTG")]
        public object SkuFTG { get; set; }

        [JsonProperty("guideDesktop")]
        public string GuideDesktop { get; set; }

        [JsonProperty("guideMobile")]
        public string GuideMobile { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class OrderModel
    {
        [JsonProperty("productVariantId")]
        public int ProductVariantId { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("priceMarket")]
        public int PriceMarket { get; set; }

        [JsonProperty("stockQuantity")]
        public int StockQuantity { get; set; }

        [JsonProperty("disableBuyButton")]
        public bool DisableBuyButton { get; set; }

        [JsonProperty("isPreOrder")]
        public bool IsPreOrder { get; set; }

        [JsonProperty("isDisplayButton")]
        public bool IsDisplayButton { get; set; }

        [JsonProperty("isRecurring")]
        public bool IsRecurring { get; set; }

        [JsonProperty("isComingSoon")]
        public bool IsComingSoon { get; set; }

        [JsonProperty("labelId")]
        public int LabelId { get; set; }

        [JsonProperty("includeInfo")]
        public string IncludeInfo { get; set; }

        [JsonProperty("hightlightsShortDes")]
        public string HightlightsShortDes { get; set; }

        [JsonProperty("attachedAccessories")]
        public string AttachedAccessories { get; set; }

        [JsonProperty("discountOnline")]
        public int DiscountOnline { get; set; }

        [JsonProperty("sku")]
        public object Sku { get; set; }

        [JsonProperty("showBuyButton")]
        public bool ShowBuyButton { get; set; }

        [JsonProperty("isOrderLanding")]
        public bool IsOrderLanding { get; set; }

        [JsonProperty("isNewTemplate")]
        public bool IsNewTemplate { get; set; }

        [JsonProperty("isShowPreOrder")]
        public bool IsShowPreOrder { get; set; }

        [JsonProperty("preOrderDateStart")]
        public object PreOrderDateStart { get; set; }

        [JsonProperty("preOrderDateEnd")]
        public object PreOrderDateEnd { get; set; }

        [JsonProperty("isNotBusiness")]
        public bool IsNotBusiness { get; set; }

        [JsonProperty("isUseOrderPage")]
        public bool IsUseOrderPage { get; set; }

        [JsonProperty("hotRepayment")]
        public object HotRepayment { get; set; }

        [JsonProperty("isNeverBusiness")]
        public bool IsNeverBusiness { get; set; }

        [JsonProperty("availableForPreOrder")]
        public bool AvailableForPreOrder { get; set; }

        [JsonProperty("minDeposit")]
        public object MinDeposit { get; set; }
    }

    public class Model
    {
        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("productGroup")]
        public object ProductGroup { get; set; }

        [JsonProperty("orderModel")]
        public OrderModel OrderModel { get; set; }

        [JsonProperty("listRelatedProduct")]
        public object ListRelatedProduct { get; set; }

        [JsonProperty("canonicalUrl")]
        public object CanonicalUrl { get; set; }

        [JsonProperty("oldProductPrice")]
        public int OldProductPrice { get; set; }
    }

    public class Datas
    {
        [JsonProperty("model")]
        public Model Model { get; set; }
    }

    public class Root
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("datas")]
        public Datas Datas { get; set; }
    }


}
