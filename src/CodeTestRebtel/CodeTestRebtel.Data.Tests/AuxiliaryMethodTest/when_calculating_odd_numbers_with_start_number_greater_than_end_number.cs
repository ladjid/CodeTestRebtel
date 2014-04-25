using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTestRebtel.Data.AuxiliaryMethod;
using Machine.Specifications;

namespace CodeTestRebtel.Data.Tests.AuxiliaryMethodTest
{
    class when_calculating_odd_numbers_with_start_number_greater_than_end_number
    {
        private static int _startNum;
        private static int _endNum;
        private static Exception _exception;
        
        private Establish context = () =>
        {
            _startNum = 100;
            _endNum = 0;
        };

        private Because of = () =>
        {
            _exception = Catch.Exception(() => AuxiliaryMethods.OddNumbers(_startNum, _endNum));
        };

        private It an_exception_should_be_thrown = () => _exception.Message.ShouldEqual("Start number cannot be greater than end number");
    }
}
