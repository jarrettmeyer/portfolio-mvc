using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Ninject;
using NUnit.Framework;
using Portfolio.Lib.Commands;
using Portfolio.Lib.Queries;

namespace Portfolio.Lib
{
    [TestFixture]
    public class NinjectMediatorTests
    {
        IKernel kernel;
        IMediator mediator;

        [SetUp]
        public void Before_each_test()
        {
            kernel = new StandardKernel();
            kernel.Bind<ICommandHandler<TestCommand, string>>().To<TestCommandHandler>();
            kernel.Bind<IQueryHandler<TestQuery, int>>().To<TestQueryHandler>();
            mediator = new NinjectMediator(kernel);
        }

        [Test]
        public void Can_get_expected_request_result()
        {
            var result = mediator.Request(new TestQuery());
            result.Should().Be(123);
        }

        [Test]
        public void Can_get_expected_send_result()
        {
            var result = mediator.Send(new TestCommand());
            result.Should().Be("Hello, World!");
        }

        class TestCommand : ICommand<string>
        {            
        }

        class TestCommandHandler : ICommandHandler<TestCommand, string>
        {
            public string Handle(TestCommand command)
            {
                return "Hello, World!";
            }
        }

        class TestQuery : IQuery<int>
        {            
        }

        class TestQueryHandler : IQueryHandler<TestQuery, int>
        {
            public int Handle(TestQuery query)
            {
                return 123;
            }
        }
    }
}
