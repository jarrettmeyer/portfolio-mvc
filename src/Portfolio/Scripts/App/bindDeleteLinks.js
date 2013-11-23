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
            before: function() {
                console.log("Before sending AJAX request.");
            },
            deleteLinkSelector: ".delete-link",
            events: "click",
            httpMethod: "DELETE",
            next: function() {
                window.location.reload();
            }
        };
        self.options = $.extend(defaults, options);
                
        $("body").on(self.options.events, self.options.deleteLinkSelector, function () {
            var url = $(this).attr("href");
            if (self.options.before) {
                self.options.before();
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
                }
            });
            return false;
        });
    };    
})();