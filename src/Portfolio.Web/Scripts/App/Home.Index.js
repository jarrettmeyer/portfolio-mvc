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

        self.categories = ko.observableArray([]);

        self.currentTask = ko.observable();

        self.addTask = function() {
            var newModel = new TaskViewModel();
        };
    };

    var TaskViewModel = function (task) {
        var self = this;

        task = task || {};
        self.data = task;
        self.id = task.id || 0;

        self.description = ko.observable(task.description);

        self.selectedCategory = ko.observable(0);

        self.selectedStatus = ko.observable("NEW");

        self.title = ko.computed(function () {
            return (self.id === 0) ? "Create New Task" : "Edit Task";
        });
    };

    $.get("/tasks", function (result) {
        window.tasksViewModel.tasks(result);
    });

    $.get("/categories", function(result) {
        window.tasksViewModel.categories(result);
    });

    window.tasksViewModel = new TasksViewModel([], 5);
    ko.applyBindings(window.tasksViewModel);
})();

