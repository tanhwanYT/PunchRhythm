using System.Collections.Generic;
using UnityEngine;

public class CounterTimingManager : MonoBehaviour
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
            timingBoxs[i] = new Vector2(
                Center.transform.position.y - timingRect[i].rect.height / 2,
                Center.transform.position.y + timingRect[i].rect.height / 2);
        }
    }

    public void CheckTiming()
    {
        for (int i = boxNoteList.Count - 1; i >= 0; i--)
        {
            float t_notePosY = boxNoteList[i].transform.position.y;

            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosY && t_notePosY <= timingBoxs[x].y)
                {
                    Debug.Log("Victory Counter");
                    Destroy(boxNoteList[i]);
                    boxNoteList.RemoveAt(i);
                    return;
                }
            }
        }

        Debug.Log("Miss!");
    }
}