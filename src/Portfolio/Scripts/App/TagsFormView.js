(function () {
    "use strict";

    if (!window.app) {
        window.app = {};
    }

    window.app.TagsFormView = (function () {
        var defaults = {
            descriptionSelector: "#Description",
            slugSelector: "#Slug",
            updateSlugEvents: "blur focus change keyup"
        };

        function TagsFormView(options) {
            console.log("TagsFormView: creating new instance.");
            this.options = $.extend(defaults, options);
            this.initialize();
        }

        TagsFormView.prototype.bindDescriptionChanged = function () {            
            this.$description.on(this.options.updateSlugEvents, function () {
                var value = this.$description.val();
                var slug = this.slugGenerator.toSlug(value);
                this.$slug.val(slug);
            }.bind(this));
        };

        TagsFormView.prototype.initialize = function () {
            this.slugGenerator = new app.SlugGenerator();
            this.$description = $(this.options.descriptionSelector);
            this.$slug = $(this.options.slugSelector);
            this.bindDescriptionChanged();
        };

        return TagsFormView;
    })();

    window.tagsFormView = new app.TagsFormView();    
})();