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
                           <td data-bind=\"text: $parent[rowText]\"></td>\
                         </tr>\
                       </tbody>\
                     </table>";

    pagingTemplate = "";
    //<td data-bind=\"text: (typeof rowText === 'function') ? rowText($parent) : $parent[rowText] \"></td>\

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