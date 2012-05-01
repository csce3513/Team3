using UnityEngine;
using System.Collections;
using System;
using SharpUnit;

public class Store_Test : TestCase
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
    public void TestBuyAmmo()
    {
		Debug.Log("Testing buying ammo");
		S_Player.cash = 200;
		S_Player.ammoleft = 0;
		S_ShopGUI.BuyAmmo(10);
        Assert.Equal(1, S_Player.ammoleft);
    }
	
	[UnitTest]
    public void TestBuyLives()
    {
		Debug.Log("Testing buying Lives");
		S_Player.cash = 200;
		S_Player.playerlives = 0;
		S_ShopGUI.BuyLife();
        Assert.Equal(1, S_Player.playerlives);
    }
	
//	[UnitTest]
//	public void TestLeaveStore()
//	{
//		Debug.Log("Testing leaving store");
//		Assert.True(S_ShopGUI.);
//		
//	}
	
		[UnitTest]
	public void TestLeaveStore()
	{
		Debug.Log("Test the file is exist");
		Assert.Equals("", S_SubmitName.UpdateName("Elizabeth"));
	}
       
}
