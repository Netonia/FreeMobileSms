using System.Net;
using System.Net.Http.Json;

namespace FreeMobileSms.App.Services;

public class FreeMobileSmsService
{
    private readonly HttpClient _httpClient;

    public FreeMobileSmsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SmsResult> SendAsync(string user, string apiKey, string message)
    {
        var request = new { user, apiKey, message };
        
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/sms/send", request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<SmsResult>();
                return content;
            }
            
            return new SmsResult(false, "Erreur lors de l'envoi du SMS.");
        }
        catch (HttpRequestException ex)
        {
            return new SmsResult(false, $"Erreur réseau : {ex.Message}");
        }
    }
}

public record SmsResult(bool Success, string Message);
