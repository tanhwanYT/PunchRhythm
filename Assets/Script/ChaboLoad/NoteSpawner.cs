using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;  // 노트 프리팹
    public Transform[] laneStartPoints; // 레인의 시작 지점
    public Transform[] laneEndPoints;   // 레인의 끝 지점
    public float noteSpeed = 5f; // 노트 이동 속도

    public void SpawnNote(int lane, float time)
    {
        if (lane < 0 || lane >= laneStartPoints.Length)
        {
            Debug.LogError($"Invalid lane: {lane}");
            return;
        }

        // 노트 생성
        GameObject noteObject = Instantiate(notePrefab);

        // 노트 위치를 worldPosition으로 설정
        noteObject.transform.position = laneStartPoints[lane].position;

        // 노트를 레인의 자식으로 설정
        noteObject.transform.SetParent(laneStartPoints[lane].parent);

        // 노트 이동 설정
        NoteMover mover = noteObject.GetComponent<NoteMover>();
        if (mover != null)
        {
            mover.SetTarget(laneEndPoints[lane].position, time, noteSpeed);
        }
    }
}
