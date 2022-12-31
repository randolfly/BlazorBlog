using AngleSharp;
using AngleSharp.Dom;
using Markdig;
using BlazorBlog.Shared.Render;
using CollectionExtensions = AngleSharp.Dom.CollectionExtensions;

namespace BlazorBlog.Server.Service;

public class RenderItemService : IRenderItemService
{
    /// <summary>
    /// Convert a markdown file to a <code>ComponentRenderItem</code>
    /// </summary>
    /// <param name="markdown"></param>
    /// <returns></returns>
    public async Task<ComponentRenderItem> ParseMarkdown(string markdown)
    {
        // convert markdown to html
        var html = ParseMarkdownToHtml(markdown);

        var config = Configuration.Default;
        //Create a new context for evaluating webpages with the given config
        var context = BrowsingContext.New(config);
        //Create a virtual request to specify the document to load (here from our fixed string)
        var doc = await context.OpenAsync(req => req.Content(html));

        return ParseDom(doc.Body);
    }

    public string ParseMarkdownToHtml(string markdown)
    {
        // convert markdown to html
        var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        var html = Markdown.ToHtml(markdown, pipeline);
        return html;
    }

    private ComponentRenderItem ParseDom(IElement htmlNode, int sequenceId = 0)
    {
        // attribute pairs
        List<KeyValuePair<string, object>> keyValuePairs = new();

        foreach (var attribute in htmlNode.Attributes)
        {
            keyValuePairs.Add(new KeyValuePair<string, object>(attribute.Name, attribute.Value));
        }

        // text content
        var hasTextContent = htmlNode.GetNodes<INode>(false)
            .Any(node => node.NodeName == "#text" && node.TextContent != "\n");
        var markupContent = hasTextContent ? htmlNode.TextContent : null;

        var componentNode = new ComponentRenderItem
        {
            RenderElement = new RenderElement(sequenceId++, htmlNode.NodeName.ToLower()),
            RenderMarkupContent = new RenderMarkupContent(sequenceId++, markupContent),
            RenderAttributes = new RenderAttributes(sequenceId++, keyValuePairs)
        };
        
        // test self-define rule
        // NOTE the html parer doesn't recognize the button node, so need to add self-defined rules in parser
        if (htmlNode.NodeName.ToLower() == "button")
        {
            componentNode.RenderElement.Element = "Button";
        }

        if (htmlNode.NodeName.ToLower() == "img")
        {
            componentNode.RenderElement.Element = "ImageTest";
            componentNode.RenderAttributes.Attributes = new List<KeyValuePair<string, object>>
            {
                new("Url", "https://www.blazor.zone/_content/BootstrapBlazor.Shared/images/bird.jpeg")
            };
            // Url="_content/BootstrapBlazor.Shared/images/bird.jpeg" FitMode="ObjectFitMode.Fill"
        }

        foreach (var childElement in htmlNode.Children)
        {
            var childComponentItem = ParseDom(childElement);
            componentNode.ContentItems.Add(childComponentItem);
        }

        return componentNode;
    }
}