using UnityEngine;

public class NoteMover : MonoBehaviour
{
    private Vector3 targetPosition; // 이동할 목표 위치
    public float spawnTime; // 노트가 스폰된 시간
    private float speed; // 이동 속도
    public bool inJudgeZone = false;


    public void SetTarget(Vector3 target, float time, float speed)
    {
        targetPosition = target;
        spawnTime = time;
        this.speed = speed;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime; // 한 프레임당 이동 거리
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // 목표 위치에 도달했을 경우
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject); // 노트 삭제
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JudgeZone"))
        {
            inJudgeZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("JudgeZone"))
        {
            inJudgeZone = false;
        }
    }
}
