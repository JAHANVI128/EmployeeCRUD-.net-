namespace Employee.Models
{
    public class Emp
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public bool IsActive { get; set; }

    }
}
