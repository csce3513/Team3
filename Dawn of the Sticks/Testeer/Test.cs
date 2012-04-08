using System;
using UnityEngine;
using NUnit.Framework;
namespace tester
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestReload ()
		{
			S_Player.Initial();
			S_Player.ShootGun(1);
			S_Player.ShootGun(1);
			S_Player.ReloadGun();
			Assert.AreEqual(10, S_Player.GetBullets());
		}
		
		[Test()]
		public void TestShoot ()
		{
			S_Player.Initial();
			S_Player.ShootGun(1);
			Assert.AreEqual(9, S_Player.GetBullets());
		}
		
		[Test()]
		public void TestLeave ()
		{
			Assert.AreEqual(1, S_Player.PlayerLeave(4.03f, -5.4f));
		}
		
		[Test()]
		public void TestKill ()
		{
			S_Player.Initial();
			S_Player.KillPlayer();
			Assert.AreEqual(1, S_Player.GetLives());
		}

}

