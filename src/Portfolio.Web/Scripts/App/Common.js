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
})();