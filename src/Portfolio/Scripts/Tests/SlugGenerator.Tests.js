describe("SlugGenerator", function () {
    var slugGenerator;

    beforeEach(function() {
        slugGenerator = new SlugGenerator();
    });    

    it("generates the expected slug for undefined values", function () {
        var slug = slugGenerator.toSlug(undefined);
        expect(slug).toBe("null");
    });
    
    it("generates the expected slug for null values", function() {
        var slug = slugGenerator.toSlug(null);
        expect(slug).toBe("null");
    });
    
    it("generates the expected slug for empty strings", function() {
        var slug = slugGenerator.toSlug("");
        expect(slug).toBe("empty");
    });

    it("generates the expected slug for basic values", function() {
        var tests = {            
            "Test Slug": "test-slug",
            "This Is A Longer Test": "this-is-a-longer-test"
        };
        $.each(tests, function (index, item) {
            var slug = slugGenerator.toSlug(index);
            expect(slug).toBe(item);
        });
    });
    
    it("compresses whitespace in simple strings", function() {
        var slug = slugGenerator.toSlug("  a    b   \t   c     \n   d");
        expect(slug).toBe("a-b-c-d");
    });
    
    it("lowercases simple strings", function() {
        var slug = slugGenerator.toSlug("Testing");
        expect(slug).toBe("testing");
    });

    it("allows special characters", function() {
        var tests = {
            ".NET": ".net",
            "A-B Testing": "a-b-testing"
        };
        $.each(tests, function (index, item) {
            var slug = slugGenerator.toSlug(index);
            expect(slug).toBe(item);
        });
    });
});