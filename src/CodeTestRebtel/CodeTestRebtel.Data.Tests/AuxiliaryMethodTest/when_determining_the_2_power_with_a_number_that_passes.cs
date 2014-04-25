using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using CodeTestRebtel.Data.AuxiliaryMethod;

namespace CodeTestRebtel.Data.Tests.AuxiliaryMethodTest
{
    class when_determining_the_2_power_with_a_number_that_passes
    {
        private static int _numberToCheck;
        private static bool _returnedBool;

        private Establish context = () =>
            {
                _numberToCheck = 8;
            };

        private Because of = () =>
            {
                _returnedBool = AuxiliaryMethods.Determine2Power(_numberToCheck);
            };

        private It should_be_true = () => _returnedBool.ShouldEqual(true);
    }
}
