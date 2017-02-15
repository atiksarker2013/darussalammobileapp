using darussalambd.Models;
using Plugin.RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace darussalambd.Services
{
    public class LoginServices
    {
        public async Task<List<Models.tbl_DarussalamMobileUser>> GetUsersAsync(string url)
        {
            RestClient<Models.tbl_DarussalamMobileUser> restClient = new Plugin.RestClient.RestClient<Models.tbl_DarussalamMobileUser>() ;
            var userList = await restClient.GetAsync(url);
            return userList;
        }

        public async Task PostUserAsync(tbl_DarussalamMobileUser _object,string url)
        {
             
            RestClient<Models.tbl_DarussalamMobileUser> restClient = new Plugin.RestClient.RestClient<Models.tbl_DarussalamMobileUser>();
            var user = await restClient.PostAsync(_object,url);
           // return item;
        }
    }
}
