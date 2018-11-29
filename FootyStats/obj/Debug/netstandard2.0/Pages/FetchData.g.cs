#pragma checksum "/Users/stuart/dev/FootyStats/FootyStats/Pages/FetchData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0cb4476a6e418e95d6ef766b8112b6e64cc4c9eb"
// <auto-generated/>
#pragma warning disable 1591
namespace FootyStats.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Blazor;
    using Microsoft.AspNetCore.Blazor.Components;
    using System.Net.Http;
    using Microsoft.AspNetCore.Blazor.Layouts;
    using Microsoft.AspNetCore.Blazor.Routing;
    using Microsoft.JSInterop;
    using Newtonsoft.Json;
    using FootyStats;
    using FootyStats.Shared;
    [Microsoft.AspNetCore.Blazor.Layouts.LayoutAttribute(typeof(MainLayout))]

    [Microsoft.AspNetCore.Blazor.Components.RouteAttribute("/fetchdata")]
    public class FetchData : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder.AddMarkupContent(0, "<h1>Weather forecast</h1>\n\n");
            builder.AddMarkupContent(1, "<p>This component demonstrates fetching data from the server.</p>\n\n");
#line 8 "/Users/stuart/dev/FootyStats/FootyStats/Pages/FetchData.cshtml"
 if (data == null)
{

#line default
#line hidden
            builder.AddContent(2, "    ");
            builder.AddMarkupContent(3, "<p><em>Loading...</em></p>\n");
#line 11 "/Users/stuart/dev/FootyStats/FootyStats/Pages/FetchData.cshtml"
}
else
{

#line default
#line hidden
            builder.AddContent(4, "    ");
            builder.OpenElement(5, "table");
            builder.AddAttribute(6, "class", "table");
            builder.AddContent(7, "\n        ");
            builder.AddMarkupContent(8, "<thead>\n            <tr>\n                <th>Id</th>\n                <th>Country</th>\n                <th>Name</th>\n                <th>Code</th>\n                <th>Start Date</th>\n            </tr>\n        </thead>\n        ");
            builder.OpenElement(9, "tbody");
            builder.AddContent(10, "\n");
#line 25 "/Users/stuart/dev/FootyStats/FootyStats/Pages/FetchData.cshtml"
             foreach(var comp in data.Competitions)
            {

#line default
#line hidden
            builder.AddContent(11, "                ");
            builder.OpenElement(12, "tr");
            builder.AddContent(13, "\n                    ");
            builder.OpenElement(14, "td");
            builder.AddContent(15, comp.Id);
            builder.CloseElement();
            builder.AddContent(16, "\n                    ");
            builder.OpenElement(17, "td");
            builder.AddContent(18, comp.Area.Name);
            builder.CloseElement();
            builder.AddContent(19, "\n                    ");
            builder.OpenElement(20, "td");
            builder.AddContent(21, comp.Name);
            builder.CloseElement();
            builder.AddContent(22, "\n                    ");
            builder.OpenElement(23, "td");
            builder.AddContent(24, comp.Code);
            builder.CloseElement();
            builder.AddContent(25, "\n                    ");
            builder.OpenElement(26, "td");
            builder.AddContent(27, comp.CurrentSeason);
            builder.CloseElement();
            builder.AddContent(28, "\n                ");
            builder.CloseElement();
            builder.AddContent(29, "\n");
#line 34 "/Users/stuart/dev/FootyStats/FootyStats/Pages/FetchData.cshtml"
            }

#line default
#line hidden
            builder.AddContent(30, "        ");
            builder.CloseElement();
            builder.AddContent(31, "\n    ");
            builder.CloseElement();
            builder.AddContent(32, "\n");
#line 37 "/Users/stuart/dev/FootyStats/FootyStats/Pages/FetchData.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
#line 39 "/Users/stuart/dev/FootyStats/FootyStats/Pages/FetchData.cshtml"
            
    FootballData data;

    protected override async Task OnInitAsync()
    {
        Http.DefaultRequestHeaders.Add("X-Auth-Token", "8c8c0f60dd594dd1a176b5e16ddb2c0b");
        var response = await Http.GetStringAsync("http://api.football-data.org/v2/competitions");
        data = FootballData.FromJson(response);
        
        //api = await FootballDataService.GetData();
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Blazor.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
