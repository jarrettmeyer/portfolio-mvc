(function() {

    if (!window.app) {
        window.app = {};
    }

    window.app.TasksFormView = (function() {
        function TasksFormView(options) {
            var defaults = {
                addTagSelector: "#add-tag",
                currentTagsSelector: "#current-tags",
                formSelector: "#task-form",
                tagSelectSelector: "#tag-select"
            };
            this.options = $.extend(defaults, options);
            this.isInitialized = false;
            this.$addTag = $(this.options.addTagSelector);
            this.$body = $("body");
            this.$currentTags = $(this.options.currentTagsSelector);
            this.$form = $(this.options.formSelector);
            this.$tagSelect = $(this.options.tagSelectSelector);
        }

        TasksFormView.prototype.bindAddTagButton = function () {
            this.$addTag.on("click", function () {                
                var tagValue = this.$tagSelect.val();
                var tagText = this.$tagSelect.find("option[value= " + tagValue + "]").text();
                console.log("Clicked " + this.options.addTagSelector + ". Selected Tag: (" + tagValue + ") " + tagText);
                var html = this.getTagHtml(tagValue, tagText);
                this.$currentTags.append(html);
            }.bind(this));
        };

        TasksFormView.prototype.bindFormSubmit = function () {
            this.$form.on("submit", function () {
                var counter = -1;
                this.$currentTags.find("div.tag").each(function(index, el) {
                    counter += 1;
                    this.updateInputName(el, counter);
                }.bind(this));
                return true;
            }.bind(this));
        };

        TasksFormView.prototype.bindRemoveTagButton = function() {
            this.$body.on("click", "button.remove-tag", function(event) {
                var $button = $(event.target);
                $button.parents("div.tag").remove();
            });
        };

        TasksFormView.prototype.getTagHtml = function (tagValue, tagText) {
            var html = "";
            html += "<div class=\"tag\">";
            html += "  <input type=\"hidden\" name=\"Tags[{{id}}].Id\" value=\"" + tagValue + "\" />";
            html += "  <input type=\"hidden\" name=\"Tags[{{id}}].Description\" value=\"" + tagText + "\" />";
            html += "  <span>" + tagText + "</span>";
            html += "  <button type=\"button\" class=\"btn btn-danger remove-tag\">Remove</button>";
            html += "</div>";
            return html;
        };

        TasksFormView.prototype.initialize = function () {
            if (!this.isInitialized) {
                this.bindAddTagButton();
                this.bindRemoveTagButton();
                this.bindFormSubmit();
                this.isInitialized = true;
            }            
        };

        TasksFormView.prototype.updateInputName = function (elementGroup, counter) {
            $(elementGroup).find("input").each(function (index, el) {
                var inputName = $(el).attr("name");
                inputName = inputName.replace("{{id}}", counter);
                $(el).attr("name", inputName);
            });
        };

        return TasksFormView;
    })();

    var tasksFormView = new app.TasksFormView();
    tasksFormView.initialize();
})();