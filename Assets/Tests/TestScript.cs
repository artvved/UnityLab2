using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestScript
    {
        [Test]
        public void TestScriptSimplePasses()
        {
            SimpleBotInput playerInput = new GameObject().AddComponent<SimpleBotInput>();
            
           
        }


        [UnityTest]
        public IEnumerator TestScriptWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}