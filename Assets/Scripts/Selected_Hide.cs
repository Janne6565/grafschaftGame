using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected_Hide : MonoBehaviour
{
	 private GameObject Player;
	 public static bool selected;
	 // Start is called before the first frame update
	 void Start()
	 {
		 Player = GameObject.Find("Player"); 
	 }

	 // Update is called once per frame
	 void Update()
	 {
		 if (Player.GetComponent<Player_Mover>().time <= Time.deltaTime)
		 {
		  selected = false;
		 }
		 if (!selected)
		 {
		  transform.localScale = new Vector3(0,0,0);
		 } 
		 else
		 {
		  transform.localScale = new Vector3(1,1,1); 
		 } 
	 }
}
