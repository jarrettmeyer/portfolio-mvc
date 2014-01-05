require(["Logger"], function(Logger) {

    return describe("Logger", function() {

        var logger;

        beforeEach(function() {
            logger = new Logger();
        });

        it("can write to the log", function() {
            var result = logger.log("test", "this is a test");
            expect(result).toBe("test: this is a test");
        });

        it("saves a log history", function() {
            logger.log("something happened");
            var history = logger.history;
            expect(history.length).toBe(1);
        });

    });

});