(function () {

    window.app.LogonView = Backbone.View.extend({
        
        currentUser: null,
        
        events: {
            "click .logon": "logon"
        },

        initialize: function(attributes) {
            this.currentUser = attributes.currentUser;
        }

    });
})();