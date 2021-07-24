using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Messages;
using Nop.Plugin.Misc.FptShopCrawler.Models;
using Nop.Plugin.Misc.FptShopCrawler.Services;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Models.Extensions;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.FptShopCrawler.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class FptShopCrawlerController : BasePluginController
    {
        #region Fields
        private readonly IFptShopImportService _fptShopImportService;

        #endregion

        #region Ctor

        public FptShopCrawlerController(IFptShopImportService fptShopImportService)
        {
            _fptShopImportService = fptShopImportService;
        }

        #endregion

        #region Methods

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public async Task<IActionResult> Configure()
        {
            return View("~/Plugins/Misc.FptShopCrawler/Views/Configure.cshtml");
        }

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public async Task<IActionResult> ImportProductByText()
        {
            return View("~/Plugins/Misc.FptShopCrawler/Views/ImportProductByText.cshtml", new ImportRequestModel());
        }

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        [HttpPost, ActionName("ImportProductByText")]
        public async Task<IActionResult> ImportProductAsync(ImportRequestModel model)
        {
            await _fptShopImportService.ImportAsync(model.JsonText);
            return View("~/Plugins/Misc.FptShopCrawler/Views/ImportProductByText.cshtml", model);
        }

        #endregion
    }
}