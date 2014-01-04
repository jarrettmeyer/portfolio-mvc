define(["models/Tag"], function(Tag) {

    return describe("Tag", function() {

        var tag;

        beforeEach(function() {
            tag = new Tag({ id: 1, slug: "my-tag", description: "My Tag", isActive: true });
        });

        it("has the expected value for id", function() {
            expect(tag.id).toBe(1);
        });

    });

});