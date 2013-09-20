(function () {
    var defaultTableTemplateName = "ko_grid_table",
        defaultPagingTemplateName = "ko_grid_paging",
        tableTemplate,
        pagingTemplate,
        writeLog;

    ko.grid = {
        viewModel: function (configuration) {
            var self = this;

            self.data = configuration.data;
            self.columns = configuration.columns;
            self.pageSize = configuration.pageSize || 5;

            self.currentPageIndex = ko.observable(0);

            self.itemsOnCurrentPage = ko.computed(function () {
                var startIndex = self.pageSize * self.currentPageIndex();
                return self.data.slice(startIndex, startIndex + self.pageSize);
            });

            self.maxPageIndex = ko.computed(function () {
                var length = ko.utils.unwrapObservable(self.data).length;
                var value = Math.ceil(length / self.pageSize) - 1;
                writeLog("Computing max page index. Length: " + length);
                writeLog("Computing max page index. Page size: " + self.pageSize);
                writeLog("Computing max page index. Max page index: " + value);
                return value;
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

            self.isFirstLink = function () {
                return self.currentPageIndex() === 0;
            };

            self.isLastLink = function() {
                return self.currentPageIndex() === self.maxPageIndex();
            };

            self.disablePreviousLink = ko.computed(function() {
                return self.isFirstLink();
            });
            
            self.disableNextLink = ko.computed(function () {
                return self.isLastLink();
            });

            self.applySorting = function (column, ascOrDesc) {
                ascOrDesc = ascOrDesc || "asc";
                ascOrDesc = ascOrDesc.toLowerCase();
                if (ascOrDesc === "asc") {
                    self.data.sort(function(x, y) {
                        return x[column] < y[column] ? -1 : 1;
                    });
                } else {
                    self.data.sort(function(x, y) {
                        return x[column] < y[column] ? 1 : -1;
                    });
                }
            };
        }
    };

    var templateEngine = new ko.nativeTemplateEngine();

    templateEngine.addTemplate = function(templateName, templateMarkup) {
        document.write("<script type=\"text/html\" id=\"" + templateName + "\">" + templateMarkup + "</script>");
    };

    tableTemplate = "<table class=\"ko-grid-table table table-condensed\">\
                       <thead>\
                         <tr data-bind=\"foreach: columns\">\
                           <th data-bind=\"text: headerText\"></th>\
                         </tr>\
                       </thead>\
                       <tbody data-bind=\"foreach: itemsOnCurrentPage\">\
                         <tr data-bind=\"foreach: $parent.columns\">\
                           <td data-bind=\"text: (typeof rowText === 'function') ? rowText($parent) : $parent[rowText]\"></td>\
                         </tr>\
                       </tbody>\
                     </table>";

    pagingTemplate = "<div class=\"ko-grid-paging\">\
                        <ul class=\"pagination\">\
                          <li data-bind=\"css: { disabled: $root.disablePreviousLink() }\">\
                            <a href=\"#\" data-bind=\"click: function() { $root.goToPreviousLink(); }\">&laquo;</a>\
                          </li>\
                          <!-- ko foreach: ko.utils.range(0, maxPageIndex) -->\
                            <li data-bind=\"css: { active: $data === $root.currentPageIndex() }\">\
                              <a href=\"#\" data-bind=\"text: $data + 1, click: function() { $root.currentPageIndex($data); }\"></a>\
                            </li>\
                          <!-- /ko -->\
                          <li data-bind=\"css: { disabled: $root.disableNextLink() }\">\
                            <a href=\"#\" data-bind=\"click: function() { $root.goToNextLink(); }\">&raquo;</a>\
                          </li>\
                        </ul>\
                      </div>";

    templateEngine.addTemplate(defaultTableTemplateName, tableTemplate);

    templateEngine.addTemplate(defaultPagingTemplateName, pagingTemplate);
    
    ko.bindingHandlers.grid = {
        init: function () {
            return { 'controlsDescendantBindings': true };
        },        
        update: function (element, viewModelAccessor, allBindingsAccessor) {
            var viewModel = viewModelAccessor(), allBindings = allBindingsAccessor();

            while (element.firstChild) {
                ko.removeNode(element.firstChild);
            }
                
            var gridTableTemplate = allBindings.gridTableTemplate || defaultTableTemplateName,
                gridPagingTemplate = allBindings.gridPagingTemplate || defaultPagingTemplateName;

            var tableContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(gridTableTemplate, viewModel, { templateEngine: templateEngine }, tableContainer, "replaceNode");

            var pagingContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(gridPagingTemplate, viewModel, { templateEngine: templateEngine }, pagingContainer, "replaceNode");
        }
    };

    writeLog = function (message) {
        if (window.console && window.console.log) {
            window.console.log(message);
        }
    };

})();