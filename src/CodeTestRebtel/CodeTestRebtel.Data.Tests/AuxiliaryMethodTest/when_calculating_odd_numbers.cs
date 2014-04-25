using System;
using Machine.Specifications;
using CodeTestRebtel.Data.AuxiliaryMethod;

namespace CodeTestRebtel.Data.Tests.AuxiliaryMethodTest
{
    class when_calculating_odd_numbers
    {
        private static int _startNum;
        private static int _endNum;
        private static string _returnedOddNumbers;
        private const string CorrectOddNumbersBetween0To100 = "0 2 4 6 8 10 12 14 16 18 20 22 24 26 28 30 32 34 36 38 40 42 44 46 48 50 52 54 56 58 60 62 64 66 68 70 72 74 76 78 80 82 84 86 88 90 92 94 96 98";

        private Establish context = () =>
            {
                _startNum = 0;
                _endNum = 100;
            };

        private Because of = () =>
            {
                _returnedOddNumbers = AuxiliaryMethods.OddNumbers(_startNum, _endNum);
            };

        private It _returnedOddNumbers_should_equal__correctOddNumbersBetween0To100 = () => _returnedOddNumbers.ShouldEqual(CorrectOddNumbersBetween0To100);
    }
}
