#pragma checksum "C:\Users\Maikel\source\repos\ClienteWebGym\ClienteWebGym\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01f18afe0ed47e15e81ecf391100ec5769eaefb7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Maikel\source\repos\ClienteWebGym\ClienteWebGym\Views\_ViewImports.cshtml"
using ClienteWebGym;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Maikel\source\repos\ClienteWebGym\ClienteWebGym\Views\_ViewImports.cshtml"
using ClienteWebGym.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01f18afe0ed47e15e81ecf391100ec5769eaefb7", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5056b182a70ff3a2a82c77dd356fa3e2eb197a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Maikel\source\repos\ClienteWebGym\ClienteWebGym\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>
</div>

<div class=""container"">
    <nav class=""navbar navbar-inverse navbar-expand-lg"">
        <div class=""container-fluid"">
            <div class=""navbar-header"">
                <a class=""navbar-brand"" href=""#"">WebSiteName</a>
            </div>

            <ul class=""nav navbar-nav navbar-right"">
                <li><a href=""#""><span class=""glyphicon glyphicon-user""></span> Sign Up</a></li>
                <li><a href=""#""><span class=""glyphicon glyphicon-log-in""></span> Login</a></li>
            </ul>
        </div>
    </nav>

    <div class=""container"">
        <div class=""jumbotron"" style='background-image:url(""/img/TatuajeOnePiece.PNG"")'>
            
            <h1> E-Wellness</h1><br />
            <p>
                Da un mejor servicio a tus clientes
                de una manera sencilla
");
            WriteLiteral(@"            </p>

            <div class=""input-group"">

                <div class=""input-group-btn"">
                    <button type=""button"" class=""btn btn-danger"">Registrar</button>
                </div>
            </div>
        </div>

    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
