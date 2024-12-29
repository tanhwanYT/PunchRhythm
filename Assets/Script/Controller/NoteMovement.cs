using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public float scrollSpeed = 5f; // 노트가 내려오는 속도

    void Update()
    {
        // Y축 방향으로 일정 속도로 이동
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // 화면 아래로 벗어났을 경우 제거 (옵션)
        if (transform.position.y < -10f) // 화면 아래 기준 값 (-10)
        {
            Destroy(gameObject);
        }
    }
}