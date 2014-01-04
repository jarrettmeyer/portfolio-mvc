/*global require */

define([
    "util",
    "router"
], function (Util, Router) {
    "use strict";

    var App = (function () {
        
        function App() {
            this.util = new Util(this.options);
            this.router = new Router();
        }

        App.prototype.options = {
            debug: true
        };

        App.prototype.toString = function () {
            return "instance of App. debug: " + this.options.debug;
        };

        return App;
    })();
    
    return App;
});
