using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teleware.Foundation.Caching;
using Teleware.Foundation.Data;
using Teleware.Data.Impl;
using Teleware.Foundation.Exceptions;

namespace Playground.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            throw new ArgumentNullException("?");
            return View();
        }

        public IActionResult ClientNoticeableException()
        {
            throw new Exp("?");
            //throw new ArgumentNullException("?");
            //return new ObjectResult(new { text = "a quick fox" });
            //return new ObjectResult("a quick fox");
            //return Json("a quick fox");
        }

        public IActionResult ArgumentNullException()
        {
            throw new ArgumentNullException("?");
            //throw new ArgumentNullException("?");
            //return new ObjectResult(new { text = "a quick fox" });
            //return new ObjectResult("a quick fox");
            //return Json("a quick fox");
        }

        public IActionResult HttpClientNoticeableException()
        {
            throw new Exp2("?", 500);
            //throw new ArgumentNullException("?");
            //return new ObjectResult(new { text = "a quick fox" });
            //return new ObjectResult("a quick fox");
            //return Json("a quick fox");
        }

        public IActionResult Nul()
        {
            return new JsonResult(null);
        }

        public string Str()
        {
            return "a quick fox";
        }

        public IActionResult StrObj()
        {
            return new ObjectResult("a quick fox");
        }

        public IActionResult StrJson()
        {
            return new JsonResult("a quick fox");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

/* request.http

GET http://localhost:5000/Home/ClientNoticeableException HTTP/1.1
Content-Type: application/json
Accept: application/json

###
GET http://localhost:5000/Home/ArgumentNullException HTTP/1.1
Content-Type: application/json
Accept: application/json

###
GET http://localhost:5000/Home/HttpClientNoticeableException HTTP/1.1
Content-Type: application/json
Accept: application/json

###
GET http://localhost:5000/Home/Str HTTP/1.1
Content-Type: application/json
Accept: application/json

###
GET http://localhost:5000/Home/StrObj HTTP/1.1
Content-Type: application/json
Accept: application/json

###
GET http://localhost:5000/Home/StrJson HTTP/1.1
Content-Type: application/json
Accept: application/json

###
GET http://localhost:5000/Home/Nul HTTP/1.1
Content-Type: application/json
Accept: application/json
 */