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

    app.bindDeleteLinks = function (next) {
        // If no next callback is given, then just reload the page.
        if (!next) {
            next = window.location.reload;
        }
        $("body").on("click", ".delete-link", function () {
            var url = $(this).attr("href");
            console.log("Sending delete request. URL: " + url);
            $.ajax({
                url: url,
                type: "DELETE",
                cache: false,
                onComplete: function (jqXHR, textStatus) {
                    console.log("Delete request complete. Text status: " + textStatus);
                    next();
                }
            });
            return false;
        });
    };    
})();