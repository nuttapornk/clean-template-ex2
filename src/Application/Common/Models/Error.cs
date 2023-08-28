using Newtonsoft.Json;

namespace Application.Common.Models;

public class Error
{
    [JsonProperty("errorcode")]
    public string? Code { get; set; }

    [JsonProperty("headermessage")]
    public string? Header { get; set; }

    [JsonProperty("errormessage")]
    public string? Message { get; set; }
}
