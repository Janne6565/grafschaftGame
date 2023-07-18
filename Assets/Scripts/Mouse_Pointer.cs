using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Pointer : MonoBehaviour
{
	public Vector3 mousepos;
	public float diffx;
	public float diffy;
	public bool calced;
	private int i;
	private int n;
	public string Oname;
	public GameObject waypoint;
	private GameObject Protag;
	public int speed;
	public int range;
	// Start is called before the first frame update
	void Start()
	{
	   Protag = GameObject.Find("Player");
	   GameObject.Find("Selected").transform.position = new Vector3(-0.5f,-0.5f); 
	}

	// Update is called once per frame
	void Update()
	{
		mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//mousepos= Input.mousePosition;
		//mousepos.x=((mousepos.x-225)*10/332-5);
		//mousepos.y=((mousepos.y)*10/332-5);
		if (!Player_Mover.iscombat)                                 //this is Movement
		{
		if ((mousepos.y > -5) && (mousepos.y < 5) && (mousepos.x > -5) && (mousepos.x < 5) && (Mathf.Pow((Mathf.Pow(mousepos.x-Protag.transform.position.x,2)+Mathf.Pow(mousepos.y-Protag.transform.position.y,2)),0.5f)<speed))
		{ 
		transform.position=new Vector2(Mathf.FloorToInt(mousepos.x)+0.5f,Mathf.FloorToInt(mousepos.y)+0.5f);
		}                                   //mark the mouse hovering tile
		if(Input.GetMouseButtonDown(0) && (Mathf.Pow((Mathf.Pow(mousepos.x-Protag.transform.position.x,2)+Mathf.Pow(mousepos.y-Protag.transform.position.y,2)),0.5f)<speed))
		{ 
		GameObject.Find("Selected").transform.position = transform.position;
		Selected_Hide.selected = true;
		calced=false;
		}                                   //select final position
		if (calced == false)
		{

			for (i=1;i<20;i++)
			{
			  GameObject.Find("PlayerWays/Way "+i).GetComponent<Way_Shower>().needed = false;  
			}

			n = 1;
			calced = true;
			diffx=GameObject.Find("Selected").transform.position.x - Protag.transform.position.x;
			diffy=GameObject.Find("Selected").transform.position.y - Protag.transform.position.y;

			for (i=1;i<10;i++)
			{
			   Oname = "PlayerWays/Way " +n;
				waypoint =GameObject.Find(Oname);
			   waypoint.transform.position = new Vector3(Mathf.FloorToInt(Protag.transform.position.x+(diffx/10)*i)+0.5f,Mathf.FloorToInt(Protag.transform.position.y+(diffy/10)*i)+0.5f,0); 
			   
			   if (n==1)
				{
					n++;
					waypoint.GetComponent<Way_Shower>().needed = true;
				}
				else
				 {
				  if ((waypoint.transform.position != GameObject.Find("PlayerWays/Way "+(n-1)).transform.position)) // && (waypoint.transform.position != GameObject.Find("Player").transform.position))
				   {
						n++;
						waypoint.GetComponent<Way_Shower>().needed = true;
				   }
			   }
			} 
		} 
		}
		else                    //This is combat
		{
			if ((mousepos.y > -5) && (mousepos.y < 5) && (mousepos.x > -5) && (mousepos.x < 5)) 
		{ 
		transform.position=new Vector2(Mathf.FloorToInt(mousepos.x)+0.5f,Mathf.FloorToInt(mousepos.y)+0.5f);
		}                                   //mark the mouse hovering tile
		if(Input.GetMouseButtonDown(0) && (Mathf.Abs(Protag.transform.position.x-transform.position.x)<=range) && (Mathf.Abs(Protag.transform.position.y-transform.position.y)<=range) && (Mathf.Abs(Protag.transform.position.x-transform.position.x)!=0 || (Mathf.Abs(Protag.transform.position.y-transform.position.y)!=0)))
		{ 
		GameObject.Find("Selected").transform.position = transform.position;
		Selected_Hide.selected = true;
		}
		}
	}
}
