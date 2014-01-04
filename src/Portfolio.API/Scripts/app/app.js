/*global require */
require.config({
    baseUrl: "/Scripts/app",
    paths: {
        "jquery": "../jquery-2.0.3",
        "underscore": "../underscore",
        "backbone": "../backbone.min",
        "templates": "templates"
    },
    shim: {
        "backbone": {
            deps: ["jquery", "underscore"],
            exports: "Backbone"
        }
    }
});

require([
    "util",
    "router"
], function(Util, Router) {

    var App = (function () {
        
        function App() {
            this.util = new Util(this.options);
            this.router = new Router();
        }

        App.prototype.options = {
            debug: true
        };

        return App;
    })();

    window.app = new App();
});
