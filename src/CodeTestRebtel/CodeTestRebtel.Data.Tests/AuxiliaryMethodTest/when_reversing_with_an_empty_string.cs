using System;
using CodeTestRebtel.Data.AuxiliaryMethod;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.AuxiliaryMethodTest
{
    class when_reversing_with_an_empty_string
    {
        private static string _strToReverse;
        private static Exception _exception;

        private Establish context = () =>
        {
            _strToReverse = string.Empty;
        };

        private Because of = () =>
        {
            _exception = Catch.Exception(() => AuxiliaryMethods.ReverseString(_strToReverse));
        };

        private It an_exception_should_be_thrown = () => _exception.Message.ShouldEqual("The string you trying to reverse is null or empty");
    }
}
