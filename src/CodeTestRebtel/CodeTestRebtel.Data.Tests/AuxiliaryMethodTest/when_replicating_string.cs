using Machine.Specifications;
using CodeTestRebtel.Data.AuxiliaryMethod;

namespace CodeTestRebtel.Data.Tests.AuxiliaryMethodTest
{
    class when_replicating_string
    {
        private static string _strToReplicate;
        private static string _replicatedStr;
        private static string _returnedStr;
        private static int _count;

        private Establish context = () =>
            {
                _strToReplicate = "replicate";
                _replicatedStr = "replicatereplicatereplicate";
                _count = 3;
            };

        private Because of = () =>
            {
                _returnedStr = AuxiliaryMethods.ReplicateString(_strToReplicate, _count);
            };

        private It _returnedStr_should_equal__replicatedStr = () => _returnedStr.ShouldEqual(_replicatedStr);
    }
}
