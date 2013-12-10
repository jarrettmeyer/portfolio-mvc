(function() {

    if (!window.app) {
        window.app = {};
    }

    window.app.MainWindowView = Backbone.View.extend({
        
        tagName: "div",
        className: ".body-content",
        
        initialize: function() {
            console.log("app.MainWindowView: initializing view");
        },

        render: function() {
            
        }
        
    });

})();