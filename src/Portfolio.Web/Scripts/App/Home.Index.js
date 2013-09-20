(function () {

    var TasksViewModel = function (tasks, pageSize) {
        var self = this;

        self.tasks = ko.observableArray(tasks);
        self.pageSize = ko.observable(pageSize);

        self.gridViewModel = new ko.grid.viewModel({
            data: self.tasks,
            columns: [
                { headerText: "Description", rowText: "Description" },
                { headerText: "Category", rowText: "Category" },
                { headerText: "Status", rowText: "Status" },
                { headerText: "Created On", rowText: "CreatedAt" },
                { headerText: "Due On", rowText: "DueOn" }
            ],
            pageSize: self.pageSize()
        });

        self.addTask = function() {

        };
    };

    var initialData = [
        { Id: 1, Description: "Test 1", Category: "A", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 2, Description: "Test 2", Category: "A", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 3, Description: "Test 3", Category: "A", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 4, Description: "Test 4", Category: "A", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 5, Description: "Test 5", Category: "A", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 6, Description: "Test 6", Category: "A", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 7, Description: "Test 7", Category: "A", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 8, Description: "Test 8", Category: "A", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 9, Description: "Test 9", Category: "A", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
    ];

    window.tasksViewModel = new TasksViewModel(initialData, 50);
    ko.applyBindings(window.tasksViewModel);
})();

