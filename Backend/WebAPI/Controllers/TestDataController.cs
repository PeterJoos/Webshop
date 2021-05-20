using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using WPLClassLibTeam02.Data;

namespace WplWebApiTeam02.Controllers
{
    //testcontroller
    [ApiController]
    [Route("[controller]")]
    public class TestDataController : Controller
    {
        [HttpGet]
        public string Get()
        {
            string JsonString = string.Empty;
            JsonString = JsonConvert.SerializeObject(EntityData.TestData.Get());
            return JsonString;

        }

        [HttpPost]
        public IActionResult Create([FromForm] FormTestDataObject form)
        {
        WPLClassLibTeam02.Entity.TestData td = new WPLClassLibTeam02.Entity.TestData();
        td.Tekst = form.Tekst;
        DateTime dtm = DateTime.Now;
        DateTime.TryParse(form.Datum, out dtm);
        td.Datum = dtm;
        int getal = 0;
        int.TryParse(form.Getal, out getal);
        td.Getal = getal;
        EntityData.TestData.Insert(td);
        return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }
    }

    public class FormTestDataObject
    {
        public string Tekst { get; set; }
        public string Datum { get; set; }
        public string Getal { get; set; }
    }
}
