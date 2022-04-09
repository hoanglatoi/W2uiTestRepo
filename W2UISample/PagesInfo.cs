using System.Text.Json;

namespace W2UISample
{
    public class PagesList
    {
        public List<PageInfo>? TablePages { get; set; }

        public PagesList()
        {

        }
    }

    public class PageInfo
    {
        public string? ScreenName { get; set; }
        public int Id { get; set; }
        public int PageNum { get; set; }
        public string? Property1 { get; set; }
        public string? Property2 { get; set; }
        public string? Property3 { get; set; }
        public List<string>? ColNames { get; set; }
    }
}
