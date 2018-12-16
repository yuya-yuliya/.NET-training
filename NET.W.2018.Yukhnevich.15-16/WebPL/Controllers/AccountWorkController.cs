using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPL.Models;

namespace WebPL.Controllers
{
    public class AccountWorkController : Controller
    {
        private IAccountService _service;

        public AccountWorkController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Index(string id)
        {
            return View(_service.GetAccount(id));
        }

        [HttpPost]
        public ActionResult AccountAction(string id, string action)
        {
            Dictionary<string, ActionResult> dict = new Dictionary<string, ActionResult>()
            {
                ["Deposit"] = View("Deposit", new OperationModel() { FromAccountNo = id }),
                ["Withdraw"] = View("Withdraw", new OperationModel() { FromAccountNo = id })
            };
            try
            {
                if (action == "Transfer")
                {
                    return View("Transfer", new TransferModel()
                    {
                        FromAccountNo = id,
                        TransferAccounts = _service.GetAllAccounts().Where(acc => acc.AccountNumber != id).Select(acc => acc.AccountNumber)
                    });
                }
                return dict[action];
            }
            catch (Exception)
            {
                return View("Index", _service.GetAccount(id));
            }
        }

        [HttpPost]
        public ActionResult Close(string id)
        {
            try
            {
                _service.CloseAccount(id);
                TempData["IsSuccess"] = true;
                TempData["AlertMessage"] = "The account successfully closed";
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }
            catch (Exception ex)
            {
                TempData["IsSuccess"] = false;
                TempData["Alert"] = "Fail";
                TempData["AlertMessage"] = ex.Message;
                return RedirectToRoute(new
                {
                    controller = "AccountWork",
                    action = "Index",
                    id
                });
            }
        }

        [HttpPost]
        public ActionResult Deposit(OperationModel operation)
        {
            try
            {
                _service.DepositAccount(operation.FromAccountNo, operation.Amount);
                TempData["Alert"] = "Success";
                TempData["AlertMessage"] = "Deposit on account was successful";
                TempData["IsSuccess"] = true;
            }
            catch (Exception ex)
            {
                TempData["IsSuccess"] = false;
                TempData["Alert"] = "Fail";
                TempData["AlertMessage"] = ex.Message;
            }
            return RedirectToRoute(new
            {
                controller = "AccountWork",
                action = "Index",
                id = operation.FromAccountNo
            });
        }

        [HttpPost]
        public ActionResult Withdraw(OperationModel operation)
        {
            try
            {
                _service.WithdrawAccount(operation.FromAccountNo, operation.Amount);
                TempData["Alert"] = "Success";
                TempData["AlertMessage"] = "Withdraw from account was successful";
                TempData["IsSuccess"] = true;
            }
            catch (Exception ex)
            {
                TempData["IsSuccess"] = false;
                TempData["Alert"] = "Fail";
                TempData["AlertMessage"] = ex.Message;
            }
            return RedirectToRoute(new
            {
                controller = "AccountWork",
                action = "Index",
                id = operation.FromAccountNo
            });
        }

        [HttpPost]
        public ActionResult Transfer(TransferModel model)
        {
            try
            {
                _service.Transfer(model.FromAccountNo, model.ToAccountNo, model.Amount);
                TempData["Alert"] = "Success";
                TempData["AlertMessage"] = "Transfer was successful";
                TempData["IsSuccess"] = true;
            }
            catch (Exception ex)
            {
                TempData["IsSuccess"] = false;
                TempData["Alert"] = "Fail";
                TempData["AlertMessage"] = ex.Message;
            }
            return RedirectToRoute(new
            {
                controller = "AccountWork",
                action = "Index",
                id = model.FromAccountNo
            });
        }
    }
}