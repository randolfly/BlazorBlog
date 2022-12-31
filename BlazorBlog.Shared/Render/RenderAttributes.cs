namespace BlazorBlog.Shared.Render; 

public class RenderAttributes : RenderBase {
    /// <summary>
    /// component attributes, eg <code>class: table</code>
    /// </summary>
    public IEnumerable<KeyValuePair<string, object>>? Attributes { get; set; }
}
