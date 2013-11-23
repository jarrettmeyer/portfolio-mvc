(function () {
    "use strict";
    
    if (!window.app) {
        window.app = {};
    }

    window.app.TagsIndexView = (function () {
        function TagsIndexView() {
            
        }

        TagsIndexView.prototype.initialize = function() {
            app.bindDeleteLinks(function () {
                window.location.reload();
            });
        };

        return TagsIndexView;
    })();

    var tagsIndexView = new app.TagsIndexView();
    tagsIndexView.initialize();
})();