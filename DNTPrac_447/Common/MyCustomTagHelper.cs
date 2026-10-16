using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DNTPrac_447.Common
{

    public class MyCustomTagHelper : TagHelper
    {
        public string str { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.SetHtmlContent("<div class='alert alert-primary'>");
            output.Content.SetHtmlContent(str);
            output.PostContent.SetHtmlContent("<div>");
        }
    }
}
