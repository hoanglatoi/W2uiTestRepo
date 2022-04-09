using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W2UISample.Models;
using System.Text.Json;
using System.IO;

namespace W2UISample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetStyleScreen(string domain, int id, int pageNum)
        {

            PageInfo? page = new PageInfo();
            int count = 3;
            while (count-- > 0)
            {
                //Get style
                PagesList pagesList = new PagesList();

                var options = new JsonSerializerOptions { WriteIndented = true };
                string fileName = "json.json";
                string jsonString = System.IO.File.ReadAllText(fileName);
                pagesList = JsonSerializer.Deserialize<PagesList>(jsonString)!;


                if (pagesList.TablePages != null)
                    page = pagesList.TablePages.Find(x => x.ScreenName == domain && x.PageNum == Convert.ToInt32(pageNum));

                if(page != null)
                {
                    count = 0;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
          
            return Json(page.ColNames);
        }

        [HttpPost]
        public IActionResult GetDataScreen(string domain, int id, int pageNum)
        {
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
            PageInfo? page = new PageInfo();
            int count = 3;
            while (count-- > 0)
            {
                //Get style
                PagesList pagesList = new PagesList();

                var options = new JsonSerializerOptions { WriteIndented = true };
                string fileName = "json.json";
                string jsonString = System.IO.File.ReadAllText(fileName);
                pagesList = JsonSerializer.Deserialize<PagesList>(jsonString)!;


                if (pagesList.TablePages != null)
                    page = pagesList.TablePages.Find(x => x.ScreenName == domain && x.PageNum == Convert.ToInt32(pageNum));

                if (page != null)
                {
                    count = 0;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }

            for(int rowNum=0; rowNum <10; rowNum++)
            {
                Dictionary<string, string> rowData = new Dictionary<string, string>();
                rowData["recid"] = rowNum.ToString();

                int colNum = 0;
                foreach (string col in page.ColNames)
                {
                    rowData[colNum.ToString()] = rowNum.ToString();
                    colNum++;
                }
                data.Add(rowData);

            }

            return Json(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}