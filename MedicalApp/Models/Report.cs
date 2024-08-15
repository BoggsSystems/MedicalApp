public class Report
{
    public int Id { get; set; }
    public int ScanId { get; set; }
    public string Findings { get; set; }
    public string Recommendations { get; set; }
    public DateTime ReportDate { get; set; }
    public string Author { get; set; }
}
