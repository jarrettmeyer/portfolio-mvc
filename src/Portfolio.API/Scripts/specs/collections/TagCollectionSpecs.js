define(["collections/TagCollection", "models/Tag"], function (TagCollection, Tag) {

    return describe("TagCollection", function() {

        var tagCollection;

        var tags = [
            { id: 1, slug: "tag-1", description: "Tag 1", isActive: true },
            { id: 2, slug: "tag-2", description: "Tag 2", isActive: true },
            { id: 3, slug: "tag-3", description: "Tag 3", isActive: false }
        ];

        beforeEach(function() {
            tagCollection = new TagCollection(tags);
        });

        it("can get active tags", function() {
            var activeTags = tagCollection.byActive();
            expect(activeTags.length).toBe(2);
            expect(activeTags.at(0).get("slug")).toBe("tag-1");
            expect(activeTags.at(1).get("slug")).toBe("tag-2");
        });

        it("has the expected model type", function () {
            var newModel = new tagCollection.model();
            expect(newModel instanceof Tag).toBeTruthy();
        });

        it("should have 3 tags", function() {
            expect(tagCollection.length).toBe(3);
        });

    });
    
});