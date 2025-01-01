using UnityEngine;

public class NoteMover : MonoBehaviour
{
    private float scrollSpeed;
    private Vector3 targetPosition;

    public void Initialize(float speed, int lane)
    {
        scrollSpeed = speed;

        if (lane == 0) // 왼쪽 레인
        {
            targetPosition = new Vector3(-2f, -5f, 0f);
        }
        else if (lane == 1) // 중간 카운터 레인
        {
            targetPosition = new Vector3(0f, -5f, 0f);
        }
        else if (lane == 2) // 오른쪽 레인
        {
            targetPosition = new Vector3(2f, -5f, 0f);
        }
    }

    private void Update()
    {
        // 노트를 targetPosition으로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, scrollSpeed * Time.deltaTime);

        // 목표 위치에 도달하면 제거
        if (transform.position == targetPosition)
        {
            Destroy(gameObject);
        }
    }
}
