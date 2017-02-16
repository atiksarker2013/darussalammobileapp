using darussalambd.Models;
using Plugin.RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace darussalambd.Services
{
  public  class BookServices
    {
        public async Task<List<Models.tbl_DarusSalamBook>> GetUsersAsync(string url)
        {
            RestClient<Models.tbl_DarusSalamBook> restClient = new Plugin.RestClient.RestClient<Models.tbl_DarusSalamBook>();
            var userList = await restClient.GetAsync(url);
            return userList;
        }
    }
}
