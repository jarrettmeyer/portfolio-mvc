define("views/CurrentUserView",
    ["jquery", "backbone", "text!templates/CurrentUserTemplate.html"],
    function ($, Backbone, currentUserTemplate) {

        var CurrentUserView = Backbone.View.extend({

            $el: $("#current-user"),

            el: "#current-user",

            render: function () {
                var content = this.template(this.model.attributes);
                this.$el.html(content);
                return this;
            },

            template: _.template(currentUserTemplate)
            
        });

        return CurrentUserView;

    });