#pragma checksum "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b42f32f5d677a2a46feb404ee9f7bbd7d0510b07"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__BookTabSliderPartial), @"mvc.1.0.view", @"/Views/Shared/_BookTabSliderPartial.cshtml")]
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
#line 1 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\_ViewImports.cshtml"
using Pustok;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\_ViewImports.cshtml"
using Pustok.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\_ViewImports.cshtml"
using Pustok.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b42f32f5d677a2a46feb404ee9f7bbd7d0510b07", @"/Views/Shared/_BookTabSliderPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8d2ec98bcfff3ea842b43546fdef4a1a134b952", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__BookTabSliderPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Book>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "getBookDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("single-btn show-detail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""product-slider multiple-row  slider-border-multiple-row  sb-slick-slider""
     data-slick-setting='{
                            ""autoplay"": true,
                            ""autoplaySpeed"": 8000,
                            ""slidesToShow"": 5,
                            ""rows"":1,
                            ""dots"":true
                        }' data-slick-responsive='[
                            {""breakpoint"":1200, ""settings"": {""slidesToShow"": 3} },
                            {""breakpoint"":768, ""settings"": {""slidesToShow"": 2} },
                            {""breakpoint"":480, ""settings"": {""slidesToShow"": 1} },
                            {""breakpoint"":320, ""settings"": {""slidesToShow"": 1} }
                        ]'>
");
#nullable restore
#line 15 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"single-slide\">\r\n            <div class=\"product-card\">\r\n                <div class=\"product-header\">\r\n                    <a href=\"#\" class=\"author\">\r\n                        ");
#nullable restore
#line 21 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
                   Write(item.Author.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </a>\r\n                    <h3>\r\n                        <a href=\"product-details.html\">\r\n                            ");
#nullable restore
#line 25 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </a>\r\n                    </h3>\r\n                </div>\r\n                <div class=\"product-card--body\">\r\n                    <div class=\"card-image\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b42f32f5d677a2a46feb404ee9f7bbd7d0510b077299", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1394, "~/uploads/books/", 1394, 16, true);
#nullable restore
#line 31 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
AddHtmlAttributeValue("", 1410, item.BookImages.FirstOrDefault(x=>x.PosterStatus==true)?.Name, 1410, 62, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <div class=\"hover-contents\">\r\n                            <a href=\"product-details.html\" class=\"hover-image\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b42f32f5d677a2a46feb404ee9f7bbd7d0510b079117", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1660, "~/uploads/books/", 1660, 16, true);
#nullable restore
#line 34 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
AddHtmlAttributeValue("", 1676, item.BookImages.FirstOrDefault(x=>x.PosterStatus==false)?.Name, 1676, 63, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </a>
                            <div class=""hover-btns"">
                                <a href=""cart.html"" class=""single-btn"">
                                    <i class=""fas fa-shopping-basket""></i>
                                </a>
                                <a href=""wishlist.html"" class=""single-btn"">
                                    <i class=""fas fa-heart""></i>
                                </a>
                                <a href=""compare.html"" class=""single-btn"">
                                    <i class=""fas fa-random""></i>
                                </a>
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b42f32f5d677a2a46feb404ee9f7bbd7d0510b0711447", async() => {
                WriteLiteral("\r\n                                    <i class=\"fas fa-eye\"></i>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
                                                                                      WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"price-block\">\r\n");
#nullable restore
#line 54 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
                         if (item.DiscountPercent > 0)
                        {
                            double discountedPrice = item.SalePrice * (100 - item.DiscountPercent) / 100;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"price\">£");
#nullable restore
#line 57 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
                                            Write(discountedPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            <del class=\"price-old\">£");
#nullable restore
#line 58 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
                                               Write(item.SalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</del>\r\n                            <span class=\"price-discount\">");
#nullable restore
#line 59 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
                                                    Write(item.DiscountPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n");
#nullable restore
#line 60 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"price\">£");
#nullable restore
#line 63 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
                                            Write(item.SalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 64 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 69 "C:\Users\Yusifiz\Desktop\AspPustok\ASP-PustokSite\Pustok\Views\Shared\_BookTabSliderPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Book>> Html { get; private set; }
    }
}
#pragma warning restore 1591
