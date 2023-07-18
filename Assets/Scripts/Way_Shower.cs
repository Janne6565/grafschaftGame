using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way_Shower : MonoBehaviour
{
    public bool needed = false;
    // Start is called before the first frame update
    void Start()
    {
      needed = false;  
    }

    // Update is called once per frame
    void Update()
    {
     if (needed == false)
     {
       transform.localScale = new Vector3(0,0,0);
     }  
     else
     {
       transform.localScale = new Vector3(1,1,1); 
     } 
    }
}
