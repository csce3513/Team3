using System.Collections;

public class TestFunctions{
	
	//Reloads the Gun
	public float ReloadGun(float ammoingun, float ammoleft)
	{
		while(ammoleft > 0 && ammoingun < 10)
					{
					ammoingun += 1;
					ammoleft -= 1;
					}
		return ammoingun;
	}
	
	 public	float ShootGun(float currentammo, float firerate)
	{
		//creates the bullet
			//Vector3 position = new Vector3(transform.position.x + transform.localScale.x / 2, transform.position.y, transform.position.z);
			
			if (firerate > .2f)
			{
			firerate = 0;
			//Instantiate(P_Bullet, position, transform.rotation);
			currentammo -= 1;
			}
		return currentammo;
	}
	
	
}

