// Override the Welcome greeting with Välkommen
(function() {
    // Wait for the page to load
    function replaceWelcomeText() {
        // Find all heading elements with "Welcome" text
        const headings = document.querySelectorAll('h1, h2, h3, h4, h5, h6');
        headings.forEach(heading => {
            if (heading.textContent.trim() === 'Welcome') {
                heading.textContent = 'Välkommen';
            }
        });
    }
    
    // Run immediately
    replaceWelcomeText();
    
    // Also run after a short delay to catch dynamically loaded content
    setTimeout(replaceWelcomeText, 100);
    setTimeout(replaceWelcomeText, 500);
    setTimeout(replaceWelcomeText, 1000);
    
    // Use MutationObserver to watch for changes
    const observer = new MutationObserver(replaceWelcomeText);
    observer.observe(document.body, {
        childList: true,
        subtree: true
    });
})();
