using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace WebPL.Models
{
    public class TransferModel : OperationModel
    {
        [Required]
        [Display(Name = "To account")]
        public string ToAccountNo { get; set; }

        public IEnumerable<string> TransferAccounts { get; set; }

        public IEnumerable<SelectListItem> Accounts
        {
            get
            {
                return TransferAccounts.Select(acc => new SelectListItem
                {
                    Value = acc,
                    Text = acc
                });
            }
        }
    }
}