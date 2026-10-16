using System.ComponentModel.DataAnnotations;

namespace DNTPrac_447.Common
{
    public class CodeValidator : ValidationAttribute
    {
        public string ch {  get; set; }
        public override bool IsValid(object value)
        {
            if(value != null && Convert.ToString(value)!.StartsWith(ch))
            {
                return true;
            }
            return false;
        }
    }
}
