using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;
using WebApplication5.Models.MVVM;
using System;
using System.Drawing;
using System.IO;

namespace WebApplication5.Controllers
{
    public class AdminController : Controller
    {
        UralAjansContext context = new UralAjansContext();
        MainPageModel mpm = new MainPageModel();
        cls_Portfolio cls_Portfolio = new cls_Portfolio();
        cls_Clients cls_Clients = new cls_Clients();
        private readonly IWebHostEnvironment _webHost;
        public AdminController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }
        public IActionResult Index()
        {
            mpm.Settings = context.Settings.OrderBy(s => s.SettingID).ToList();
            mpm.Contact = context.Contact.OrderByDescending(c => c.MessageID).ToList();
            mpm.Clients = context.Clients.OrderByDescending(c => c.ClientID).ToList();
            mpm.Portfolio = context.Portfolio.OrderByDescending(p => p.PortfolioID).ToList();
            mpm.Newsletter = context.Newsletter.OrderByDescending(n => n.MailID).ToList();
            return View(mpm);
        }
        public IActionResult Index2()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SettingEdit()
        {
            List<Settings> settings = new List<Settings>();
            return View(settings);
        }
        [HttpPost]
        public IActionResult SettingEdit(int id)
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PortfolioAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PortfolioAdd(Portfolio portfolio, IFormFile photo)
        {
            string portfolioPhotoFolder = Path.Combine(_webHost.WebRootPath, "imgs/portfolio");
            string fileName = Path.GetFileName(photo.FileName);
            string filesavePath = Path.Combine(portfolioPhotoFolder, fileName);
            using (FileStream stream = new FileStream(filesavePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }
            portfolio.Photo = fileName;
            portfolio.Date = DateTime.Now.ToString("dd,MMMM,yyyy");
            bool answer = cls_Portfolio.InsertPortfolio(portfolio);
            if (answer == true)
            {
                TempData["Message"] = portfolio.PortfolioName + "Eklendi";
            }
            else
            {
                TempData["Message"] = "Hata";
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> PortfolioEdit(int id)
        {
            var portfolio = context.Portfolio.FirstOrDefault(p => p.PortfolioID == id);
            return View(portfolio);
        }
        [HttpPost]
        public async Task<IActionResult> PortfolioEdit(Portfolio portfolio, IFormFile Photo)
        {


            var photopath = context.Portfolio.Where(p => p.PortfolioID == portfolio.PortfolioID).SingleOrDefault().Photo;
            if (Photo != null)
            {
                System.IO.File.Delete("wwwroot/imgs/portfolio/" + photopath);
                string portfolioPhotoFolder = Path.Combine(_webHost.WebRootPath, "imgs/portfolio");
                string fileName = Path.GetFileName(Photo.FileName);
                string filesavePath = Path.Combine(portfolioPhotoFolder, fileName);
                using (FileStream stream = new FileStream(filesavePath, FileMode.Create))
                {
                    await Photo.CopyToAsync(stream);
                }
                portfolio.Photo = fileName;

            }
            else
            {
                Portfolio prt = context.Portfolio.FirstOrDefault(p => p.PortfolioID == portfolio.PortfolioID);
                portfolio.Photo = prt.Photo;
            }


            portfolio.Date = context.Portfolio.Where(p => p.PortfolioID == portfolio.PortfolioID).SingleOrDefault().Date;
            bool answer = cls_Portfolio.UpdatePortfolio(portfolio);
            if (answer == true)
            {
                TempData["Message"] = portfolio.PortfolioName + " Güncellendi";
            }
            else
            {
                TempData["Message"] = "Hata";
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> PortfolioDelete(int? id)
        {
            if (id == null || context.Portfolio == null)
            {
                return NotFound();
            }
            var portfolio = await context.Portfolio.FirstOrDefaultAsync(c => c.PortfolioID == id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View(portfolio);
        }
        //bu metod yazımına rooting denir. güvenlik için kullanılır.
        [HttpPost, ActionName("PortfolioDelete")]
        public async Task<IActionResult> PortfolioDelete(int id)
        {

            bool answer = cls_Portfolio.DeletePortfolio(id);
            if (answer == true)
            {
                TempData["Message"] = "Silindi";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Message"] = "HATA";
                return RedirectToAction(nameof(Index));
            }

        }

    }
}
