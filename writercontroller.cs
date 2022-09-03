using Core_Bootcamp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Bootcamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public ActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);

            return Json(jsonWriters);
        }


        public IActionResult GetWriterByID(int wrid)
        {
            var findwriter = writers.FirstOrDefault(x => x.id == wrid);
            var jsonWriters = JsonConvert.SerializeObject(findwriter);
            return Json(jsonWriters);
        }


        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }


        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.id == id);
            writers.Remove(writer);
            return Json(writer);
        }



        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.id == w.id);
            writer.name = w.name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                id=1,
                name="serhat"
            },
            new WriterClass
            {
                id=2,
                name="demir"
            },
            new WriterClass
            {
                id=3,
                name="van"

            },
            new WriterClass
            {
                id=4,
                name="sami"
            }
        };
    }
}
