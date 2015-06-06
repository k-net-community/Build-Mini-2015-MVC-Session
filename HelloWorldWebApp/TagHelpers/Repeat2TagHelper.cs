using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.TagHelpers
{
    public class Repeat2TagHelper : TagHelper
    {
        public int Count { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (Count <= 0)
                return;

            for (int i = 0; i < Count; i++)
            {
                var content = await context.GetChildContentAsync();
                output.Content.Append(content);
            }
        }
    }
}
