using BlazorBlog.Shared.Render;

namespace BlazorBlog.Server.Service;

public interface IRenderItemService
{
    public Task<ComponentRenderItem> ParseMarkdown(string markdown);
    public string ParseMarkdownToHtml(string markdown);
}