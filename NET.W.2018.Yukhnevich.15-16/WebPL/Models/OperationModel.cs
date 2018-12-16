using System.ComponentModel.DataAnnotations;

namespace WebPL.Models
{
    public class OperationModel
    {
        [Required]
        [Display(Name = "From account")]
        public string FromAccountNo { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
    }
}