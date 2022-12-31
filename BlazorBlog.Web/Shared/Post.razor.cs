using System.Net.Http.Json;
using BootstrapBlazor.Components;
using Console = System.Console;

namespace BlazorBlog.Web.Shared;

using BlazorBlog.Shared.Render;
using Microsoft.AspNetCore.Components;

public partial class Post : ComponentBase
{
    private RenderFragment Body { get; set; }
    private ComponentRenderItem? ComponentRenderTree { get; set; }

    [Inject] public HttpClient HttpClient { get; set; }

    private RenderFragment CreatePost(ComponentRenderItem renderItem) => builder =>
    {
        if (renderItem.RenderElement.Element == "ImageTest")
        {
            builder.OpenComponent(renderItem.RenderElement.SequenceId, typeof(ImageTest));
        }
        else
        {
            builder.OpenElement(renderItem.RenderElement.SequenceId, renderItem.RenderElement.Element);
        }

        // NOTE the result here shows that the string-object key map is not valid, it requires cast
        // just switch back to Dictionary and use AddAttribute
        if (renderItem.RenderElement.Element == "ImageTest")
        {
            builder.AddAttribute(renderItem.RenderAttributes.SequenceId, "Url", "https://www.blazor.zone/_content/BootstrapBlazor.Shared/images/bird.jpeg");
            builder.AddAttribute(renderItem.RenderAttributes.SequenceId+1, "Alt", "aaaaaaaaa");
        }
        else
        {
            if (renderItem.RenderAttributes != null)
            {
                builder.AddMultipleAttributes(renderItem.RenderAttributes.SequenceId,
                    renderItem.RenderAttributes.Attributes);
            }
        }


        if (renderItem.RenderMarkupContent != null)
        {
            builder.AddMarkupContent(renderItem.RenderMarkupContent.SequenceId,
                renderItem.RenderMarkupContent.MarkupContent);
        }

        if (renderItem.ContentItems.Count != 0)
        {
            foreach (var contentItem in renderItem.ContentItems)
            {
                var contentRenderFragment = CreatePost(contentItem);
                builder.AddContent(contentItem.RenderElement.SequenceId, contentRenderFragment);
            }
        }

        if (renderItem.RenderElement.Element == "ImageTest")
        {
            builder.CloseComponent();
        }
        else
        {
            builder.CloseElement();
        }

        // self defined component
        // builder.OpenComponent(3, typeof(TestComponent));
        // builder.AddAttribute(4, "Msg", "hhhh");
        // builder.CloseComponent();
    };

    //parse-markdown-to-dom?markdownFilePath=E%3A%5CCode%5CC%23%5CTool%5CBlazorBlog%5CBlazorBlog.Server%5Cassets%5Chello.md
    private async Task RenderComponent()
    {
        var mdFilePath = @"E:\Code\C#\Tool\BlazorBlog\BlazorBlog.Server\assets\hello.md";
        var uri = System.Web.HttpUtility.UrlEncode(mdFilePath);
        var renderItem =
            await HttpClient.GetFromJsonAsync<ComponentRenderItem>($"parse-markdown-to-dom?markdownFilePath={uri}");
        Console.WriteLine("Initial Render Tree Successfully");

        Body = CreatePost(renderItem);
    }
}