using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    TimingManager theTimingManager;
    RightTimingManager rightTimingManager;
    CounterTimingManager counterTimingManager;
    private void Start()
    {
        rightTimingManager = FindObjectOfType<RightTimingManager>();
        theTimingManager = FindObjectOfType<TimingManager>();
        counterTimingManager = FindObjectOfType<CounterTimingManager>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            theTimingManager.CheckTiming();
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)) 
        { 
            rightTimingManager.CheckTiming(); 
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            counterTimingManager.CheckTiming();
        }
    }
}
