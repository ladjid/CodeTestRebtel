using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTestRebtel.Data.AuxiliaryMethod;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.AuxiliaryMethodTest
{
    class when_replicating_with_a_count_thats_less_than_or_equal_zero
    {
        private static string _strToReplicate;
        private static int _count;
        private static Exception _exception;

        private Establish context = () =>
        {
            _strToReplicate = "replicate";
            _count = 0;
        };

        private Because of = () =>
        {
            _exception = Catch.Exception(() => AuxiliaryMethods.ReplicateString(_strToReplicate, _count));
        };

        private It an_exception_should_be_thrown = () => _exception.Message.ShouldEqual("Is not posible to replicate the string, because the count is less than or equal zero");
    }
}
