define(["backbone", "models/Tag"], function (Backbone, Tag) {

    var TagCollection = Backbone.Collection.extend({        
        
        model: Tag,
        
        parse: function(result) {
            return result.data;
        },
        
        url: "api/tags"

    });

    return TagCollection;

});
