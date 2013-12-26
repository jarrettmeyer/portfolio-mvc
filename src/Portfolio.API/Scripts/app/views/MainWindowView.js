(function() {

    if (!window.app) {
        window.app = {};
    }

    window.app.MainWindowView = Backbone.View.extend({

        className: ".body-content",
        
        initialize: function() {
            console.log("app.MainWindowView: initializing view");
            this.currentUser = new app.CurrentUser();
            this.logonView = new app.LogonView({
                 currentUser: this.currentUser
            });
        },

        render: function() {
            
        },
        
        tagName: "div"
        
    });

})();