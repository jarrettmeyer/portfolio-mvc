/*global define */

define("App", ["Util", "Router", "models/CurrentUser"], function (Util, Router, CurrentUser) {
    "use strict";

    var App = (function () {
        
        function App() {
            this.util = new Util(this.options);
            this.router = new Router();
            this.currentUser = new CurrentUser();
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
