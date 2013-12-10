(function() {

    if (!window.app) {
        window.app = {};
    }

    window.app.CurrentUser = Backbone.Model.extend({        
       
        authenticate: function (result) {
            if (result.success) {
                this.set({
                    id: result.id,
                    isAuthenticated: true,
                    sessionId: result.sessionId,
                    username: result.username
                });                
            }            
        },

        initialize: function() {
            this.setDefaultValues();
        },

        logoff: function() {
            this.setDefaultValues();
        },
        
        setDefaultValues: function() {
            this.set({
                id: 0,
                isAuthenticated: false,
                sessionId: null,
                username: "Guest"
            });
        }

    });

})();