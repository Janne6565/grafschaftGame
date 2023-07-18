using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mover : MonoBehaviour
{
    private GameObject Player;              // just for not having to search them up all the time
    private float tomovex;                  // the distance the enemy is away from the player
    private float tomovey;
    public float enemyspeed;                // the amount of spaces the enemy can move per turn (diagonal being allowed)
    public static List<Vector3> Enemypositions = new List<Vector3>();   // A list of every enemies position, used for combat and collision calculation
    // Start is called before the first frame update
    void Start()
    {
     Player = GameObject.Find("Player"); 
     transform.position = new Vector3(-3.5f,-3.5f,0); 
     Enemypositions.Add(transform.position); 
    }

    // Update is called once per frame
    void Update()
    {
      if ((Player.GetComponent<Player_Mover>().time <= Time.deltaTime) && (!Player_Mover.iscombat))
      {
        Enemypositions.Remove(transform.position);
        tomovex = transform.position.x-Player.transform.position.x;
        tomovey = transform.position.y-Player.transform.position.y;
        if (tomovex > enemyspeed)
        {
            tomovex = enemyspeed;
        }
        if (tomovex < -enemyspeed)
        {
            tomovex = -enemyspeed;
        }
        if (tomovey > enemyspeed)
        {
            tomovey = enemyspeed;
        }
        if (tomovey < -enemyspeed)
        {
            tomovey = -enemyspeed;
        }
        transform.position = new Vector3(transform.position.x-tomovex,transform.position.y-tomovey,0);
        Enemypositions.Add(transform.position);
      }  
    }
}
