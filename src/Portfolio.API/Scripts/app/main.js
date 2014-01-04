/*global require */

require.config({
    baseUrl: "/Scripts/app",
    paths: {
        "backbone": "../backbone.min",
        "jquery": "../jquery-2.0.3",
        "templates": "templates",
        "underscore": "../underscore"
    },
    shim: {
        "backbone": {
            deps: ["jquery", "underscore"],
            exports: "Backbone"
        }
    }
});