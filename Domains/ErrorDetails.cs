using System.Text.Json;

namespace MyHabitsApi.Domains
{
    public class ErrorDetails
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public string? Trace { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
