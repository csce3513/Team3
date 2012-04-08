using System;
using NUnit.Framework;
namespace Testing
{
	[TestFixture()]
	public class Test
	{	
		[Test()]
		public void TestReload ()
		{
			TestFunctions tester = new TestFunctions();
			float result = tester.ReloadGun(0, 20);
			Assert.AreEqual(10, result);
			
		}
		
		[Test()]
		public void TestShot ()
		{
			TestFunctions tester = new TestFunctions();
			float result = tester.ShootGun(10, 1);
			Assert.AreEqual(9, result);
			
		}
		
		
	}
}

