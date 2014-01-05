define(["backbone", "models/Tag"], function (Backbone, Tag) {

    var TagCollection = Backbone.Collection.extend({        
        
        byActive: function (active) {
            if (active === undefined) {
                active = true;
            }
            var filtered = this.filter(function(tag) {
                return tag.get("isActive") === active;
            });
            return new TagCollection(filtered); 
        },

        model: Tag,
        
        parse: function(result) {
            return result.data;
        },
        
        url: "/api/tags"

    });

    return TagCollection;

});
