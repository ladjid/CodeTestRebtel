using CodeTestRebtel.Data.AuxiliaryMethod;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.AuxiliaryMethodTest
{
    class when_determining_the_2_power_with_a_number_that_fails
    {
        private static int _numberToCheck;
        private static bool _returnedBool;

        private Establish context = () =>
        {
            _numberToCheck = 5;
        };

        private Because of = () =>
        {
            _returnedBool = AuxiliaryMethods.Determine2Power(_numberToCheck);
        };

        private It should_be_true = () => _returnedBool.ShouldEqual(false);
    }
}
