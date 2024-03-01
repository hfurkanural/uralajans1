using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication5.Models;
using WebApplication5.Models.MVVM;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        cls_Contact contactCLS = new cls_Contact();
        UralAjansContext context = new UralAjansContext();
        MainPageModel mpm = new MainPageModel();
        cls_Search cls_Search = new cls_Search();
        cls_Newsletter cls_Newsletter = new cls_Newsletter();
        public IActionResult Index()
        {
            mpm.Settings = context.Settings.OrderBy(s => s.SettingID).ToList();
            mpm.Portfolio = context.Portfolio.OrderByDescending(p => p.PortfolioID).Take(6).ToList();
            ViewBag.Baslik = "Anasayfa";

            return View(mpm);
        }
        public IActionResult IndexLight()
        {
            mpm.Settings = context.Settings.OrderBy(s => s.SettingID).ToList();
            mpm.Portfolio = context.Portfolio.OrderByDescending(p => p.PortfolioID).Take(6).ToList();
            ViewBag.Baslik = "Anasayfa";

            return View(mpm);
        }

        public IActionResult AboutUs()
        {
            ViewBag.telephone = context.Settings.SingleOrDefault().PhoneNumber;
            ViewBag.Baslik = "Hakkımızda";

            return View();
        }
        public IActionResult AboutUsLight()
        {
            ViewBag.Baslik = "Hakkımızda";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Baslik = "Hizmetlerimiz";

            return View();
        }
        public ActionResult ServicesLight()
        {
            ViewBag.Baslik = "Hizmetlerimiz";

            return View();
        }
        public IActionResult Portfolio()
        {
            ViewBag.Baslik = "Portfolyo";

            List<Portfolio> portfolio = context.Portfolio.OrderByDescending(p => p.PortfolioID).Take(8).ToList();
            return View(portfolio);
        }
        public IActionResult PortfolioLight()
        {
            ViewBag.Baslik = "Portfolyo";

            List<Portfolio> portfolio = context.Portfolio.OrderByDescending(p => p.PortfolioID).Take(8).ToList();
            return View(portfolio);
        }
        [HttpGet]
        public IActionResult Contact()
        {
            ViewBag.telephone = context.Settings.SingleOrDefault().PhoneNumber;
            ViewBag.email = context.Settings.SingleOrDefault().Email;
            ViewBag.facebook = context.Settings.SingleOrDefault().Facebook;
            ViewBag.twitter = context.Settings.SingleOrDefault().Twitter;
            ViewBag.linkedin = context.Settings.SingleOrDefault().LinkedIn;
            ViewBag.instagram = context.Settings.SingleOrDefault().Instagram;
            ViewBag.address = context.Settings.SingleOrDefault().Address;
            ViewBag.Baslik = "İletişim";

            return View();
        }
        [HttpGet]
        public IActionResult ContactLight()
        {
            ViewBag.telephone = context.Settings.SingleOrDefault().PhoneNumber;
            ViewBag.email = context.Settings.SingleOrDefault().Email;
            ViewBag.facebook = context.Settings.SingleOrDefault().Facebook;
            ViewBag.twitter = context.Settings.SingleOrDefault().Twitter;
            ViewBag.linkedin = context.Settings.SingleOrDefault().LinkedIn;
            ViewBag.instagram = context.Settings.SingleOrDefault().Instagram;
            ViewBag.address = context.Settings.SingleOrDefault().Address;

            ViewBag.Baslik = "İletişim";

            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            bool answer = contactCLS.AddMessage(contact);
            if (answer == true)
            {
                TempData["Message"] = "Mesajınız Gönderildi";
            }
            else
            {
                TempData["Message"] = "Hata";
            }

            return View();
        }
        public IActionResult EcommerceDetail()
        {
            ViewBag.Baslik = "E-Ticaret Hizmetimiz";

            ViewBag.phonenumber = context.Settings.FirstOrDefault().PhoneNumber;
            return View();
        }
        public IActionResult EcommerceDetailLight()
        {
            ViewBag.Baslik = "E-Ticaret Hizmetimiz";

            ViewBag.phonenumber = context.Settings.FirstOrDefault().PhoneNumber;
            return View();
        }
        public IActionResult WebDesignDetail()
        {
            ViewBag.Baslik = "Web Tasarım Hizmetimiz";

            ViewBag.phonenumber = context.Settings.FirstOrDefault().PhoneNumber;

            return View();
        }
        public IActionResult WebDesignDetailLight()
        {
            ViewBag.Baslik = "Web Tasarım Hizmetimiz";

            ViewBag.phonenumber = context.Settings.FirstOrDefault().PhoneNumber;

            return View();
        }
        public IActionResult SoftwareDevelopmentDetail()
        {
            ViewBag.Baslik = "Yazılım Geliştirme Hizmetimiz";

            ViewBag.phonenumber = context.Settings.FirstOrDefault().PhoneNumber;

            return View();
        }
        public IActionResult SoftwareDevelopmentDetailLight()
        {
            ViewBag.Baslik = "Yazılım Geliştirme Hizmetimiz";

            ViewBag.phonenumber = context.Settings.FirstOrDefault().PhoneNumber;

            return View();
        }
        public IActionResult GraphicDesignDetail()
        {
            ViewBag.Baslik = "Grafik Tasarım Hizmetimiz";

            ViewBag.phonenumber = context.Settings.FirstOrDefault().PhoneNumber;

            return View();
        }
        public IActionResult GraphicDesignDetailLight()
        {
            ViewBag.Baslik = "Grafik Tasarım Hizmetimiz";

            ViewBag.phonenumber = context.Settings.FirstOrDefault().PhoneNumber;

            return View();
        }
        public IActionResult SocialMediaDetail()
        {
            ViewBag.Baslik = "Sosyal Medya Hizmetimiz";

            ViewBag.phonenumber = context.Settings.FirstOrDefault().PhoneNumber;

            return View();
        }
        public IActionResult SocialMediaDetailLight()
        {
            ViewBag.Baslik = "Sosyal Medya Hizmetimiz";

            ViewBag.phonenumber = context.Settings.FirstOrDefault().PhoneNumber;


            return View();
        }
        public IActionResult SEODetail()
        {
            ViewBag.Baslik = "SEO Hizmetimiz";

            ViewBag.phonenumber = context.Settings.FirstOrDefault().PhoneNumber;

            return View();
        }
        public IActionResult SEODetailLight()
        {
            ViewBag.Baslik = "SEO Hizmetimiz";

            ViewBag.phonenumber = context.Settings.FirstOrDefault().PhoneNumber;

            return View();
        }
        public PartialViewResult gettingProducts(string id)
        {
            id = id.ToUpper(new System.Globalization.CultureInfo("tr-TR"));
            List<sp_Search> ulist = cls_Search.sp_Searches(id);
            string json = JsonConvert.SerializeObject(ulist);
            var response = JsonConvert.DeserializeObject<List<sp_Search>>(json);
            return PartialView(response);
        }
        public IActionResult Error(int code)
        {
            return View();
        }
        public IActionResult ErrorLight(int code) 
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Mailing()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Mailing(Newsletter news) 
        {

            bool answer = cls_Newsletter.EmailInsert(news);
            if (answer == true)
            {
                TempData["Message"] = "E-posta Adresiniz Başarıyla Eklendi";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "HATA";
                return RedirectToAction("Index");
            }
        }
    }
}
