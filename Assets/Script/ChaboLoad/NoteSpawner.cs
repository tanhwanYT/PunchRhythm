using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;  // 노트 프리팹
    public Transform[] laneStartPoints; // 레인의 시작 지점
    public Transform[] laneEndPoints;   // 레인의 끝 지점
    public float noteSpeed = 5f; // 기본 노트 이동 속도

    private float bpm = 120f; // 기본 BPM 값
    private float beatDuration; // 한 박자의 길이 (초 단위)
    private List<NoteLoader.Note> noteData; // 채보 데이터
    private int noteIndex = 0; // 현재 생성할 노트의 인덱스
    private float songStartTime; // 음악이 시작된 시간

    public void InitializeSpawner(List<NoteLoader.Note> notes, float chartBPM)
    {
        noteData = notes;
        bpm = chartBPM;
        beatDuration = 60f / bpm; // 한 박자의 초 단위 길이
        noteIndex = 0;
        songStartTime = Time.time;
    }

    private void Update()
    {
        if (noteData == null || noteIndex >= noteData.Count)
            return;

        float currentTime = Time.time - songStartTime; // 음악이 시작된 후 경과 시간

        // 현재 시간이 노트의 스폰 타이밍에 도달하면 노트 생성
        while (noteIndex < noteData.Count && noteData[noteIndex].time <= currentTime)
        {
            SpawnNote(noteData[noteIndex]);
            noteIndex++;
        }
    }

    private void SpawnNote(NoteLoader.Note noteInfo)
    {
        int lane = noteInfo.lane;
        if (lane < 0 || lane >= laneStartPoints.Length)
        {
            Debug.LogError($"Invalid lane: {lane}");
            return;
        }

        // 노트 생성
        GameObject noteObject = Instantiate(notePrefab, laneStartPoints[lane].position, Quaternion.identity);

        // 노트를 레인의 자식으로 설정
        noteObject.transform.SetParent(laneStartPoints[lane].parent);

        // 노트 이동 설정
        NoteMover mover = noteObject.GetComponent<NoteMover>();
        if (mover != null)
        {
            Debug.Log(bpm);
            float noteSpeed = beatDuration;
            mover.SetTarget(laneEndPoints[lane].position, noteInfo.time, noteSpeed);
        }
    }
}
