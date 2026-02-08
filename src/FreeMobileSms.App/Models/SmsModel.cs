using System.ComponentModel.DataAnnotations;

namespace FreeMobileSms.App.Models;

public class SmsModel
{
    [Required(ErrorMessage = "L'identifiant Free Mobile est requis.")]
    public string User { get; set; } = string.Empty;

    [Required(ErrorMessage = "La clé API est requise.")]
    public string ApiKey { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le message est requis.")]
    [MaxLength(160, ErrorMessage = "Le message ne peut pas dépasser 160 caractères.")]
    public string Message { get; set; } = string.Empty;
}
