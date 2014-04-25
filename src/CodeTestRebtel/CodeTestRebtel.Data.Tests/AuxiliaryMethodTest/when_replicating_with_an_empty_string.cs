using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTestRebtel.Data.AuxiliaryMethod;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.AuxiliaryMethodTest
{
    class when_replicating_with_an_empty_string
    {
        private static string _strToReplicate;
        private static int _count;
        private static Exception _exception;

        private Establish context = () =>
        {
            _strToReplicate = string.Empty;
            _count = 3;
        };

        private Because of = () =>
        {
            _exception = Catch.Exception(()=>AuxiliaryMethods.ReplicateString(_strToReplicate, _count));
        };

        private It an_exception_should_be_thrown = () => _exception.Message.ShouldEqual("The string you trying to Replicate is null or empty");
    }
}
