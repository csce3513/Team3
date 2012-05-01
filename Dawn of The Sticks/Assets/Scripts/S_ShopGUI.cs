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
	string mousehover = GUI.tooltip;
	static public float money = S_Player.cash; //<---- pass money variable here
	bool flag1 = false,// Define as key is down, they will change to true
	     flag2 = false,
	     flag3 = false,
		 flag5 = false,
		 flag6 = false,
		 flag7 = false,
		 flag8 = false,
		 flag9 = false,
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
		GUI.contentColor = Color.blue;
		Total = GUI.TextArea(new Rect(0.8f*Screen.width,0.05f*Screen.height,
		                       150,20), Total);
		if(GUI.Button(new Rect(0.041f*Screen.width,0.32f*Screen.height,
		                       150,20), new GUIContent("Buy AK-47 - 20G","Buy AK-47 - 20G")))//<-- Change name of amo at AMO3
		{
			if(S_Player.cash >= 200 && S_Player.currentgun != 1)
			{
			S_Player.cash = S_Player.cash - 20;
			S_Player.currentgun = 1;
			}
			flag9 = true;
		}
		if(GUI.Button(new Rect(0.041f*Screen.width,0.45f*Screen.height,
		                       150,20), "AMMO - 10G"))//<-- Change name of amo at AMO1
		{	if(S_Player.currentgun == 1)
			{
			BuyAmmo(amo1);
			}
			//funcction to render picture of bullet can put here
			
			
			flag1 = true;
		}
		if(GUI.Button(new Rect(0.3f*Screen.width,0.32f*Screen.height,
		                       150,20), new GUIContent("Buy G36K - 60G", "Buy G36K - 60G")))//<-- Change name of amo at AMO3
		{
			if(S_Player.cash >= 60 && S_Player.currentgun != 2)
			{
			S_Player.cash = S_Player.cash - 60;
				S_Player.ammoleft += 10;
				S_Player.currentgun = 2;
				S_Player.rateofgun = 0.1f;
				
			}
			flag7 = true;
		}
		if(GUI.Button(new Rect(0.3f*Screen.width,0.45f*Screen.height,
		                       150,20),"AMMO - 20G"))//<-- Change name of amo at AMO2
		{
			if(S_Player.currentgun == 2)
			{
			BuyAmmo(amo2);
			}
			flag2 = true;
		}
		if(GUI.Button(new Rect(0.55f*Screen.width,0.32f*Screen.height,150,20), new GUIContent("Buy Shotgun - 200G", "Buy Shotgun - 200G")))//<-- Change name of amo at AMO3
		{
			if(S_Player.cash >= 200 && S_Player.currentgun != 3)
			{
			S_Player.ammoleft += 5;
			S_Player.cash = S_Player.cash - 200;
			S_Player.currentgun = 3;
			}
			flag6 = true;
		}
		if(GUI.Button(new Rect(0.55f*Screen.width,0.45f*Screen.height,
		                       150,20), "AMMO - 30G"))//<-- Change name of amo at AMO3
		{
			if(S_Player.currentgun == 3)
			{
			BuyAmmo(amo3);
			}
			flag3 = true;
		}
		if(GUI.Button(new Rect(0.8f*Screen.width,0.32f*Screen.height,
		                       150,20), new GUIContent("Buy AUG - 400G", "Buy AUG - 400G")))//<-- Change name of amo at AMO3
		{
			if(S_Player.cash >= 200 && S_Player.currentgun != 4)
			{
			S_Player.rateofgun = 0f;
			S_Player.ammoleft += 10;
			S_Player.cash = S_Player.cash - 400;
			S_Player.currentgun = 4;
			}
			flag8 = true;
		}
		if(GUI.Button(new Rect(0.8f*Screen.width,0.45f*Screen.height,
		                       150,20), "AMMO - 40G"))//<-- Change name of amo at AMO4
		{
			if(S_Player.currentgun == 4)
			{
			BuyAmmo(amo4);
			}
			flag4 = true;
		}
		if(GUI.Button(new Rect(0.15f*Screen.width,0.83f*Screen.height,
		                       150,20), "Buy Life - 100G"))
		{
			
			BuyLife();
			flag5 = true;
		}
		
		if(GUI.tooltip == "Buy Shotgun - 200G"){
        GUI.TextField(new Rect(Event.current.mousePosition.x + 5f, Event.current.mousePosition.y, 190, 40), "Shotgun: 3 pellet spray \n Firerate: 1 shot per 0.2 sec");
    	}
		else if(GUI.tooltip == "Buy AUG - 400G")
		{
			GUI.TextField(new Rect(Event.current.mousePosition.x + 5f, Event.current.mousePosition.y, 190, 40), "Shotgun: Single Shot \n Firerate: Speed of Click");
		}
		else if(GUI.tooltip == "Buy AK-47 - 20G")
		{
			GUI.TextField(new Rect(Event.current.mousePosition.x + 5f, Event.current.mousePosition.y, 190, 40), "Shotgun: Single Shot \n Firerate: 1 shot per 0.2 sec");
		}
		else if(GUI.tooltip == "Buy G36K - 60G")
		{
			GUI.TextField(new Rect(Event.current.mousePosition.x + 5f, Event.current.mousePosition.y, 190, 40), "G36K: Single Shot \n Firerate: 1 shot per 0.1 sec");
		}
			
		else
		{
			Debug.Log("The mouse is away");
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
	
	void OnMouseEnter()
	{
			
	}
	
	// Update is called once per frame
	void Update ()
	{			
		Total = S_Player.cash.ToString()+ "G";
		
		
	}
}