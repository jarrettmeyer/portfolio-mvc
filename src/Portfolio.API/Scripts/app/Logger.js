define("Logger", [], function () {

    var Logger = (function() {

        var defaults = {
            debug: true
        };

        function Logger(options) {
            this.options = $.extend(defaults, options);
            this.canWriteLog = (console && console.log && this.options.debug);
            this.history = [];
        }

        Logger.prototype.log = function (source, message) {
            this.history.push({
                source: source,
                message: message
            });
            var logMessage = source + ": " + message;
            if (this.canWriteLog) {
                console.log(logMessage);
            }
            return logMessage;
        };

        return Logger;

    })();

    return Logger;

});