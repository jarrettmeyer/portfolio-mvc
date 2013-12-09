(function () {
    "use strict";
    
    if (!window.app) {
        window.app = {};
    }

    window.app.NewSessionView = (function () {

        // Constructor
        function NewSessionView(options) {
            console.log("NewSessionView: creating new instance.");
            this.options = $.extend(options, defaults);            
            this.initialize();
        }                

        return NewSessionView;
    })();

    window.newSessionView = new app.NewSessionView();
    
})();