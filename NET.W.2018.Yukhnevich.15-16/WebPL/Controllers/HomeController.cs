using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPL.Models;

namespace WebPL.Controllers
{
    public class HomeController : Controller
    {
        private IAccountService _service;
        private IAccountNumberCreateService _numberService;

        public HomeController(IAccountService service, IAccountNumberCreateService accountNumberService)
        {
            _service = service;
            _numberService = accountNumberService;
        }

        public ActionResult Index()
        {
            return View(_service.GetAllAccounts());
        }

        [HttpGet]
        public ActionResult Open()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Open(AccountModel account)
        {
            try
            {
                _service.OpenAccount(account.OwnerName + " " + account.OwnerSurname, account.Type, _numberService);
                TempData["IsSuccess"] = true;
                TempData["AlertMessage"] = "The account successfully opend";
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }
            catch (Exception ex)
            {
                ViewBag.Alert = "Fail";
                ViewBag.AlertMessage = ex.Message;
                return View("Open");
            }
        }
    }
}