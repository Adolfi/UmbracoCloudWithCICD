// Override the Welcome greeting with Välkommen
(function() {
    // Wait for the page to load
    function replaceWelcomeText() {
        // Target only the login modal heading to avoid unintended replacements
        const authModal = document.querySelector('umb-app-auth-modal');
        if (authModal) {
            const heading = authModal.querySelector('h1');
            if (heading && heading.textContent.trim() === 'Welcome') {
                heading.textContent = 'Välkommen';
            }
        }
    }
    
    // Run immediately
    replaceWelcomeText();
    
    // Use MutationObserver to watch for changes
    const observer = new MutationObserver(replaceWelcomeText);
    observer.observe(document.body, {
        childList: true,
        subtree: true
    });
})();
