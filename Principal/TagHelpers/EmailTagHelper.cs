using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Principal.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string EmailDomain { get; set; } = "nter.com";
        public string Name { get; set; } = "";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            // Replaces <email> with <a> tag

            var address = Name.ToLower() + "@" + EmailDomain.ToLower();
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent(address);
        }
    }
}
