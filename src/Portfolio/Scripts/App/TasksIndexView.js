(function () {
    "use strict";

    if (!window.app) {
        window.app = {};
    }

    window.app.TasksIndexView = (function () {
        function TasksIndexView(options) {
            var defaults = {
                completeSelector: ".task-complete-button"
            };
            this.options = $.extend(defaults, options);
            this.isInitialized = false;
            this.$body = $("body");
            console.log("Created new instance of TasksIndexView");
        }

        TasksIndexView.prototype.bindCompleteButtons = function () {
            this.$body.on("click", this.options.completeSelector, function(event) {
                var $el = $(event.target);
                var url = $el.attr("data-url");
                console.log("Sending POST to " + url);
                $.post(url, function() {
                    window.location.reload();
                });
            });
        };

        TasksIndexView.prototype.initialize = function () {
            console.log("Initializing TasksIndexView");
            this.bindCompleteButtons();
            this.isInitialized = true;
        };

        return TasksIndexView;
    })();

    var tasksIndexView = new app.TasksIndexView();
    tasksIndexView.initialize();
})();