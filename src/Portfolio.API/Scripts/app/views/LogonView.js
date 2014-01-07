define("views/LogonView", ["backbone", "models/Credentials", "text!templates/LogonTemplate.html"], function (Backbone, Credentials, logonTemplate) {
    "use strict";

    var LogonView = Backbone.View.extend({        

        events: {
            "click .logon": "logon"
        },

        initialize: function (options) {
            this.app = options.app;
            this.model = new Credentials();
            this.app.util.log("LogonView", "initialized");
        },

        logon: function() {
            this.app.util.log("LogonView", "logon");
        },

        render: function() {
            var content = this.template(this.model.attributes);
            this.$el.html(content);
            return this;
        },

        template: _.template(logonTemplate)
    });

    return LogonView;

});
