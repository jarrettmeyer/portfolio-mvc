using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using NUnit.Framework;
using Portfolio.Lib.ViewModels;
using Portfolio.ViewModels;

namespace Portfolio.Web.ViewModels
{
    [TestFixture]
    public class FlashMessageCollectionTests
    {
        private FlashMessageCollection flashMessages;
        private TempDataDictionary tempData;

        [SetUp]
        public void before_each_test()
        {
            tempData = new TempDataDictionary();
            flashMessages = new FlashMessageCollection(tempData);
        }

        [Test]
        public void adds_key_to_temp_data()
        {
            var flashData = GetFlashMessagesFromTempData();
            flashData.Should().BeAssignableTo<List<FlashMessage>>();
        }

        [Test]
        public void key_is_empty_by_default()
        {
            var flashData = GetFlashMessagesFromTempData();
            flashData.Count().Should().Be(0);
        }

        [Test]
        public void can_add_success_message()
        {
            flashMessages.AddSuccessMessage("This is a test success message");
            flashMessages.Count().Should().Be(1);
        }

        private IEnumerable<FlashMessage> GetFlashMessagesFromTempData()
        {
            return tempData["FlashMessageCollection"] as List<FlashMessage>;
        }
    }
}
