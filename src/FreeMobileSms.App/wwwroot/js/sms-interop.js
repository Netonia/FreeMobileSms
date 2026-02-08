// JavaScript interop for SMS requests
let isSending = false;

window.sendSmsRequest = async function(url) {
    // Prevent duplicate requests
    if (isSending) {
        console.warn('SMS request already in progress');
        return 200;
    }

    isSending = true;

    try {
        // Use no-cors mode which allows sending the request even with CORS restrictions
        // The SMS will be sent even if we can't read the response
        await fetch(url, {
            method: 'GET',
            mode: 'no-cors'
        });
        
        // If fetch completes without throwing an error, the SMS was likely sent
        return 200;
    } catch (error) {
        console.error('SMS Request Error:', error);
        return 0;
    } finally {
        isSending = false;
    }
};
