/*global define */

define("App",
    ["Util", "Router", "models/CurrentUser", "views/MainWindowView", "views/CurrentUserView"],
    function(Util, Router, CurrentUser, MainWindowView, CurrentUserView) {
        "use strict";

        var App = (function() {

            function App() {
                this.util = new Util(this.options);
                this.router = new Router({ app: this });
                initializeCurrentUser(this);
                initializeMainWindowView(this);
            }

            App.prototype.options = {
                debug: true
            };

            App.prototype.toString = function() {
                return "instance of App. debug: " + this.options.debug;
            };
            
            function initializeCurrentUser(app) {
                app.util.log("app", "initializing current user");
                app.currentUser = new CurrentUser();
                app.currentUserView = new CurrentUserView({
                    model: app.currentUser
                });
                app.currentUserView.render();
            }

            function initializeMainWindowView(app) {
                app.mainWindowView = new MainWindowView({ app: app });
                app.mainWindowView.render();
            }

            return App;
        })();

        return App;

    });
