using System.Text.Json;

namespace doit.Models.Errors;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string ErrorId { get; set; } = Guid.NewGuid().ToString();
    public string RequestId { get; set; }
    public string Details { get; set; }
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    public string StackTrace { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions
        {
            WriteIndented = true // To make the JSON output more readable
        });
    }
}