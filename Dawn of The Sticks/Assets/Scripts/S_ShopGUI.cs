using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;

public class S_ShopGUI : MonoBehaviour
{   
	float amo1 = 10,// Define values of amo here 
	    amo2 = 20,
	    amo3 = 30,
	    amo4 = 40;
	float amo1_count=0,
	    amo2_count=0,
	    amo3_count=0,
	    amo4_count=0;
	static public float money = S_Player.cash; //<---- pass money variable here
	bool flag1 = false,// Define as key is down, they will change to true
	     flag2 = false,
	     flag3 = false,
		 flag5 = false,
	     flag4 = false;
	//bool finishShopping = false;
	public string Total;
	
	public static float UpdateMoney(float amo)
	{
		return S_Player.cash = S_Player.cash - amo;
	}
   
	// Use this for initialization
	void Start ()
	{
		amo1_count=S_Player.ammoleft;//<--- Pass variable that helds value of player's amo here
	    amo2_count=0;
	    amo3_count=0;
	    amo4_count=0;
	}

	void OnGUI()
	{
		Total = GUI.TextArea(new Rect(0.8f*Screen.width,0.05f*Screen.height,
		                       150,20), Total);
		if(GUI.Button(new Rect(0.041f*Screen.width,0.45f*Screen.height,
		                       200,20), "AK-47 Ammo(1 bullet) - 10G"))//<-- Change name of amo at AMO1
		{
			BuyAmmo(amo1);
			//funcction to render picture of bullet can put here
			
			
			flag1 = true;
		}
		if(GUI.Button(new Rect(0.3f*Screen.width,0.45f*Screen.height,
		                       150,20), "AMO2 - 20G"))//<-- Change name of amo at AMO2
		{
			BuyAmmo(amo2);
			flag2 = true;
		}
		if(GUI.Button(new Rect(0.5f*Screen.width,0.45f*Screen.height,
		                       150,20), "AMO3 - 30G"))//<-- Change name of amo at AMO3
		{
			
			BuyAmmo(amo3);
			flag3 = true;
		}
		if(GUI.Button(new Rect(0.8f*Screen.width,0.45f*Screen.height,
		                       150,20), "AMO4 - 40G"))//<-- Change name of amo at AMO4
		{
			
			BuyAmmo(amo4);
			flag4 = true;
		}
		if(GUI.Button(new Rect(0.15f*Screen.width,0.83f*Screen.height,
		                       150,20), "Buy Life - 100G"))
		{
			
			BuyLife();
			flag5 = true;
		}
	}
	
	public static void BuyAmmo(float ammocost)
	{
		if(S_Player.cash >= ammocost)
			{
				UpdateMoney(ammocost);
				S_Player.ammoleft++;
			}
	}
	
	public static void BuyLife()
	{
		if(S_Player.cash >= 100)
			{
				UpdateMoney(100);
				S_Player.playerlives++;
			}
	}
	
	// Update is called once per frame
	void Update ()
	{			
		Total = S_Player.cash.ToString()+ "G";
	}
}