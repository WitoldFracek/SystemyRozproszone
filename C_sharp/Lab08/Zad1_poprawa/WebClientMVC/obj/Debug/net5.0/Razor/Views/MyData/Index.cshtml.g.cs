#pragma checksum "D:\HDD\Studia\Systemy Rozproszone\SystemyRozproszone\C_sharp\Lab08\Zad1_poprawa\WebClientMVC\Views\MyData\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4e9cecf1029c5e568b37d5986a6a00018fc4bcd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MyData_Index), @"mvc.1.0.view", @"/Views/MyData/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\HDD\Studia\Systemy Rozproszone\SystemyRozproszone\C_sharp\Lab08\Zad1_poprawa\WebClientMVC\Views\_ViewImports.cshtml"
using WebClientMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\HDD\Studia\Systemy Rozproszone\SystemyRozproszone\C_sharp\Lab08\Zad1_poprawa\WebClientMVC\Views\_ViewImports.cshtml"
using WebClientMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4e9cecf1029c5e568b37d5986a6a00018fc4bcd", @"/Views/MyData/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a61a7f4266fdd88e2042afbcbedf6e2272218ef6", @"/Views/_ViewImports.cshtml")]
    public class Views_MyData_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InfoPresenter.MyData>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\HDD\Studia\Systemy Rozproszone\SystemyRozproszone\C_sharp\Lab08\Zad1_poprawa\WebClientMVC\Views\MyData\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>My data</h1>\r\n<h2>");
#nullable restore
#line 8 "D:\HDD\Studia\Systemy Rozproszone\SystemyRozproszone\C_sharp\Lab08\Zad1_poprawa\WebClientMVC\Views\MyData\Index.cshtml"
Write(Model.ServiceData);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h2>");
#nullable restore
#line 9 "D:\HDD\Studia\Systemy Rozproszone\SystemyRozproszone\C_sharp\Lab08\Zad1_poprawa\WebClientMVC\Views\MyData\Index.cshtml"
Write(Model.LocalData);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InfoPresenter.MyData> Html { get; private set; }
    }
}
#pragma warning restore 1591
