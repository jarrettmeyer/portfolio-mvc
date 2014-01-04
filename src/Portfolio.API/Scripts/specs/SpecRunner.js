require.config({
    baseUrl: "/Scripts/app",
    paths: {
        "backbone": "../backbone",
        "jasmine": "../jasmine/jasmine",
        "jasmine-html": "../jasmine/jasmine-html",
        "jquery": "../jquery-2.0.3",
        "specs": "../specs",
        "underscore": "../underscore"
    },
    shim: {
        "underscore": {
            exports: "_"
        },
        "backbone": {
            deps: ["jquery", "underscore"],
            exports: "Backbone"
        },
        "jasmine": {
            exports: "jasmine"
        },
        "jasmine-html": {
            deps: ["jasmine"],
            exports: "jasmine"
        }
    }
});

require(["jquery", "underscore", "jasmine-html"], function ($, _, jasmine) {
    var jasmineEnv = jasmine.getEnv();
    jasmineEnv.updateInterval = 1000;

    var htmlReporter = new jasmine.HtmlReporter();

    jasmineEnv.addReporter(htmlReporter);

    jasmineEnv.specFilter = function (spec) {
        return htmlReporter.specFilter(spec);
    };

    var specs = [];
    specs.push("specs/FrameworkSpecs");
    specs.push("specs/AppSpecs");
    specs.push("specs/models/TagSpecs");
    specs.push("specs/collections/TagCollectionSpecs");

    $(function() {
        require(specs, function() {
            jasmineEnv.execute();
        });
    });
});