using System;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;

namespace Nop.Plugin.Misc.FptShopCrawler.Services
{
    public interface IFptShopImportService
    {
        Task<Product> ImportAsync(string json, string imageFolder = null);
        Task ImportBackgroundAsync();
    }
}
