require(["Util", "SlugGenerator"], function(Util, SlugGenerator) {

    return describe("Util", function() {

        var util;

        beforeEach(function() {
            util = new Util();
        });

        it("can return a slug", function() {
            var slug = util.toSlug("This Is A Test");
            expect(slug).toBe("this-is-a-test");
        });

        it("should extend an options parameter", function() {
            util = new Util({ foo: "bar" });
            expect(util.options.foo).toBe("bar");
        });

        it("should have an options property", function() {
            expect(util.options.debug).toBe(true);
        });

        it("should hold a reference to the slug generator", function () {
            expect(util.slugGenerator instanceof SlugGenerator).toBeTruthy();
        });

    });

});