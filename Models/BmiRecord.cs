namespace BmiBlazorApp.Models;

public class BmiRecord
{
    public int Id { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Bmi { get; set; }
    public string Category { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}