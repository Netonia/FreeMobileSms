using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace FreeMobileSms.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SmsController(HttpClient httpClient) : ControllerBase
{
    [HttpPost("send")]
    public async Task<IActionResult> SendSms([FromBody] SendSmsRequest request)
    {
        var url = $"https://smsapi.free-mobile.fr/sendmsg?user={Uri.EscapeDataString(request.User)}&pass={Uri.EscapeDataString(request.ApiKey)}&msg={Uri.EscapeDataString(request.Message)}";

        try
        {
            var response = await httpClient.GetAsync(url);

            var result = response.StatusCode switch
            {
                HttpStatusCode.OK => new { success = true, message = "SMS envoyé avec succès !" },
                HttpStatusCode.BadRequest => new { success = false, message = "Erreur 400 : un paramètre est manquant." },
                HttpStatusCode.Forbidden => new { success = false, message = "Erreur 403 : identifiant ou clé API incorrect, ou service non activé." },
                HttpStatusCode.InternalServerError => new { success = false, message = "Erreur 500 : erreur côté serveur Free Mobile." },
                _ => new { success = false, message = $"Erreur inattendue : {(int)response.StatusCode} {response.ReasonPhrase}" }
            };

            return Ok(result);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, new { success = false, message = $"Erreur réseau : {ex.Message}" });
        }
    }
}

public class SendSmsRequest
{
    public required string User { get; set; }
    public required string ApiKey { get; set; }
    public required string Message { get; set; }
}
