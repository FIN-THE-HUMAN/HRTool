using Microsoft.AspNetCore.Mvc;
using HRTool.Services;
using System.Collections.Generic;
using System.Text;

namespace HRTool.Controllers
{
    public class TestController : Controller
    {
        [Route("Test")]
        public string Index()
        {
            List<string> vacancies = YandexJobParser.Parse("https://rabota.yandex.ru/search?text=программист&rid=6");
            StringBuilder sb = new StringBuilder();
            foreach (var item in vacancies)
            {
                sb.Append(item + "fghjk");
            }
            return sb.ToString();
        }
    }
}
