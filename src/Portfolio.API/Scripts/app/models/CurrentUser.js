define("models/CurrentUser", ["backbone"], function (Backbone) {

    var CurrentUser = Backbone.Model.extend({        
       
        authenticate: function (result) {
            if (result.success) {
                this.set({
                    id: result.id,
                    isAuthenticated: true,
                    sessionId: result.sessionId,
                    username: result.username
                });
            }
            return this;
        },

        initialize: function() {
            this.setDefaultValues();
            return this;
        },
        
        isAuthenticated: function() {
            return this.get("isAuthenticated");
        },
        
        logoff: function() {
            this.setDefaultValues();
            return this;
        },
        
        setDefaultValues: function() {
            this.set({
                id: 0,
                isAuthenticated: false,
                sessionId: null,
                username: "Guest"
            });
            return this;
        }

    });

    return CurrentUser;

});