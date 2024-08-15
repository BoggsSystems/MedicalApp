public class Technician
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<string> Skills { get; set; }

    public Technician()
    {
        Skills = new List<string>();
    }
}
