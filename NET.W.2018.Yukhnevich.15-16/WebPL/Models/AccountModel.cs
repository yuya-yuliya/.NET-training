using BLL.Interface.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebPL.Models
{
    public class AccountModel
    {
        [Required]
        [Display(Name = "Owner name")]
        public string OwnerName { get; set; }

        [Required]
        [Display(Name = "Owner surname")]
        public string OwnerSurname { get; set; }

        [Required]
        [Display(Name = "Account type")]
        public AccountType Type { get; set; }
    }
}