/*global require */

require.config({
    baseUrl: "/Scripts/app",
    paths: {
        "backbone": "../backbone",
        "jquery": "../jquery-2.0.3",
        "text": "../text",
        "underscore": "../underscore"
    },
    shim: {
        "backbone": {
            deps: ["jquery", "underscore"],
            exports: "Backbone"
        },
        "underscore": {
            exports: "_"
        }
    }
});

require(["App"], function(App) {

    window.app = new App();

});