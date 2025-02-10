using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;  // ��Ʈ ������
    public Transform[] laneStartPoints; // ������ ���� ����
    public Transform[] laneEndPoints;   // ������ �� ����
    public float noteSpeed = 5f; // �⺻ ��Ʈ �̵� �ӵ�

    private float bpm = 120f; // �⺻ BPM ��
    private float beatDuration; // �� ������ ���� (�� ����)
    private List<NoteLoader.Note> noteData; // ä�� ������
    private int noteIndex = 0; // ���� ������ ��Ʈ�� �ε���
    private float songStartTime; // ������ ���۵� �ð�

    public void InitializeSpawner(List<NoteLoader.Note> notes, float chartBPM)
    {
        noteData = notes;
        bpm = chartBPM;
        beatDuration = 60f / bpm; // �� ������ �� ���� ����
        noteIndex = 0;
        songStartTime = Time.time;
    }

    private void Update()
    {
        if (noteData == null || noteIndex >= noteData.Count)
            return;

        float currentTime = Time.time - songStartTime; // ������ ���۵� �� ��� �ð�

        // ���� �ð��� ��Ʈ�� ���� Ÿ�ֿ̹� �����ϸ� ��Ʈ ����
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

        // ��Ʈ ����
        GameObject noteObject = Instantiate(notePrefab, laneStartPoints[lane].position, Quaternion.identity);

        // ��Ʈ�� ������ �ڽ����� ����
        noteObject.transform.SetParent(laneStartPoints[lane].parent);

        // ��Ʈ �̵� ����
        NoteMover mover = noteObject.GetComponent<NoteMover>();
        if (mover != null)
        {
            Debug.Log(bpm);
            float noteSpeed = beatDuration;
            mover.SetTarget(laneEndPoints[lane].position, noteInfo.time, noteSpeed);
        }
    }
}
