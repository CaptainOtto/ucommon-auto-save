using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace CaptnJohn.Template.Tests
{
    /// <summary>
    /// Placeholder example test file for runtime test.
    /// </summary>
    public class TestRuntimeExample
    {

        [Test]
        public void TestRuntimeExampleSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        [UnityTest]
        public IEnumerator TestRuntimeExampleEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
