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

console.log("Done with QUnit tests.");