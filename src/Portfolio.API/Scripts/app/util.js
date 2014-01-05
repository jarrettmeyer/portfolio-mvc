/*global console, define */
define("Util", ["jquery", "Logger", "SlugGenerator"], function ($, Logger, SlugGenerator) {
    "use strict";

    var Util = (function() {

        var defaults = {
            debug: true
        };

        function Util(options) {
            this.options = $.extend(defaults, options);
            this.logger = new Logger(this.options);
            this.slugGenerator = new SlugGenerator(this.options);
        }

        Util.prototype.log = function (source, message) {
            this.logger.log(source, message);
        };

        Util.prototype.toSlug = function(message) {
            return this.slugGenerator.toSlug(message);
        };

        return Util;

    })();

    return Util;

});