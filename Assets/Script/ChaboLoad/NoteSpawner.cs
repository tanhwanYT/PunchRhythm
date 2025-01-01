using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject leftNotePrefab;    // ���� ��Ʈ ������
    public GameObject counterNotePrefab; // �߰� ī���� ��Ʈ ������
    public GameObject rightNotePrefab;  // ������ ��Ʈ ������

    // ��Ʈ�� �������� �ӵ�
    public float scrollSpeed = 5f;

    // ��Ʈ ���� �޼���
    public void SpawnNote(int lane, float spawnTime)
    {
        GameObject notePrefab = null;
        Vector3 spawnPosition = Vector3.zero;
        Debug.Log($"Spawning note at lane {lane} and time {spawnTime}"); // �α� �߰�


        // ���ο� ���� �����հ� ���� ��ġ�� ����
        if (lane == 0) // ���� ����
        {
            notePrefab = leftNotePrefab;
            spawnPosition = new Vector3(-8f, 5f, 0f);
        }
        else if (lane == 1) // �߰� ī���� ����
        {
            notePrefab = counterNotePrefab;
            spawnPosition = new Vector3(0f, 6f, 0f);
        }
        else if (lane == 2) // ������ ����
        {
            notePrefab = rightNotePrefab;
            spawnPosition = new Vector3(8f, 5f, 0f);
        }

        if (notePrefab != null)
        {
            GameObject note = Instantiate(notePrefab, spawnPosition, Quaternion.identity);
            if (note == null)
            {
                Debug.LogError("Note prefab instantiation failed!");
            }

            NoteMover noteMover = note.GetComponent<NoteMover>();

            if (noteMover != null)
            {
                noteMover.Initialize(scrollSpeed, lane); // �ӵ��� ���� ���� ����
            }
        }
    }
}
