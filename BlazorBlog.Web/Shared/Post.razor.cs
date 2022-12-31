namespace BlazorBlog.Web.Shared;

using BlazorBlog.Shared.Render;
using Microsoft.AspNetCore.Components;

public partial class Post : ComponentBase {
    private RenderFragment Body { get; set; }

    protected RenderFragment CreatePost(ComponentRenderItem renderItem) => builder => {
        builder.OpenElement(renderItem.RenderElement.SequenceId, renderItem.RenderElement.Element);
        if (renderItem.RenderAttributes != null)
        {
            builder.AddMultipleAttributes(renderItem.RenderAttributes.SequenceId, renderItem.RenderAttributes.Attributes);
        }
        if (renderItem.RenderMarkupContent != null)
        {
            builder.AddMarkupContent(renderItem.RenderMarkupContent.SequenceId, renderItem.RenderMarkupContent.MarkupContent);
        }
        builder.CloseComponent();
    };

    private void RenderComponent() {
        var renderItem = new ComponentRenderItem
        {
            RenderElement = new RenderElement
            {
                SequenceId = 0,
                Element = "h2"
            },
            RenderAttributes = new RenderAttributes
            {
                SequenceId = 1,
                Attributes = new[]
                {
                    new KeyValuePair<string, object>("class", "test-1"),
                    new KeyValuePair<string, object>("id", "test-2")
                }
            },
            RenderMarkupContent = new RenderMarkupContent
            {
                SequenceId = 2,
                MarkupContent = "I have a dream today"
            }
        };
        Body = CreatePost(renderItem);
    }

}
