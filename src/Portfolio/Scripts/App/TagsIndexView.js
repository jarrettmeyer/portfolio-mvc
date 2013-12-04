(function () {
    "use strict";
    
    if (!window.app) {
        window.app = {};
    }

    window.app.TagsIndexView = (function () {
        function TagsIndexView() {
            console.log("Created new instance of TagsIndexView");
        }

        TagsIndexView.prototype.initialize = function() {
            app.bindDeleteLinks({
                next: function () {
                    window.location.reload();
                },
                useAntiForgeryToken: true
            });
        };

        return TagsIndexView;
    })();

    var tagsIndexView = new app.TagsIndexView();
    tagsIndexView.initialize();
})();