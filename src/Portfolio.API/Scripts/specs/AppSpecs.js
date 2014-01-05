define(['App', 'Router', 'Util'], function (App, Router, Util) {
    
    return describe("App", function() {

        var app = new App();

        it("should be defined", function() {
            expect(app).toBeDefined();
        });

        it("should have a router property", function () {
            expect(app.router).toBeDefined();
            expect(app.router instanceof Router).toBeTruthy();
        });

        it("should have a util property", function() {
            expect(app.util).toBeDefined();
            expect(app.util instanceof Util).toBeTruthy();
        });

        it("should have an options property", function() {
            expect(app.options).toBeDefined();
            expect(typeof app.options).toBe("object");
        });
        
    });
    
});
