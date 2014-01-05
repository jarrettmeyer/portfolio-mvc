require(["SlugGenerator"], function (SlugGenerator) {

    return describe("SlugGenerator", function() {

        var slugGenerator;

        beforeEach(function() {
            slugGenerator = new SlugGenerator();
        });

        it("allows special characters", function () {
            var tests = {
                ".NET": ".net",
                "A-B Testing": "a-b-testing",
                "Red, White & Blue": "red-white-and-blue"
            };
            $.each(tests, function (index, item) {
                var slug = slugGenerator.toSlug(index);
                expect(slug).toBe(item);
            });
        });

        it("can be created", function() {
            expect(slugGenerator instanceof SlugGenerator).toBeTruthy();
        });

        it("compresses whitespace in simple strings", function () {
            var slug = slugGenerator.toSlug("  a    b   \t   c     \n   d");
            expect(slug).toBe("a-b-c-d");
        });

        it("generates the expected slug for basic values", function () {
            var tests = {
                "Test Slug": "test-slug",
                "This Is A Longer Test": "this-is-a-longer-test"
            };
            $.each(tests, function (index, item) {
                var slug = slugGenerator.toSlug(index);
                expect(slug).toBe(item);
            });
        });

        it("generates the expected slug for empty strings", function () {
            var slug = slugGenerator.toSlug("");
            expect(slug).toBe("empty");
        });
        
        it("generates the expected slug for null values", function () {
            var slug = slugGenerator.toSlug(null);
            expect(slug).toBe("null");
        });
        
        it("generates the expected slug for undefined values", function () {
            var slug = slugGenerator.toSlug(undefined);
            expect(slug).toBe("undefined");
        });

        it("lowercases simple strings", function () {
            var slug = slugGenerator.toSlug("Testing");
            expect(slug).toBe("testing");
        });

    });

});