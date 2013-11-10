console.log("Starting QUnit tests.");

test("initial test", function () {
    ok(true);
});

module("Array.replaceIndex tests");
test("can replace by index", function () {
    var a = [1, 2, 3, 4, 5];
    var testCase = {
        0: [-1, 2, 3, 4, 5],
        1: [1, -1, 3, 4, 5],
        2: [1, 2, -1, 4, 5],
        3: [1, 2, 3, -1, 5],
        4: [1, 2, 3, 4, -1]
    };
    for (var i = 0; i < 4; i += 1) {
        var b = a.replaceIndex(i, -1);
        deepEqual(b, testCase[i]);
    }
});

module("Array.replaceWhen");
test("can replace with a predicate", function() {
    var a = [1, 2, 3, 4, 5];
    var condition = function(x) {
        return x % 2 === 0;
    };
    var b = a.replaceWhen(condition, -1);
    deepEqual([1, -1, 3, -1, 5], b);
});

module("String.toDate");
test("can parse MVC style date format", function () {
    expect(1);
    var s = "/Date(1379716140000)/";
    var d = s.toDate();
    var expected = new Date(1379716140000);
    equal(expected.toString(), d.toString());
});
test("can parse yyyy-mm-dd date format", function () {
    var s = "2013-09-28";
    var d = s.toDate();
    var expected = new Date(Date.parse("2013-09-28"));
    //console.log("expected date: " + expected.toUTCString());
    equal(expected.toString(), d.toString());
});


console.log("Done with QUnit tests.");