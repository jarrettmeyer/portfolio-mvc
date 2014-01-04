/*global console, define */
define([
], function () {
    "use strict";

    var Util = (function() {

        function Util(options) {
            this.options = options;
        }

        Util.prototype.log = function (source, message) {
            var logMessage = null;
            if (console && console.log && this.options.debug) {
                if (source && message) {
                    logMessage = source + ": " + message;
                } else {
                    logMessage = source;
                }
                console.log(logMessage);
            }
            return logMessage;
        };

        return Util;

    })();

    return Util;

});