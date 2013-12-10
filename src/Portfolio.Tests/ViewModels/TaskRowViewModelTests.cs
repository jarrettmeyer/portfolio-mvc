using System;
using FluentAssertions;
using NUnit.Framework;
using Portfolio.Lib.Models;
using Portfolio.Lib.ViewModels;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class TaskRowViewModelTests
    {
        private TaskRowViewModel model;
        private Task task;

        [Test]
        public void IsDueToday_is_true_when_task_is_due_today()
        {
            task = new Task { DueOn = DateTime.Today };
            model = new TaskRowViewModel(task);
            model.IsDueToday.Should().BeTrue();
        }

        [Test]
        public void IsPastDue_is_true_when_task_is_due_yesterday()
        {
            task = new Task { DueOn = DateTime.Today.AddDays(-1) };
            model = new TaskRowViewModel(task);
            model.IsPastDue.Should().BeTrue();
        }
    }
}
