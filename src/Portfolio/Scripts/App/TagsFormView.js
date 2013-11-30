(function () {
    "use strict";

    if (!window.app) {
        window.app = {};
    }

    window.app.TagsFormView = (function() {
        function TagsFormView(options) {
            var defaults = {
                descriptionSelector: "#Description",
                slugSelector: "#Slug",
                updateSlugEvents: "blur focus change keyup"
            };
            this.options = $.extend(defaults, options);
            this.slugGenerator = new app.SlugGenerator();
            this.$description = $(this.options.descriptionSelector);
            this.$slug = $(this.options.slugSelector);
        }

        TagsFormView.prototype.bindDescriptionChanged = function () {            
            this.$description.on(this.options.updateSlugEvents, function () {
                var value = this.$description.val();
                var slug = this.slugGenerator.toSlug(value);
                this.$slug.val(slug);
            }.bind(this));
        };

        TagsFormView.prototype.initialize = function () {
            this.bindDescriptionChanged();
        };

        return TagsFormView;
    })();

    var tagsFormView = new app.TagsFormView();
    tagsFormView.initialize();
})();