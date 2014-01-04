describe("framework", function() {

    it("can require Backbone", function () {
        require(['backbone'], function (Backbone) {
            expect(Backbone).toBeDefined();
        });
    });

    it("can require jQuery", function() {
        require(['jquery'], function($) {
            expect($).toBeDefined();
        });
    });

    it("can require underscore", function() {
        require(['underscore'], function(_) {
            expect(_).toBeDefined();
        });
    });

    it("should define 'define'", function() {
        expect(define).toBeDefined();
        expect(typeof define).toBe("function");
    });

    it("should define 'require'", function() {
        expect(require).toBeDefined();
        expect(typeof require).toBe("function");
    });

});
