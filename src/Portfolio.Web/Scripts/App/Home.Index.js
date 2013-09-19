(function () {

    var TasksViewModel = function (tasks, pageSize) {
        var self = this;

        self.tasks = ko.observableArray(tasks);
        self.pageSize = ko.observable(pageSize);

        self.grid = new ko.grid.viewModel({
            data: self.tasks,
            columns: [
                { headerText: "Description", rowText: "Description" },
                { headerText: "Created On", rowText: "CreatedAt" },
                { headerText: "Due On", rowText: "DueOn" }
            ],
            pageSize: self.pageSize
        });
    };

    var initialData = [
        { Id: 1, Description: "Test 1", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 2, Description: "Test 2", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 3, Description: "Test 3", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 4, Description: "Test 4", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 5, Description: "Test 5", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 6, Description: "Test 6", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 7, Description: "Test 7", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 8, Description: "Test 8", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },
        { Id: 9, Description: "Test 9", CreatedAt: new Date(), DueOn: new Date(2013, 11, 31) },        
    ];

    window.tasksViewModel = new TasksViewModel(initialData, 50);
})();

