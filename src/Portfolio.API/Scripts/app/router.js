/*global app, define */
define("Router", ['jquery', 'underscore', 'backbone'], function ($, _, Backbone) {
    "use strict";

    var Router = Backbone.Router.extend({
        
        initialize: function (options) {
            this.app = options.app;
        },

        routes: {
            "logon": "showLogon",
            "tags": "showTags",
            "tasks": "showTasks"
        },
        
        showLogon: function() {
            
        },

        showTags: function() {
            this.app.util.log("Router", "showTags");
            this.app.mainWindowView.showTags();
        },
        
        showTasks: function() {
            this.app.util.log("Router", "showTasks");
        }
        
    });

    return Router;

});