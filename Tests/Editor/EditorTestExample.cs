using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace CaptnJohn.Template.Editor.Tests
{  
    /// <summary>
    /// Placeholder editor test example.
    /// </summary>
    public class TestEditorExample
    {

      [Test]
      public void TestEditorExampleSimplePasses()
      {
        // Use the Assert class to test conditions
      }

      [UnityTest]
      public IEnumerator TestEditorExampleWithEnumeratorPasses()
      {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
      }
    }
}
