(function () {
    var editTaskUrl = "/tasks/{id}/edit",
        getCategoriesUrl = "/categories",
        getPageSizeUrl = "/settings/pagesize",
        getTasksUrl = "/tasks",
        newTaskUrl = "/tasks/new",
        $taskModalDialog = $("#task-modal-dialog");

    $taskModalDialog.modal({
        keyboard: true,
        show: false
    });

    var TasksViewModel = function (tasks, pageSize) {
        var self = this;

        self.isAddingTask = false,
        self.isEditingTask = false;

        self.categories = ko.observableArray([]);

        self.currentPageIndex = ko.observable(0);

        self.currentTask = ko.observable();

        self.tasks = ko.observableArray(tasks);

        self.pageSize = ko.observable(pageSize);

        self.maxPageIndex = ko.computed(function () {
            var length = ko.utils.unwrapObservable(self.tasks).length;
            var value = Math.ceil(length / self.pageSize()) - 1;
            return value;
        });

        self.addTask = function () {
            var newTaskModel = new TaskViewModel();
            self.currentTask(newTaskModel);
            $taskModalDialog.modal("show");
            self.isAddingTask = true;
        };

        self.cancel = function () {
            self.currentTask(null);
            $taskModalDialog.modal("hide");
            self.isAddingTask = false;
            self.isEditingTask = false;
        };

        self.editTask = function (task) {
            self.currentTask(task);
            $taskModalDialog.modal("show");
            self.isEditingTask = true;
        };

        self.isFirstLink = function () {
            return self.currentPageIndex() === 0;
        };

        self.isLastLink = function () {
            return self.currentPageIndex() === self.maxPageIndex();
        };

        self.disableNextLink = ko.computed(function () {
            return self.isLastLink();
        });

        self.disablePreviousLink = ko.computed(function () {
            return self.isFirstLink();
        });

        self.goToPreviousLink = function () {
            if (!self.isFirstLink()) {
                var current = self.currentPageIndex();
                self.currentPageIndex(current - 1);
            }
        };

        self.goToNextLink = function () {
            if (!self.isLastLink()) {
                var current = self.currentPageIndex();
                self.currentPageIndex(current + 1);
            }
        };

        self.itemsOnCurrentPage = ko.computed(function () {
            var startIndex = self.pageSize() * self.currentPageIndex();
            return self.tasks.slice(startIndex, startIndex + self.pageSize());
        });

        self.save = function () {
            $taskModalDialog.modal("hide");
            var data = self.currentTask().getData();
            var url = self.currentTask().getUrl();            
            $.post(url, data, function (result) {
                if (self.currentTask().isNewTask()) {
                    self.tasks.push(new TaskViewModel(result));
                }
                self.currentTask(null);
            });
        };
    };

    /**
     *  
     */
    var TaskViewModel = function (task) {
        var self = this;
        task = task || {};

        self.category = ko.observable(task.Category.Description);
        self.createdAt = ko.observable(parseMvcDate(task.CreatedAt));
        self.description = ko.observable(task.Description || "");
        self.dueOn = ko.observable(parseMvcDate(task.DueOn));
        self.id = ko.observable(task.Id || 0);
        self.selectedCategory = ko.observable(task.Category);

        self.getEditUrl = function () {
            var url = editTaskUrl.replace("{id}", self.id());
            return url;
        };

        self.title = ko.computed(function () {
            return (self.id === 0) ? "Create New Task" : "Edit Task";
        });

        self.formattedCreatedAt = ko.computed(function () {
            return formatDate(self.createdAt());
        });

        self.formattedDueOn = ko.computed(function() {
            return formatDate(self.dueOn());
        });

        self.getData = function () {
            var data = {
                Category: self.selectedCategory().Id,
                Description: self.description(),
                DueOn: self.dueOn(),
                Id: self.id
            };
            return data;
        };

        self.getUrl = function () {
            if (self.id === 0) {
                return newTaskUrl;
            } else {
                return self.getEditUrl();
            }
        };

        self.isNewTask = function () {
            return self.id === 0;
        };
    };

    window.tasksViewModel = new TasksViewModel([], 5);
    ko.applyBindings(window.tasksViewModel);

    $.get(getTasksUrl, function (result) {
        for (var i = 0, len = result.length; i < len; i += 1) {
            window.tasksViewModel.tasks.push(new TaskViewModel(result[i]));
        }        
    });

    $.get(getCategoriesUrl, function (result) {
        window.tasksViewModel.categories(result);
    });

    $.get(getPageSizeUrl, function (result) {
        window.tasksViewModel.pageSize(result);
    });
})();