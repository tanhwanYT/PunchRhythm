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
        GameObject noteObject = Instantiate(notePrefab, laneStartPoints[lane].position, Quaternion.identity);

        // 노트 이동 설정
        NoteMover mover = noteObject.GetComponent<NoteMover>();
        if (mover != null)
        {
            mover.SetTarget(laneEndPoints[lane].position, time, noteSpeed);
        }
    }
}
