using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text todisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Mover.iscombat)
        {
            todisplay.color = Color.red;
        }
        else
        {
            todisplay.color = Color.green;
        }
        todisplay.text =  Player_Mover.timeshown.ToString();
    }
}
