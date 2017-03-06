using darussalambd.Models;
using Plugin.RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace darussalambd.Services
{
    public class CartService
    {
        public async Task<List<Models.tbl_DarussalamMobileCart>> GetCartsAsync(string url)
        {
            RestClient<Models.tbl_DarussalamMobileCart> restClient = new Plugin.RestClient.RestClient<Models.tbl_DarussalamMobileCart>();
            var userList = await restClient.GetAsync(url);
            return userList;
        }

        public async Task PostCartAsync(tbl_DarussalamMobileCart _object, string url)
        {

            RestClient<Models.tbl_DarussalamMobileCart> restClient = new Plugin.RestClient.RestClient<Models.tbl_DarussalamMobileCart>();
            var user = await restClient.PostAsync(_object, url);
            // return item;
        }


        //public async Task<List<Models.tbl_DarussalamMobileCart>> PutAsync(string id, tbl_DarussalamMobileCart obj, string url)
        //{
        // //   tbl_DarussalamMobileCart obj = new

        //    RestClient<Models.tbl_DarussalamMobileCart> restClient = new Plugin.RestClient.RestClient<Models.tbl_DarussalamMobileCart>();
        //    var userList = await restClient.PutAsync(id, obj,url);
        //    return userList;
        //}


    }
}
