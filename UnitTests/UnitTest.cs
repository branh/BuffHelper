namespace UnitTests
{
    using System.Diagnostics;
    using BuffHelper.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StatTypeTests
    {
        [TestMethod]
        public void AllStatTypesList()
        {
            for (int i = 0; i < StatTypes.AllStatsList.Length; ++i)
            {
                Debug.Assert(((IIndexable)StatTypes.AllStatsList[i]).index == i,
                    "Missing index " + i);
            }
        }
    }
}
