using Microsoft.AspNetCore.Mvc;

namespace DNTPrac_447.Controllers
{
    [Route("firstc")]
    public class FirstController : Controller
    {
        [Route("name")]
        public string getName()
        {
            return "Pradeep Shet";
        }
        [Route("addr/{id}/{country}")]
        public string getAddress(int id, string country)
        {
            return "Pradeep Shet, Mumbai " + id + " " + country;
        }
    }
}
