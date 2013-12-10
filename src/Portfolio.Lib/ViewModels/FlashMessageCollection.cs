using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Portfolio.Lib.ViewModels
{
    [Serializable]
    public class FlashMessageCollection : IEnumerable<FlashMessage>
    {
        private readonly List<FlashMessage> flashMessages;
        private readonly TempDataDictionary tempData;
        private static readonly string tempDataKey = typeof(FlashMessageCollection).Name;

        public FlashMessageCollection(TempDataDictionary tempData)
        {
            this.tempData = tempData;
            flashMessages = new List<FlashMessage>();
            InitializeTempData();
        }

        public void Add(string key, string message)
        {
            flashMessages.Add(new FlashMessage(key, message));

            // By default, reading a temp data key will delete the object from temp data.
            // Keep the key until the collection of messages is iterated.
            tempData.Keep(tempDataKey);
        }

        public void AddErrorMessage(string message)
        {
            Add("danger", message);
        }

        public void AddSuccessMessage(string message)
        {
            Add("success", message);            
        }

        public IEnumerator<FlashMessage> GetEnumerator()
        {
            try
            {
                return flashMessages.GetEnumerator();
            }
            finally
            {
                // Remove the temp data key when we iterate through the list of messages.
                tempData.Remove(tempDataKey);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void InitializeTempData()
        {
            var messages = tempData[tempDataKey] as List<FlashMessage>;
            if (messages == null)            
                tempData.Add(tempDataKey, flashMessages);
            else
                flashMessages.AddRange(messages);
        }
    }
}