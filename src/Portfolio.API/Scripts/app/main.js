/*global require */

require.config({
    baseUrl: "/Scripts/app",
    paths: {
        "backbone": "../backbone",
        "jquery": "../jquery-2.0.3",
        "templates": "templates",
        "underscore": "../underscore"
    },
    shim: {
        "underscore": {
            exports: "_"
        },
        "backbone": {
            deps: ["jquery", "underscore"],
            exports: "Backbone"
        }
    }
});

require(["App"], function(App) {

    window.app = new App();

});