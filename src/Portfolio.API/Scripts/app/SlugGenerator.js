define("SlugGenerator", function() {

    var SlugGenerator = (function () {
        
        function SlugGenerator(options) {
            var defaults = {
                emptyStringValue: "empty",
                nullValue: "null",
                replacementCharacters: {
                    ",": "",
                    "&": "and",
                    "\\s+": "-",
                    "[^\\x00-\\x7F]": "-",
                    "[^0-9a-z\\.\\-\\_]": "-"
                },
                undefinedValue: "undefined",
                useLowerCase: true
            };
            this.options = $.extend(defaults, options);
        }

        SlugGenerator.prototype.convertToLowerCase = function (value) {
            if (this.options.useLowerCase) {
                value = value.toLowerCase();
            }
            return value;
        };

        SlugGenerator.prototype.getOptions = function () {
            return this.options;
        };

        SlugGenerator.prototype.performReplacements = function (value) {
            $.each(this.options.replacementCharacters, function (key, item) {
                value = value.replace(new RegExp(key, "g"), item);
            });
            return value;
        };

        SlugGenerator.prototype.toSlug = function (value) {
            if (value === undefined)
                return this.options.undefinedValue;
            if (value === null)
                return this.options.nullValue;
            if (value === "")
                return this.options.emptyStringValue;            

            value = value.trim();
            value = this.convertToLowerCase(value);
            value = this.performReplacements(value);

            return value;
        };

        return SlugGenerator;
    })();

    return SlugGenerator;
    
});
