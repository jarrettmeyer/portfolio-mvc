using System;
using NUnit.Framework;

namespace Portfolio.Domain.ViewModels
{
    [TestFixture]
    public class TaskViewModelTests
    {
        [Test]
        public void IsPastDue_returns_false_when_DueOn_is_in_the_future()
        {
            var model = new TaskViewModel { DueOn = DateTime.Today.AddDays(1) };
            Assert.IsFalse(model.IsPastDue);
        }

        [Test]
        public void IsPastDue_returns_false_when_DueOn_is_null()
        {
            var model = new TaskViewModel { DueOn = null };
            Assert.IsFalse(model.IsPastDue);
        }

        [Test]
        public void IsPastDue_returns_true_when_DueOn_is_in_the_past()
        {
            var model = new TaskViewModel { DueOn = DateTime.Today.AddDays(-1) };
            Assert.IsTrue(model.IsPastDue);
        }
    }
}
