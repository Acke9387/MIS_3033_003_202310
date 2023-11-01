using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebVersionOfChuckNorris.Models;

namespace WebVersionOfChuckNorris.Controllers
{
    public class ChuckNorrisController : Controller
    {
        public IActionResult Index()
        {

            string url = "https://api.chucknorris.io/jokes/random";
            ChuckNorrisAPI chuckNorrisAPI;
            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync(url).Result;

                 chuckNorrisAPI = JsonConvert.DeserializeObject<ChuckNorrisAPI>(json);

            }
            chuckNorrisAPI.icon_url = "https://4.bp.blogspot.com/-AqhMrSKWgCw/WNgmZTvmsVI/AAAAAAAAaTg/Q_FJ21XOArUw2fOMrsCGfARlD9336BmNwCLcB/s1600/20%2BGifs%2BChuck%2BNorris%2B7.gif";
            return View(chuckNorrisAPI);
        }
    }
}
