/**
 * Delete links, as indicated with the CSS class .delete-link, need to 
 * send a DELETE request to the server, not a GET. This method will 
 * overwrite those links.
 */
(function () {
    "use strict";

    if (!window.app) {
        window.app = {};
    }

    app.bindDeleteLinks = function (options) {
        var self = this;

        var defaults = {
            antiForgeryTokenField: "__RequestVerificationToken",
            before: function() {
                console.log("Before sending AJAX request.");
            },
            deleteLinkSelector: ".delete-link",
            events: "click",
            httpMethod: "DELETE",
            next: function() {
                window.location.reload();
            },
            useAntiForgeryToken: false
        };
        
        self.options = $.extend(defaults, options);
                
        $("body").on(self.options.events, self.options.deleteLinkSelector, function (event) {
            var data = {};

            // Get the URL from the link that was clicked.
            var url = $(this).attr("href");
            
            // If a before delegate exists, then invoke the delegate.
            if (self.options.before) {
                self.options.before();
            }
            
            // Check for anti-forgery tokens.
            if (self.options.useAntiForgeryToken) {
                var tokenValue = $("input[name=" + self.options.antiForgeryTokenField + "]").val();
                data[self.options.antiForgeryTokenField] = tokenValue;
                console.log("Anti Forgery Token: " + tokenValue);
            }
            
            console.log("Sending delete request. URL: " + url);
            $.ajax({
                url: url,
                type: self.options.httpMethod,
                cache: false,
                complete: function (jqXHR, textStatus) {
                    console.log("Delete request complete. Text status: " + textStatus);
                    if (self.options.next) {
                        self.options.next();
                    }
                },
                data: data
            });
            return false;
        });
    };    
})();