using UnityEngine;
using System.Collections;
using System;
using SharpUnit;

public class Test_MainMenu : TestCase
{

	 [UnitTest]
	public void TestQuit()
	{
		Debug.Log("Test quit button");
		Assert.False(MenuObject.isQuit);
	}
	
	[UnitTest]
	public void TestStart()
	{
		Debug.Log("Test start button");
		Assert.False(MenuObject.isStartGame);
	}
	
	[UnitTest]
	public void TestHighScore()
	{
		Debug.Log("Test high score button");
		Assert.False(MenuObject.isHighScore);
	}
	
	[UnitTest]
	public void TestCredit()
	{
		Debug.Log("Test credit button");
		Assert.False(MenuObject.isCredits);
	}
	
	
}
