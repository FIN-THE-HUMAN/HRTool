using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;
using System.Collections.Generic;
using HRTool.DAL.Models;

namespace HRTool.Services
{
    public static class YandexJobParser
    {
        public static List<string> Parse(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            var parser = new HtmlParser();
            var document = parser.Parse(stream);
            var vacancies = document.QuerySelectorAll("td.serp-vacancy__cell");
            System.Console.WriteLine(vacancies.Length.ToString());
            List<string> vacanciesList = new List<string>();
            foreach(var e in vacancies)
            {
                Vacancy vacancy = new Vacancy();
                 var name =
                    e.QuerySelector("div.clearfix>h3.heading heading_level_3 serp-vacancy__name>a.link link_upped_yes stat__click");
                vacancy.Name = name.TextContent;
                string Name = name.TextContent;
                vacanciesList.Add(Name + "Привет");
            }

            return vacanciesList;
        }
    }
}