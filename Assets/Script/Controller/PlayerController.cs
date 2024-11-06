using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    TimingManager theTimingManager;

    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            theTimingManager.CheckTiming();
        }
    }
}
