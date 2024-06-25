namespace JobsApi.DLL.Models
{
    public class Job
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyContactEmail { get; set; }
        public string CompanyContactPhone { get; set; }
    }
}
