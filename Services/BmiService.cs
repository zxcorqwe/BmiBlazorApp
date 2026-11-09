using BmiBlazorApp.Models;

namespace BmiBlazorApp.Services;

public class BmiService
{
    private readonly List<BmiRecord> _records = new();
    private int _nextId = 1;

    public List<BmiRecord> GetAll() => _records;

    public BmiRecord Create(double height, double weight)
    {
        var (bmi, category) = CalculateBmi(height, weight);
        var record = new BmiRecord
        {
            Id = _nextId++,
            Height = height,
            Weight = weight,
            Bmi = bmi,
            Category = category,
            CreatedAt = DateTime.UtcNow
        };
        _records.Add(record);
        return record;
    }

    public void Delete(int id)
    {
        var record = _records.FirstOrDefault(r => r.Id == id);
        if (record != null) _records.Remove(record);
    }

    public static (double Bmi, string Category) CalculateBmi(double heightCm, double weightKg)
    {
        double heightM = heightCm / 100.0;
        double bmi = weightKg / (heightM * heightM);
        string category = bmi switch
        {
            < 16.0 => "Выраженный дефицит массы тела",
            < 18.5 => "Недостаточная масса тела",
            < 25.0 => "Норма",
            < 30.0 => "Избыточная масса тела (предожирение)",
            < 35.0 => "Ожирение I степени",
            < 40.0 => "Ожирение II степени",
            _ => "Ожирение III степени"
        };
        return (bmi, category);
    }
}