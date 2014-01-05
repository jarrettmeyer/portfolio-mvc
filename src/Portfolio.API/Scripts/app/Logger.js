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

        Logger.prototype.log = function(source, message) {
            var logMessage;
            if (source && message) {
                logMessage = source + ": " + message;
                this.history.push({
                    source: source,
                    message: message
                });
            } else {                
                logMessage = source;
                this.history.push({
                    source: null,
                    message: logMessage
                });
            }
            if (this.canWriteLog) {
                console.log(logMessage);
            }
            return logMessage;
        };

        return Logger;

    })();

    return Logger;

});