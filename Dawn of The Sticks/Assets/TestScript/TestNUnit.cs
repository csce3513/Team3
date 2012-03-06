using NUnit.Framework;
using System;
namespace AssemblyCSharp
{
	[TestFixture()]
	public class TestNUnit
	{
		[Test()]
		//Intended to fail
		public void TestBulletLeft()
		{
			Assert.AreEqual(2, S_Player.ReloadGun(10f));
		}
		[Test()]
		public void TestName()
		{
			string temp = S_HighScore.UpdateName("adfdsafd");
			Assert.IsNotNull(temp,"Check not null String");
		}
		
		[Test()]
		//Pass test
		public void TestNULLName()
		{
			string temp = S_HighScore.UpdateName("");
			Assert.IsEmpty(temp,"Check null String");
		}
		[Test()]
		//Pass test
		public void TestZeroScore()
		{
			Assert.AreEqual(0,S_HighScore.UpdateScore());
		}
	}
}

