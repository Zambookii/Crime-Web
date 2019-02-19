#pragma checksum "/home/codio/workspace/crimes/Views/CrimeCodes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "149d726be8b92ef023664bc1077bfccffb21b74e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(crimes.Pages.Views_CrimeCodes), @"mvc.1.0.razor-page", @"/Views/CrimeCodes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Views/CrimeCodes.cshtml", typeof(crimes.Pages.Views_CrimeCodes), null)]
namespace crimes.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/home/codio/workspace/crimes/Views/_ViewImports.cshtml"
using crimes;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"149d726be8b92ef023664bc1077bfccffb21b74e", @"/Views/CrimeCodes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f842f8255da31aa43ed40deaf7f18adbc89934f4", @"/Views/_ViewImports.cshtml")]
    public class Views_CrimeCodes : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/home/codio/workspace/crimes/Views/CrimeCodes.cshtml"
  
  ViewData["Title"] = "All Crime Codes";

#line default
#line hidden
            BeginContext(75, 29, true);
            WriteLiteral("\n<h2>All Crime Codes</h2>  \n\n");
            EndContext();
#line 9 "/home/codio/workspace/crimes/Views/CrimeCodes.cshtml"
  
   if (@Model.EX != null)
	 {

#line default
#line hidden
            BeginContext(137, 37, true);
            WriteLiteral("\t   <br />\n\t\t <br />\n\t\t <h3>**ERROR: ");
            EndContext();
            BeginContext(175, 16, false);
#line 14 "/home/codio/workspace/crimes/Views/CrimeCodes.cshtml"
                 Write(Model.EX.Message);

#line default
#line hidden
            EndContext();
            BeginContext(191, 46, true);
            WriteLiteral("</h3>\n\t\t <br />\n\t\t <hr />\n\t\t <br />\n\t\t <br />\n");
            EndContext();
#line 19 "/home/codio/workspace/crimes/Views/CrimeCodes.cshtml"
	 }

#line default
#line hidden
            BeginContext(243, 304, true);
            WriteLiteral(@"
<table class=""table"">  
    <thead>  
        <tr>  
            <th>  
                PrimaryDesc
            </th>  
            <th>  
                SecondaryDesc
            </th>  
            <th>  
                PercentTotal 
            </th>  
        </tr>  
    </thead>  
    <tbody>  
");
            EndContext();
#line 37 "/home/codio/workspace/crimes/Views/CrimeCodes.cshtml"
                  
				   int rank = 1;
				 

#line default
#line hidden
            BeginContext(582, 5, true);
            WriteLiteral("\t\t\t\t\n");
            EndContext();
#line 41 "/home/codio/workspace/crimes/Views/CrimeCodes.cshtml"
         foreach (var item in Model.CrimeList)  
        {  

#line default
#line hidden
            BeginContext(648, 76, true);
            WriteLiteral("            <tr>  \n             \n                <td>  \n                    ");
            EndContext();
            BeginContext(725, 16, false);
#line 46 "/home/codio/workspace/crimes/Views/CrimeCodes.cshtml"
               Write(item.PrimaryDesc);

#line default
#line hidden
            EndContext();
            BeginContext(741, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(810, 18, false);
#line 49 "/home/codio/workspace/crimes/Views/CrimeCodes.cshtml"
               Write(item.SecondaryDesc);

#line default
#line hidden
            EndContext();
            BeginContext(828, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(897, 17, false);
#line 52 "/home/codio/workspace/crimes/Views/CrimeCodes.cshtml"
               Write(item.PercentTotal);

#line default
#line hidden
            EndContext();
            BeginContext(914, 46, true);
            WriteLiteral("\n                </td>   \n            </tr>  \n");
            EndContext();
#line 55 "/home/codio/workspace/crimes/Views/CrimeCodes.cshtml"
						
						rank++;
        }  

#line default
#line hidden
            BeginContext(993, 24, true);
            WriteLiteral("    </tbody>  \n</table> ");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CrimeCodesModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CrimeCodesModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CrimeCodesModel>)PageContext?.ViewData;
        public CrimeCodesModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
