using UnityEngine;
using System.Collections;
using SharpUnit;

public class Player_Test : TestCase
{
	public override void SetUp()
    { 
    }

    /**
     * Dispose of test resources, called after each test.
     */
    public override void TearDown()
    {
    }

    /**
     * Sample test that passes.
     */
    [UnitTest]
    public void TestLeave()
    {
		Debug.Log("Testing Player leaving area");
		S_Player.zombieskilled = 10;
        Assert.Equal(1, S_Player.PlayerLeave(4.03f, -5.4f));
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.enabled = true;
		S_Player.zombieskilled = 0;
		GameObject.FindGameObjectWithTag("Door").renderer.enabled = false;
    }
}