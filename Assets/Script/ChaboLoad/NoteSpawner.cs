using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;  // ��Ʈ ������
    public Transform[] laneStartPoints; // ������ ���� ����
    public Transform[] laneEndPoints;   // ������ �� ����
    public float noteSpeed = 5f; // ��Ʈ �̵� �ӵ�

    public void SpawnNote(int lane, float time)
    {
        if (lane < 0 || lane >= laneStartPoints.Length)
        {
            Debug.LogError($"Invalid lane: {lane}");
            return;
        }

        // ��Ʈ ����
        GameObject noteObject = Instantiate(notePrefab);

        // ��Ʈ ��ġ�� worldPosition���� ����
        noteObject.transform.position = laneStartPoints[lane].position;

        // ��Ʈ�� ������ �ڽ����� ����
        noteObject.transform.SetParent(laneStartPoints[lane].parent);

        // ��Ʈ �̵� ����
        NoteMover mover = noteObject.GetComponent<NoteMover>();
        if (mover != null)
        {
            mover.SetTarget(laneEndPoints[lane].position, time, noteSpeed);
        }
    }
}
