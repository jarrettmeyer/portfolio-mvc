(function() {
    app.TagCollection = Backbone.Collection.extend({
        model: app.Tag,
        
        parse: function(result) {
            return result.data;
        },

        url: "/api/tags"
    });
})();