# PRD --- Application Blazor WASM Test SMS Free Mobile

## 1. Contexte et objectif

Application web statique développée en Blazor WebAssembly et hébergeable
sur GitHub Pages permettant de tester l'envoi de SMS via l'API
officielle Free Mobile.

Objectifs : - Fournir une interface simple pour envoyer un SMS de
test. - Être utilisable sans backend dédié. - Fonctionner intégralement
en hébergement statique GitHub Pages. - Reproduire les fonctionnalités
essentielles du projet FreeMobile-API-SMS.

------------------------------------------------------------------------

## 2. Fonctionnalités

### 2.1 Fonction principale

-   Saisie de l'identifiant Free Mobile
-   Saisie de la clé API
-   Saisie du numéro destinataire
-   Saisie du message (≤160 caractères)
-   Bouton d'envoi
-   Affichage du résultat de l'API

### 2.2 Expérience utilisateur

-   Validation des champs obligatoire
-   Gestion des erreurs HTTP
-   Indicateur de chargement
-   Sauvegarde locale optionnelle des identifiants

### 2.3 Documentation intégrée

-   Procédure d'activation de l'API Free Mobile
-   Exemples de messages
-   Aide au formatage

------------------------------------------------------------------------

## 3. Architecture technique

### 3.1 Stack

-   slnx
- .NET 10 Blazor WebAssembly
-   Application 100% cliente
-   HttpClient pour appels HTTPS
-   Déploiement statique GitHub Pages

### 3.2 Appel API

Endpoint :
https://smsapi.free-mobile.fr/sendmsg?user={user}&pass={pass}&msg={msg}

Méthodes : - GET simple
- POST recommandé si possible

### 3.3 Sécurité

-   Aucune persistance serveur
-   Stockage local facultatif
-   Avertissement sur l'exposition des clés
-   HTTPS obligatoire

------------------------------------------------------------------------

## 4. Interface

-   Page unique responsive
-   Formulaire centré
-   Zone de logs

------------------------------------------------------------------------

## 5. Déploiement

-   Build Blazor WASM
-   Publication dossier wwwroot
-   Workflow GitHub Actions
-   Hébergement GitHub Pages

------------------------------------------------------------------------

## 6. Critères d'acceptation

-   Envoi réel de SMS réussi
-   Fonctionnement sans backend
-   Déploiement GitHub Pages opérationnel
-   Gestion d'erreurs claire

------------------------------------------------------------------------

## 7. Évolutions

-   Historique local
-   Templates
-   Mode hors‑ligne
