define("views/CurrentUserView",
    ["jquery", "backbone", "text!templates/CurrentUserTemplate.html"],
    function ($, Backbone, currentUserTemplate) {

        var CurrentUserView = Backbone.View.extend({
            $el: "#current-user",

            initialize: function(options) {
                this.model = options.currentUser;
            },

            render: function() {
                this.$el.html();
                return this;
            },

            template: _.template(currentUserTemplate, this.model)
        });

        return CurrentUserView;

    });