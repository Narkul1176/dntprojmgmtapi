using DNTPrac_447.Common;
using System.ComponentModel.DataAnnotations;

namespace DNTPrac_447.Models
{
    public class ProductViewModel
    {
        [Display(Name ="Product Id")]
        [Required]
        public int? ProductId { get; set; }
        
        [Display(Name = "Product Code")]
        [CodeValidator(ch ="p", ErrorMessage ="Product Code is not starting with 'p'")]
        [Required]
        public string ProductCode { get; set; }

        [Display(Name = "Product Name")]
        [Required]

        public string ProductName { get; set; }

        [Display(Name = "Product Price")]
        [Required]
        public int? ProductPrice { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int? CategoryId { get; set; }
    }
}
