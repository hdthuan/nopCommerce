using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Nop.Core;
using Nop.Core.Domain.Cms;
using Nop.Core.Domain.Tasks;
using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Plugins;
using Nop.Services.Stores;
using Nop.Services.Tasks;
using Nop.Web.Framework.Menu;
using Task = System.Threading.Tasks.Task;

namespace Nop.Plugin.Misc.FptShopCrawler
{
    /// <summary>
    /// Represents the FptShopCrawler plugin
    /// </summary>
    public class FptShopCrawlerPlugin : BasePlugin, IMiscPlugin, IAdminMenuPlugin
    {
        #region Fields

        private readonly IWebHelper _webHelper;
        private readonly IScheduleTaskService _scheduleTaskService;

        #endregion

        #region Ctor

        public FptShopCrawlerPlugin(IWebHelper webHelper,
            IScheduleTaskService scheduleTaskService
            )
        {
            _webHelper = webHelper;
            _scheduleTaskService = scheduleTaskService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/FptShopCrawler/Configure";
        }

        public Task ManageSiteMapAsync(SiteMapNode rootNode)
        {
            var menuItem = new SiteMapNode()
            {
                SystemName = "YourCustomSystemName",
                Title = "Plugin Title",
                ControllerName = "FptShopCrawler",
                ActionName = "ImportProductByText",
                Visible = true,
                RouteValues = new RouteValueDictionary() { { "area", "Admin" } },
            };
            var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Third party plugins");
            if (pluginNode != null)
                pluginNode.ChildNodes.Add(menuItem);
            else
                rootNode.ChildNodes.Add(menuItem);

            return Task.CompletedTask;
        }
        private string _backgroundTaskType = "Nop.Plugin.Misc.FptShopCrawler.Services.ImportBackgroundTask";
        /// <summary>
        /// Install the plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            //install import background task
            if (await _scheduleTaskService.GetTaskByTypeAsync(_backgroundTaskType) == null)
            {
                await _scheduleTaskService.InsertTaskAsync(new ScheduleTask
                {
                    Enabled = true,
                    Seconds = 60,
                    Name = "FptShopImportBackgroundTaskName",
                    Type = _backgroundTaskType,
                });
            }

            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            //schedule task
            var task = await _scheduleTaskService.GetTaskByTypeAsync(_backgroundTaskType);
            if (task != null)
                await _scheduleTaskService.DeleteTaskAsync(task);

            await base.UninstallAsync();
        }

        #endregion
    }
}
