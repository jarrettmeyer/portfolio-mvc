using System.Collections.Generic;
using Moq;
using Portfolio.Lib.Services;

namespace Portfolio
{
    public class MockServiceLocator : ServiceLocator
    {
        private static readonly Dictionary<string, object> mocks = new Dictionary<string, object>();

        public static Mock<TService> GetMock<TService>() where TService : class 
        {
            string typeName = typeof(TService).Name;
            Mock<TService> mock;
            if (mocks.ContainsKey(typeName))
            {
                object obj = mocks[typeName];
                mock = (Mock<TService>)obj;                
            }
            else
            {
                mock = new Mock<TService> { DefaultValue = DefaultValue.Mock };
                mocks.Add(typeName, mock);                
            }
            return mock;
        }

        public override TService GetService<TService>()
        {            
            Mock<TService> mock = GetMock<TService>();
            return mock.Object;
        }
    }
}
