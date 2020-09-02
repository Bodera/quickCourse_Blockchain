#pragma checksum "/home/bode/Documentos/git-myRepos/quickCourse_Blockchain/functional-demo/demo-01/2nd-module/BlockChain/Views/Home/Configure.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ceb9db78331fd7137c419f0cb01f8af77e480c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Configure), @"mvc.1.0.view", @"/Views/Home/Configure.cshtml")]
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
#line 1 "/home/bode/Documentos/git-myRepos/quickCourse_Blockchain/functional-demo/demo-01/2nd-module/BlockChain/Views/_ViewImports.cshtml"
using BlockChain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/bode/Documentos/git-myRepos/quickCourse_Blockchain/functional-demo/demo-01/2nd-module/BlockChain/Views/_ViewImports.cshtml"
using BlockChain.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ceb9db78331fd7137c419f0cb01f8af77e480c7", @"/Views/Home/Configure.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f01fe8973a7ff96578a512b188a8ab2031f331b5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Configure : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Node>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("node_form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Add nodes -->
<div class=""container"">
    <div class=""row"">
        <div class=""col-lg-12"">

            <div class=""card-body"">
                <h4 class=""card-title"">Add Blockchain nodes</h4>
                <p class=""card-text"">Enter a list of Blockchain node URLs separated by comma and click on ""Add"" button to add them to the list of nodes</p>
            </div>

        </div>
    </div>
</div>

<div class=""container alert alert-secondary"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ceb9db78331fd7137c419f0cb01f8af77e480c74449", async() => {
                WriteLiteral(@"
        <div class=""row"">
            <label class=""col-sm-2"">Node URLs:</label>
            <div class=""col-sm-10"">
                <input type=""text"" name=""nodes"" id=""nodes"" rows=""2"" class=""form-control"">
            </div>
        </div>

        <br>

        <div class=""row"">
            <div class=""col-lg-12 text-center"">
                <input type=""submit"" id=""add_node_button"" class=""btn btn-primary btn-lg"" value=""Add Node"">
            </div>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 17 "/home/bode/Documentos/git-myRepos/quickCourse_Blockchain/functional-demo/demo-01/2nd-module/BlockChain/Views/Home/Configure.cshtml"
AddHtmlAttributeValue("", 536, Url.Action("RegisterNodes","Home"), 536, 35, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>

<hr>

<!-- List of nodes -->
<div class=""container"">
    <div class=""row"">

        <div class=""col-lg-12"">
            <div class=""card-body"">
                <h4 class=""card-title"">This node can retrieve Blockchain data from the following nodes:</h4>
            </div>
        </div>

        <div class=""col-lg-12"" id=""list_nodes"">
            <ul>
");
#nullable restore
#line 49 "/home/bode/Documentos/git-myRepos/quickCourse_Blockchain/functional-demo/demo-01/2nd-module/BlockChain/Views/Home/Configure.cshtml"
                 foreach(var item in Model){

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><a");
            BeginWriteAttribute("href", " href=\"", 1518, "\"", 1538, 1);
#nullable restore
#line 50 "/home/bode/Documentos/git-myRepos/quickCourse_Blockchain/functional-demo/demo-01/2nd-module/BlockChain/Views/Home/Configure.cshtml"
WriteAttributeValue("", 1525, item.Address, 1525, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 50 "/home/bode/Documentos/git-myRepos/quickCourse_Blockchain/functional-demo/demo-01/2nd-module/BlockChain/Views/Home/Configure.cshtml"
                                       Write(item.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 51 "/home/bode/Documentos/git-myRepos/quickCourse_Blockchain/functional-demo/demo-01/2nd-module/BlockChain/Views/Home/Configure.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </div>\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Node>> Html { get; private set; }
    }
}
#pragma warning restore 1591
