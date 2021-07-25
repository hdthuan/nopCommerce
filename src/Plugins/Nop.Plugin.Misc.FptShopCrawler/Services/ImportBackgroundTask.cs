using Nop.Services.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Nop.Plugin.Misc.FptShopCrawler.Services
{
    /// <summary>
    /// Represents a schedule task to synchronize contacts
    /// </summary>
    public class ImportBackgroundTask : IScheduleTask
    {
        #region Fields

        private readonly IFptShopImportService _fptShopImportService;

        #endregion

        #region Ctor

        public ImportBackgroundTask(IFptShopImportService fptShopImportService)
        {
            _fptShopImportService = fptShopImportService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Execute task
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task ExecuteAsync()
        {
            await _fptShopImportService.ImportBackgroundAsync();
        }

        #endregion
    }
}