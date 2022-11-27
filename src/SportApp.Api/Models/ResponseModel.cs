using System.Text.Json;

namespace SportApp.Api.Models
{
    public class ResponseModel
    {
        public string? Status { get; set; }
        public string? Message { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}