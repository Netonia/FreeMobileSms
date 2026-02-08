# Free Mobile SMS

Application Blazor WebAssembly pour tester l'envoi de SMS via l'API Free Mobile.

## 🚀 Démo

[https://netonia.github.io/FreeMobileSms/](https://netonia.github.io/FreeMobileSms/)

## 📋 Prérequis

- Un abonnement Free Mobile
- L'option « Notifications par SMS » activée dans l'[Espace Abonné](https://mobile.free.fr/account/)
- Votre identifiant Free Mobile et la clé API associée

## 🛠️ Développement

### Prérequis

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Lancer en local

```bash
dotnet run --project src/FreeMobileSms.App
```

### Compiler

```bash
dotnet build
```

## 📦 Déploiement

L'application est automatiquement déployée sur GitHub Pages via GitHub Actions à chaque push sur `main`.

## 🔒 Sécurité

- Aucun serveur intermédiaire : les identifiants sont envoyés directement depuis le navigateur vers l'API Free Mobile
- Sauvegarde locale optionnelle des identifiants dans le `localStorage` du navigateur
- Connexion HTTPS obligatoire