using System.Web.Mvc;
using FluentAssertions;
using NUnit.Framework;
using Portfolio.Lib.Actions;

namespace Portfolio.Web.Lib.Actions
{
    [TestFixture]
    public class AbstractActionTests
    {
        private IAction action;

        [Test]
        public void can_use_given_temp_data_dictionary()
        {
            var tempData = new TempDataDictionary();

            action = new FakeAction()
                .WithTempData(tempData);

            action.TempData.ShouldBeEquivalentTo(tempData);
        }

        internal class FakeAction : AbstractAction
        {
            public bool IsExecuted { get; private set; }

            public override void Execute()
            {
                IsExecuted = true;
            }
        }
    }
}
