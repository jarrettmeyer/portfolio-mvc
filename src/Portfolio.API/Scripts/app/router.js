/*global app, define */
define("Router", ['jquery', 'underscore', 'backbone'], function ($, _, Backbone) {
    "use strict";

    var Router = Backbone.Router.extend({
        
        routes: {
            "logon": "showLogon",
            "tags": "showTags",
            "tasks": "showTasks"
        },
        
        showLogon: function() {
            
        },

        showTags: function() {
            app.util.log("Router", "showTags");
        },
        
        showTasks: function() {
            app.util.log("Router", "showTasks");
        }
        
    });

    return Router;

});