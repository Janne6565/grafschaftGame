using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mover : MonoBehaviour
{
	public float time;
	public static int timeshown;
	private GameObject toswitch;
	private int i;
	public static bool iscombat;
	// Start is called before the first frame update
	void Start()
	{
	  time = 5;  
	  toswitch = GameObject.Find("Selected");
	  iscombat = false;
	}

	// Update is called once per frame
	void Update()
	{
		time -= Time.deltaTime;
		timeshown = Mathf.FloorToInt(time+1);
		if (time <= 0)
		{
			if (!iscombat)
			{
				for(i=1;i<20;i++)
				{
				 GameObject.Find("PlayerWays/Way "+i).GetComponent<Way_Shower>().needed = false;
				}
				transform.position = toswitch.transform.position;
				iscombat = true;
			}
			else
			{
				iscombat = false;
			}
			time = 5;
		}  
	}
}
