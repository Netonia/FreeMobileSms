using System.Net;

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
        var url = $"https://smsapi.free-mobile.fr/sendmsg?user={Uri.EscapeDataString(user)}&pass={Uri.EscapeDataString(apiKey)}&msg={Uri.EscapeDataString(message)}";

        try
        {
            var response = await _httpClient.GetAsync(url);

            return response.StatusCode switch
            {
                HttpStatusCode.OK => new SmsResult(true, "SMS envoyé avec succès !"),
                HttpStatusCode.BadRequest => new SmsResult(false, "Erreur 400 : un paramètre est manquant."),
                HttpStatusCode.Forbidden => new SmsResult(false, "Erreur 403 : identifiant ou clé API incorrect, ou service non activé."),
                HttpStatusCode.InternalServerError => new SmsResult(false, "Erreur 500 : erreur côté serveur Free Mobile."),
                _ => new SmsResult(false, $"Erreur inattendue : {(int)response.StatusCode} {response.ReasonPhrase}")
            };
        }
        catch (HttpRequestException ex)
        {
            return new SmsResult(false, $"Erreur réseau : {ex.Message}");
        }
    }
}

public record SmsResult(bool Success, string Message);
