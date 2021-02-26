#pragma checksum "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\Components\TcpActiveConnections.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a92ad238f2a647998e6fffb769ad8c8ca848fa7"
// <auto-generated/>
#pragma warning disable 1591
namespace Simple.Diagnostics.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\_Imports.razor"
using Simple.Diagnostics;

#line default
#line hidden
#nullable disable
    public partial class TcpActiveConnections : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "a");
            __builder.AddAttribute(1, "class", "card-link");
            __builder.AddAttribute(2, "data-toggle", "collapse");
            __builder.AddAttribute(3, "href", "#collapseTwo");
            __builder.OpenElement(4, "h5");
            __builder.AddContent(5, 
#nullable restore
#line 37 "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\Components\TcpActiveConnections.razor"
         Title

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(6, " ");
            __builder.AddContent(7, 
#nullable restore
#line 37 "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\Components\TcpActiveConnections.razor"
                Monitor.ActiveConnections

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n\r\n");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "id", "collapseTwo");
            __builder.AddAttribute(11, "class", "collapse show");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "container");
            __builder.AddAttribute(14, "style", "max-height:600px;overflow-y:auto");
            __builder.OpenElement(15, "table");
            __builder.AddAttribute(16, "class", "table table-bordered table-hover table-sm");
            __builder.AddMarkupContent(17, @"<thead class=""thead-dark""><tr class=""text-center""><th class=""border"">Index</th>
                    <th class=""border"">Last Updated</th>
                    <th class=""border"">Local Port</th>
                    <th class=""border"">Remote Port</th>
                    <th class=""border"">State</th></tr></thead>
            ");
            __builder.OpenElement(18, "tbody");
#nullable restore
#line 53 "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\Components\TcpActiveConnections.razor"
                 foreach (var item in Monitor.GetActiveConnections())
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(19, "tr");
            __builder.OpenElement(20, "td");
            __builder.AddAttribute(21, "class", "text-center border");
            __builder.AddContent(22, 
#nullable restore
#line 56 "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\Components\TcpActiveConnections.razor"
                                                        item.Index

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n                        ");
            __builder.OpenElement(24, "td");
            __builder.AddAttribute(25, "class", "text-center border");
            __builder.AddContent(26, 
#nullable restore
#line 57 "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\Components\TcpActiveConnections.razor"
                                                        item.LastUpdated.ToString("MM/dd/yyyy HH:mm:ss")

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n                        ");
            __builder.OpenElement(28, "td");
            __builder.AddAttribute(29, "class", "text-center border");
            __builder.AddContent(30, 
#nullable restore
#line 58 "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\Components\TcpActiveConnections.razor"
                                                        item.LocalPort

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n                        ");
            __builder.OpenElement(32, "td");
            __builder.AddAttribute(33, "class", "text-center border");
            __builder.AddContent(34, 
#nullable restore
#line 59 "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\Components\TcpActiveConnections.razor"
                                                        item.RemotePort

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n                        ");
            __builder.OpenElement(36, "td");
            __builder.AddAttribute(37, "class", "text-center border");
            __builder.AddContent(38, 
#nullable restore
#line 60 "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\Components\TcpActiveConnections.razor"
                                                        item.State

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 62 "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\Components\TcpActiveConnections.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 3 "L:\VisualStudio\source\repos\firemanwayne\Diagnostics\src\Simple.Diagnostics\Components\TcpActiveConnections.razor"
       

    [Parameter] public string Title { get; set; }

    [Inject] ITcpMonitor Monitor { get; set; }

    protected override void OnInitialized()
    {
        try
        {
            Monitor.OnConnectionAdded += (o, a) => { InvokeAsync(() => StateHasChanged()); };
            Monitor.OnConnectionUpdated += (o, a) => { InvokeAsync(() => StateHasChanged()); };
            Monitor.OnConnectionRemoved += (o, a) => { InvokeAsync(() => StateHasChanged()); };            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }


    public void Dispose()
    {
        if (Monitor != null)
        {
            Monitor.OnConnectionAdded -= (o, a) => { };
            Monitor.OnConnectionUpdated -= (o, a) => { };
            Monitor.OnConnectionRemoved -= (o, a) => { };
        }
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591