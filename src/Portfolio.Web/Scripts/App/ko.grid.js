(function () {
    var defaultTableName = "ko_grid_table",
        defaultPagingName = "ko_grid_paging";

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

            }, self);

            self.maxPageIndex = ko.computed(function () {
                return Math.ceil(ko.utils.unwrapObservable(self.data).length / self.pageSize) - 1;
            }, self);
        }
    };

    var templateEngine = new ko.nativeTemplateEngine();

    templateEngine.addTemplate = function(templateName, templateMarkup) {
        document.write("<script type=\"text/html\" id=\"" + templateName + "\">" + templateMarkup + "</script>");
    };

    templateEngine.addTemplate(defaultTableName, "");

    templateEngine.addTemplate(defaultPagingName, "");
    
    ko.bindingHandlers.grid = {
        init: function () {
            return { 'controlsDescendantBindings': true };
        },
        // This method is called to initialize the node, and will also be called again if you change what the grid is bound to
        update: function (element, viewModelAccessor, allBindingsAccessor) {
            var viewModel = viewModelAccessor(), allBindings = allBindingsAccessor();

            // Empty the element
            while (element.firstChild) {
                ko.removeNode(element.firstChild);
            }
                

            // Allow the default templates to be overridden
            var gridTableTemplate = allBindings.gridTableTemplate || defaultTableName,
                gridPagingTemplate = allBindings.gridPagingTemplate || defaultPagingName;

            // Render the main grid
            var tableContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(gridTableTemplate, viewModel, { templateEngine: templateEngine }, tableContainer, "replaceNode");

            // Render the page links
            var pagingContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(gridPagingTemplate, viewModel, { templateEngine: templateEngine }, pagingContainer, "replaceNode");
        }
    };

})();