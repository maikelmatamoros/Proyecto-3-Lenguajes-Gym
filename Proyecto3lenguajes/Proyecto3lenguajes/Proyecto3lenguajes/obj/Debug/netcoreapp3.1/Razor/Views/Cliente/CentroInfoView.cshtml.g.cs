#pragma checksum "C:\Users\Maikel\Downloads\Proyecto3lenguajes\Proyecto3lenguajes\Proyecto3lenguajes\Views\Cliente\CentroInfoView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1ed116da92e66d286ecce9aac430bfc9deb61f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cliente_CentroInfoView), @"mvc.1.0.view", @"/Views/Cliente/CentroInfoView.cshtml")]
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
#line 1 "C:\Users\Maikel\Downloads\Proyecto3lenguajes\Proyecto3lenguajes\Proyecto3lenguajes\Views\_ViewImports.cshtml"
using Proyecto3lenguajes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Maikel\Downloads\Proyecto3lenguajes\Proyecto3lenguajes\Proyecto3lenguajes\Views\_ViewImports.cshtml"
using Proyecto3lenguajes.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1ed116da92e66d286ecce9aac430bfc9deb61f8", @"/Views/Cliente/CentroInfoView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6ab45ed3730143a90e7362e0aaec648ddf194b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Cliente_CentroInfoView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/CentroInfo.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Maikel\Downloads\Proyecto3lenguajes\Proyecto3lenguajes\Proyecto3lenguajes\Views\Cliente\CentroInfoView.cshtml"
  
    ViewData["Title"] = "CentroInfoView";
    Layout = "_LayoutUsuario";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-12"">
        <h1 class=""col-md-12"">Información de Centro de Entrenamiento</h1>
    </div>
</div>


<div class=""row"">
    <div class=""col-md-5"" style=""background-color: rgba(10, 129, 16,0.4) !important; border-radius: 20px;"">
        <h5 class=""col-md-12"" id=""nombre""></h5>
        <h5 class=""col-md-12"" id=""descripcion""></h5>
        <h5 class=""col-md-12"" id=""ubicacion""></h5>
        <div class=""col-md-12"" id=""logo""></div>

    </div>

    <div class=""col-md-8 col-sm-8 center-block"" id=""img"">
        
        
    </div>
</div>
<div class=""row"">
    <div class=""col-12"">
        <h2 style=""margin-left:auto;margin-right:auto;color:white;"">Lista de clases futuras</h2>
    </div>
    <div class=""container col-12"">
        <div class=""table-responsive"">
            <table id=""ClasesVirtualesTable"" class=""table table-bordered"">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Fecha</t");
            WriteLiteral(@"h>
                        <th>Horario</th>
                        <th>Nombre</th>
                        <th>Descripción</th>
                        <th>Transmision</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>
</div>


");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b1ed116da92e66d286ecce9aac430bfc9deb61f85461", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 55 "C:\Users\Maikel\Downloads\Proyecto3lenguajes\Proyecto3lenguajes\Proyecto3lenguajes\Views\Cliente\CentroInfoView.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
