namespace UnitTests
{
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pathfinder.Utility.Data;

    [TestClass]
    public class StatTypeTests
    {
        [TestMethod]
        public void AllIndexesValid()
        {
            for(int i = 0; i < StatTypes.AllStatsList.Length; ++i)
            {
                Debug.Assert(((IIndexable)StatTypes.AllStatsList[i]).index == i, 
                    "All Stat Types index does not match. Index: " + i);
            }
            StatTypeTests.verifyMetaAttribute(StatTypes.AC);
            StatTypeTests.verifyMetaAttribute(StatTypes.touchAC);
            StatTypeTests.verifyMetaAttribute(StatTypes.flatfootedAC);
        }

        private static void verifyMetaAttribute(StatType attribute)
        {
            IIndexable indexable = attribute as IIndexable;
            Debug.Assert(indexable == null || indexable.index < 0,
                attribute.Name + " is a meta-attribute and should not be indexable");
        }
    }
}
