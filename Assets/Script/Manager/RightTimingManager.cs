using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;



    private void Start()
    {
        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i] = new Vector2(Center.transform.position.x - timingRect[i].rect.width / 2,
                                        Center.transform.position.x + timingRect[i].rect.width / 2);
        }
    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.position.x;


            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    Destroy(boxNoteList[i]);
                    boxNoteList.RemoveAt(i);

                    Debug.Log("Hit" + x);
                    return;
                }
            }
        }

        Debug.Log("Miss!");
    }
}
