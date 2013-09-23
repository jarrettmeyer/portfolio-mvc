(function () {
    var defaultTableTemplateName = "ko_grid_table",
        defaultPagingTemplateName = "ko_grid_paging",
        tableTemplate,
        pagingTemplate,
        writeLog;

    

    //var templateEngine = new ko.nativeTemplateEngine();

    //templateEngine.addTemplate = function(templateName, templateMarkup) {
    //    document.write("<script type=\"text/html\" id=\"" + templateName + "\">" + templateMarkup + "</script>");
    //};

    //tableTemplate = "<table class=\"ko-grid-table table table-condensed\">\
    //                   <thead>\
    //                     <tr data-bind=\"foreach: columns\">\
    //                       <th data-bind=\"text: headerText\"></th>\
    //                     </tr>\
    //                   </thead>\
    //                   <tbody data-bind=\"foreach: itemsOnCurrentPage\">\
    //                     <tr data-bind=\"foreach: $parent.columns\">\
    //                       <td data-bind=\"text: (typeof rowText === 'function') ? rowText($parent) : $parent[rowText]\"></td>\
    //                     </tr>\
    //                   </tbody>\
    //                 </table>";

    //pagingTemplate = "<div class=\"ko-grid-paging\">\
    //                    <ul class=\"pagination\">\
    //                      <li data-bind=\"css: { disabled: $root.disablePreviousLink() }\">\
    //                        <a href=\"#\" data-bind=\"click: function() { $root.goToPreviousLink(); }\">&laquo;</a>\
    //                      </li>\
    //                      <!-- ko foreach: ko.utils.range(0, maxPageIndex) -->\
    //                        <li data-bind=\"css: { active: $data === $root.currentPageIndex() }\">\
    //                          <a href=\"#\" data-bind=\"text: $data + 1, click: function() { $root.currentPageIndex($data); }\"></a>\
    //                        </li>\
    //                      <!-- /ko -->\
    //                      <li data-bind=\"css: { disabled: $root.disableNextLink() }\">\
    //                        <a href=\"#\" data-bind=\"click: function() { $root.goToNextLink(); }\">&raquo;</a>\
    //                      </li>\
    //                    </ul>\
    //                  </div>";

    //templateEngine.addTemplate(defaultTableTemplateName, tableTemplate);

    //templateEngine.addTemplate(defaultPagingTemplateName, pagingTemplate);
    
    //ko.bindingHandlers.grid = {
    //    init: function () {
    //        return { 'controlsDescendantBindings': true };
    //    },        
    //    update: function (element, viewModelAccessor, allBindingsAccessor) {
    //        var viewModel = viewModelAccessor(), allBindings = allBindingsAccessor();

    //        while (element.firstChild) {
    //            ko.removeNode(element.firstChild);
    //        }
                
    //        var gridTableTemplate = allBindings.gridTableTemplate || defaultTableTemplateName,
    //            gridPagingTemplate = allBindings.gridPagingTemplate || defaultPagingTemplateName;

    //        var tableContainer = element.appendChild(document.createElement("DIV"));
    //        ko.renderTemplate(gridTableTemplate, viewModel, { templateEngine: templateEngine }, tableContainer, "replaceNode");

    //        var pagingContainer = element.appendChild(document.createElement("DIV"));
    //        ko.renderTemplate(gridPagingTemplate, viewModel, { templateEngine: templateEngine }, pagingContainer, "replaceNode");
    //    }
    //};

    //writeLog = function (message) {
    //    if (window.console && window.console.log) {
    //        window.console.log(message);
    //    }
    //};

})();