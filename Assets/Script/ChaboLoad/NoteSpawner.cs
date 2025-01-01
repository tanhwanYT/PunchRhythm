using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject leftNotePrefab;    // 왼쪽 노트 프리팹
    public GameObject counterNotePrefab; // 중간 카운터 노트 프리팹
    public GameObject rightNotePrefab;  // 오른쪽 노트 프리팹

    // 노트가 내려오는 속도
    public float scrollSpeed = 5f;

    // 노트 생성 메서드
    public void SpawnNote(int lane, float spawnTime)
    {
        GameObject notePrefab = null;
        Vector3 spawnPosition = Vector3.zero;
        Debug.Log($"Spawning note at lane {lane} and time {spawnTime}"); // 로그 추가


        // 레인에 따라 프리팹과 스폰 위치를 설정
        if (lane == 0) // 왼쪽 레인
        {
            notePrefab = leftNotePrefab;
            spawnPosition = new Vector3(-8f, 5f, 0f);
        }
        else if (lane == 1) // 중간 카운터 레인
        {
            notePrefab = counterNotePrefab;
            spawnPosition = new Vector3(0f, 6f, 0f);
        }
        else if (lane == 2) // 오른쪽 레인
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
                noteMover.Initialize(scrollSpeed, lane); // 속도와 레인 정보 전달
            }
        }
    }
}
