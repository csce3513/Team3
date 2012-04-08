using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;

public class S_ShopGUI : MonoBehaviour
{   
	int amo1 = 10,// Define values of amo here 
	    amo2 = 20,
	    amo3 = 30,
	    amo4 = 40;
	int amo1_count=0,
	    amo2_count=0,
	    amo3_count=0,
	    amo4_count=0;
	float money = 100f; //<---- pass money variable here
	bool flag1 = false,// Define as key is down, they will change to true
	     flag2 = false,
	     flag3 = false,
	     flag4 = false;
	//bool finishShopping = false;
	public string Total;
	
	public float UpdateMoney(int amo)
	{
		return money = money-amo;
	}
   
	// Use this for initialization
	void Start ()
	{
		amo1_count=0;//<--- Pass variable that helds value of player's amo here
	    amo2_count=0;
	    amo3_count=0;
	    amo4_count=0;
	}

	void OnGUI()
	{
		Total = GUI.TextArea(new Rect(0.3f*Screen.width,0.3f*Screen.height,
		                       150,20),Total);
		if(GUI.Button(new Rect(0.2f*Screen.width,0.4f*Screen.height,
		                       150,20), "AMO1 - 10G"))//<-- Change name of amo at AMO1
		{
			if(money>=amo1)
			{
				UpdateMoney(amo1);
				amo1_count++;
			}
			//funcction to render picture of bullet can put here
			
			
			flag1 = true;
		}
		if(GUI.Button(new Rect(0.2f*Screen.width,0.5f*Screen.height,
		                       150,20), "AMO2 - 20G"))//<-- Change name of amo at AMO2
		{
			if(money>=amo2)
			{
				UpdateMoney(amo2);
				amo2_count++;
			}
			flag2 = true;
		}
		if(GUI.Button(new Rect(0.2f*Screen.width,0.6f*Screen.height,
		                       150,20), "AMO3 - 30G"))//<-- Change name of amo at AMO3
		{
			
			if(money>=amo3)
			{
				UpdateMoney(amo3);
				amo3_count++;
			}
			flag3 = true;
		}
		if(GUI.Button(new Rect(0.2f*Screen.width,0.7f*Screen.height,
		                       150,20), "AMO4 - 40G"))//<-- Change name of amo at AMO4
		{
			
			if(money>=amo4)
			{
				UpdateMoney(amo4);
				amo4_count++;
			}
			flag4 = true;
		}
	}
	// Update is called once per frame
	void Update ()
	{			
		Total = money.ToString()+ "G";
	}
}
