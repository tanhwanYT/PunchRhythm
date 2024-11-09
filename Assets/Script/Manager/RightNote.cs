using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightNote : MonoBehaviour
{
    private float noteSpeed = 400;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * noteSpeed * Time.deltaTime;
    }
}
