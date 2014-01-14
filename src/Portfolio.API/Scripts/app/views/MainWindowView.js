define("views/MainWindowView", ["backbone", "text!templates/MainWindowTemplate.html"], function (Backbone, mainWindowTemplate) {

    function ensureElementIsInitialized(view) {
        if (view.isFirstRender) {
            view.$el = $(view.selector);
            view.isFirstRender = false;
            view.app.util.log("MainWindowView", "Initialized jQuery element.");
        }
    }

    var MainWindowView = Backbone.View.extend({

        initialize: function(options) {
            this.app = options.app;
        },

        isFirstRender: true,

        render: function () {
            this.app.util.log("MainWindowView", "rendering view");
            ensureElementIsInitialized(this);
            var content = _.template(this.template);
            this.$el.html(content);
        },

        selector: "#body-content",
        
        showTags: function() {
        },

        template: mainWindowTemplate

    });

    return MainWindowView;

});
