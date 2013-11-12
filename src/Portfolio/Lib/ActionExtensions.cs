using System.Web.Mvc;
using Portfolio.Lib.Actions;

namespace Portfolio.Lib
{
    public static class ActionExtensions
    {
        public static TAction WithTempData<TAction>(this TAction action, TempDataDictionary tempData) where TAction : IAction
        {
            action.TempData = tempData;
            return action;
        }
    }
}