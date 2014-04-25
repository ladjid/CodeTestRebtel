using Machine.Specifications;
using CodeTestRebtel.Data.AuxiliaryMethod;

namespace CodeTestRebtel.Data.Tests.AuxiliaryMethodTest
{
    class when_reversing_a_string
    {
        private static string _strToReverse;
        private static string _returnedStr;
        private static string _reversedStr;
        
        private Establish context = () =>
            {
                _strToReverse = "reverse strings";
                _reversedStr = "sgnirts esrever";
            };

        private Because of = () =>
            {
                _returnedStr = AuxiliaryMethods.ReverseString(_strToReverse);
            };

        private It _returnedStr_should_equal__reversedStr = () => _returnedStr.ShouldEqual(_reversedStr);

    }
}
