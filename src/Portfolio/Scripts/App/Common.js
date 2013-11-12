(function () {
    window.formatDate = function(date, defaultValue) {
        defaultValue = defaultValue || "";
        if (date) {
            var day = getDay(date);
            var dt = date.getDate(date);
            var month = getMonth(date);
            var year = date.getFullYear();
            return day + " " + dt + " " + month + " " + year;
        }
        return defaultValue;
    };

    window.parseMvcDate = function (mvcDate) {
        if (!mvcDate) {
            return null;
        }
        var ticksAsString = mvcDate.substring(6);
        var ticksAsInt = parseInt(ticksAsString);
        var date = new Date(ticksAsInt);
        return date;        
    };
    
    function getDay(date) {
        var d = date.getDay();
        var days = { 0: "Sun", 1: "Mon", 2: "Tue", 3: "Wed", 4: "Thu", 5: "Fri", 6: "Sat" };
        return days[d];
    }

    function getMonth(date) {
        var m = date.getMonth();
        var months = { 0: "Jan", 1: "Feb", 2: "Mar", 3: "Apr", 4: "May", 5: "Jun", 6: "Jul", 7: "Aug", 8: "Sep", 9: "Oct", 10: "Nov", 11: "Dec" };
        return months[m];        
    }

    Array.prototype.replaceIndex = function (index, item) {
        var i, len, newArray = [];
        for (i = 0, len = this.length; i < len; i += 1) {
            if (i === index) {
                newArray.push(item);
            } else {
                newArray.push(this[i]);
            }
        }
        return newArray;
    };

    Array.prototype.replaceWhen = function (predicate, item) {
        var i, len, newArray = [];
        for (i = 0, len = this.length; i < len; i += 1) {
            if (predicate(this[i])) {
                newArray.push(item);
            } else {
                newArray.push(this[i]);
            }
        }
        return newArray;
    };

    /**
     * Converts the string to a JavaScript date object.
     */
    String.prototype.toDate = function () {
        // MVC-date format
        if (this.match(/\/Date\(\d+\)\//)) { 
            var ticksAsString = this.substring(6);
            var ticksAsInt = parseInt(ticksAsString);
            var date = new Date(ticksAsInt);
            return date;
        }
        
        // yyyy-mm-dd format used by Twitter Bootstrap
        if (this.match(/\d{4}-\d{1,2}-\d{1,2}/)) {
            var dateInt = Date.parse(this);
            return new Date(dateInt);            
        }
        
        // I have no idea what this is
        return Date.parse(this);        
    };

    /**
     *
     */
    $(function() {
        $("body").on("click", ".delete-link", function () {
            var $this = $(this),
                href = $this.attr("href");
            $.ajax({
                url: href,
                type: "DELETE",
                success: function() {
                    window.location.reload();
                }
            });
            return false;
        });
    });
})();