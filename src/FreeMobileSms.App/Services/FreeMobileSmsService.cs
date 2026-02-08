using System.Net;
using Microsoft.JSInterop;

namespace FreeMobileSms.App.Services;

public class FreeMobileSmsService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;

    public FreeMobileSmsService(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
    }

    public async Task<SmsResult> SendAsync(string user, string apiKey, string message)
    {
        var url = $"https://smsapi.free-mobile.fr/sendmsg?user={Uri.EscapeDataString(user)}&pass={Uri.EscapeDataString(apiKey)}&msg={Uri.EscapeDataString(message)}";

        try
        {
            // Use JavaScript fetch to bypass CORS restrictions
            var statusCode = await _jsRuntime.InvokeAsync<int>("window.sendSmsRequest", url);

            return statusCode switch
            {
                200 => new SmsResult(true, "SMS envoyé avec succès !"),
                400 => new SmsResult(false, "Erreur 400 : un paramètre est manquant."),
                403 => new SmsResult(false, "Erreur 403 : identifiant ou clé API incorrect, ou service non activé."),
                500 => new SmsResult(false, "Erreur 500 : erreur côté serveur Free Mobile."),
                0 => new SmsResult(false, "Erreur réseau : impossible de joindre le service."),
                _ => new SmsResult(false, $"Erreur inattendue : {statusCode}")
            };
        }
        catch (Exception ex)
        {
            return new SmsResult(false, $"Erreur : {ex.Message}");
        }
    }
}

public record SmsResult(bool Success, string Message);
