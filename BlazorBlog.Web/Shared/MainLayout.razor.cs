using BootstrapBlazor.Components;

namespace BlazorBlog.Web.Shared;

public sealed partial class MainLayout {
    // menu items
    private List<MenuItem>? Menus { get; set; }
    private bool IsFullSide { get; set; } = false;
    private string Theme { get; set; } = "themeColor";
    protected override void OnInitialized() {
        base.OnInitialized();
        Menus = GetIconSideMenuItems();
    }

    private static List<MenuItem> GetIconSideMenuItems() {
        var menus = new List<MenuItem>
        {
            new MenuItem
            {
                Icon = "fa-solid fa-gear",
                Url = "/test",
                Text = "test",
                Items = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/test",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/test",
                        Text = "test",
                    }
                }
            },
            new MenuItem
            {
                Icon = "fa-solid fa-gear",
                Url = "/hello-blog",
                Text = "test",
                Items = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/hello-blog",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/hello-blog",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/test",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/test",
                        Text = "test",
                    }
                }
            },
            new MenuItem
            {
                Icon = "fa-solid fa-gear",
                Url = "/hello-blog",
                Text = "test",
                Items = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/hello-blog",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/hello-blog",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/test",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/test",
                        Text = "test",
                    }
                }
            },
            new MenuItem
            {
                Icon = "fa-solid fa-gear",
                Url = "/hello-blog",
                Text = "test",
                Items = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/hello-blog",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/hello-blog",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/test",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/test",
                        Text = "test",
                    }
                }
            },
            new MenuItem
            {
                Icon = "fa-solid fa-gear",
                Url = "/hello-blog",
                Text = "test",
                Items = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/hello-blog",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/hello-blog",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/test",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/test",
                        Text = "test",
                    }
                }
            },
            new MenuItem
            {
                Icon = "fa-solid fa-gear",
                Url = "/hello-blog",
                Text = "test",
                Items = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/hello-blog",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/hello-blog",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/test",
                        Text = "test",
                    },
                    new MenuItem
                    {
                        Icon = "fa-solid fa-gear",
                        Url = "/test",
                        Text = "test",
                    }
                }
            }
            
        };
        return menus;
    }
}
