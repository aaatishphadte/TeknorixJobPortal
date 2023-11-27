namespace TeknorixAPI.Models
{
    public class SearchDto
    {
        public string query { get; set; }

        public int PageNo { get; set; }

        public int PageSize { get; set; }
        public int? LocationId { get; set; }
        public int? DepartmentID { get; set; }
    }
}
