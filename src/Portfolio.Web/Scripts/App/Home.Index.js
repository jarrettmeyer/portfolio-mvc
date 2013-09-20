(function () {

    var TasksViewModel = function (tasks, pageSize) {
        var self = this;

        self.tasks = ko.observableArray(tasks);
        self.pageSize = ko.observable(pageSize);

        self.gridViewModel = new ko.grid.viewModel({
            data: self.tasks,
            columns: [
                { headerText: "Description", rowText: "Description" },
                { headerText: "Category", rowText: function (x) { return x.Category.Description; } },
                { headerText: "Status", rowText: function (x) { return x.Status.Description; } },
                { headerText: "Created On", rowText: function (x) { return formatDate(parseMvcDate(x.CreatedAt)); } },
                { headerText: "Due On", rowText: function (x) { return formatDate(parseMvcDate(x.DueOn)); } }
            ],
            pageSize: self.pageSize()
        });

        self.addTask = function() {

        };
    };

    var initialData;

    $.get("/tasks", function (result) {
        window.tasksViewModel.tasks(result);
    });

    window.tasksViewModel = new TasksViewModel([], 5);
    ko.applyBindings(window.tasksViewModel);
})();

