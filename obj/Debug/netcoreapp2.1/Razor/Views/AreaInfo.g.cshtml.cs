#pragma checksum "/home/codio/workspace/crimes/Views/AreaInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e417350dbe695da012ec1ab9b41e448a86b6c2be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(crimes.Pages.Views_AreaInfo), @"mvc.1.0.razor-page", @"/Views/AreaInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Views/AreaInfo.cshtml", typeof(crimes.Pages.Views_AreaInfo), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e417350dbe695da012ec1ab9b41e448a86b6c2be", @"/Views/AreaInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f842f8255da31aa43ed40deaf7f18adbc89934f4", @"/Views/_ViewImports.cshtml")]
    public class Views_AreaInfo : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/home/codio/workspace/crimes/Views/AreaInfo.cshtml"
  
  ViewData["Title"] = "All Area Information";

#line default
#line hidden
            BeginContext(78, 34, true);
            WriteLiteral("\n<h2>All Area Information</h2>  \n\n");
            EndContext();
#line 9 "/home/codio/workspace/crimes/Views/AreaInfo.cshtml"
  
   if (@Model.EX != null)
	 {

#line default
#line hidden
            BeginContext(145, 37, true);
            WriteLiteral("\t   <br />\n\t\t <br />\n\t\t <h3>**ERROR: ");
            EndContext();
            BeginContext(183, 16, false);
#line 14 "/home/codio/workspace/crimes/Views/AreaInfo.cshtml"
                 Write(Model.EX.Message);

#line default
#line hidden
            EndContext();
            BeginContext(199, 46, true);
            WriteLiteral("</h3>\n\t\t <br />\n\t\t <hr />\n\t\t <br />\n\t\t <br />\n");
            EndContext();
#line 19 "/home/codio/workspace/crimes/Views/AreaInfo.cshtml"
	 }

#line default
#line hidden
            BeginContext(251, 358, true);
            WriteLiteral(@"
<table class=""table"">  
    <thead>  
        <tr>  
            <th>  
                Area
            </th>  
            <th>  
                AreaName
            </th>  
            <th>  
                NumOccured 
            </th>  
            <th>  
                PercentTotal 
            </th> 
        </tr>  
    </thead>  
    <tbody>  
");
            EndContext();
#line 40 "/home/codio/workspace/crimes/Views/AreaInfo.cshtml"
                  
				   int rank = 1;
				 

#line default
#line hidden
            BeginContext(644, 5, true);
            WriteLiteral("\t\t\t\t\n");
            EndContext();
#line 44 "/home/codio/workspace/crimes/Views/AreaInfo.cshtml"
         foreach (var item in Model.CrimeList)  
        {  

#line default
#line hidden
            BeginContext(710, 76, true);
            WriteLiteral("            <tr>  \n             \n                <td>  \n                    ");
            EndContext();
            BeginContext(787, 9, false);
#line 49 "/home/codio/workspace/crimes/Views/AreaInfo.cshtml"
               Write(item.Area);

#line default
#line hidden
            EndContext();
            BeginContext(796, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(865, 13, false);
#line 52 "/home/codio/workspace/crimes/Views/AreaInfo.cshtml"
               Write(item.AreaName);

#line default
#line hidden
            EndContext();
            BeginContext(878, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(947, 15, false);
#line 55 "/home/codio/workspace/crimes/Views/AreaInfo.cshtml"
               Write(item.NumOccured);

#line default
#line hidden
            EndContext();
            BeginContext(962, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1031, 17, false);
#line 58 "/home/codio/workspace/crimes/Views/AreaInfo.cshtml"
               Write(item.PercentTotal);

#line default
#line hidden
            EndContext();
            BeginContext(1048, 45, true);
            WriteLiteral("\n                </td>  \n            </tr>  \n");
            EndContext();
#line 61 "/home/codio/workspace/crimes/Views/AreaInfo.cshtml"
						
						rank++;
        }  

#line default
#line hidden
            BeginContext(1126, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AreaInfoModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AreaInfoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AreaInfoModel>)PageContext?.ViewData;
        public AreaInfoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
