using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Portfolio.Lib.Rules;
using Portfolio.Models;
using Portfolio.Web.Models;

namespace Portfolio.Web.Lib.Rules
{
    [TestFixture]
    public class WorkflowValidatorImplTests
    {
        private Status status1;
        private Status status2;
        private Status status3;
        private IWorkflowValidator workflowValidator;


        [SetUp]
        public void BeforeEachTest()
        {
            status1 = new Status { Id = "1" };
            status2 = new Status { Id = "2" };
            status3 = new Status { Id = "3" };
            var workflows = new List<StatusWorkflow>
            {
                new StatusWorkflow { FromStatus = status1, ToStatus = status2 },
                new StatusWorkflow { FromStatus = status2, ToStatus = status3 },
            };
            workflowValidator = new WorkflowValidatorImpl(workflows);
        }

        [Test]
        public void returns_false_when_workflow_is_not_allowed()
        {
            bool result = workflowValidator.IsValidTransition("1", "3");
            result.Should().BeFalse();
        }

        [Test]
        public void returns_true_when_workflow_is_allowed()
        {
            bool result = workflowValidator.IsValidTransition("1", "2");
            result.Should().BeTrue();
        }
    }
}
