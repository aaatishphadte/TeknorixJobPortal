namespace TeknorixAPI.Models
{
    public class SearchResultDto
    {
        public int Total { get; set; }
        public List<Jobs>? data { get; set; }
    }
}
