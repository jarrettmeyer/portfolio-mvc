define("view/LogonView", ["backbone"], function (Backbone) {

    var LogonView = Backbone.View.extend({
        
        currentUser: null,
        
        events: {
            "click .logon": "logon"
        },

        initialize: function(attributes) {
            this.currentUser = attributes.currentUser;
        }

    });

    return LogonView;

});