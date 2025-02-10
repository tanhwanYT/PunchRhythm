using UnityEngine;

public class NoteMover : MonoBehaviour
{
    public bool inJudgeZone = false;
    public float moveSpeed; // 이동 속도
    private Vector3 targetPosition;
    private float startTime;
    public void SetTarget(Vector3 target, float noteTime, float speed)
    {
        targetPosition = target;
        float journeyLength = Vector3.Distance(transform.position, targetPosition);
        moveSpeed = journeyLength / speed; // 계산된 속도 적용
        startTime = Time.time; // 시작 시간을 설정
    }

    void Update()
    {
        float distanceCovered = (Time.time - startTime) * moveSpeed;
        float fractionOfJourney = distanceCovered / Vector3.Distance(transform.position, targetPosition);

        // 노트 이동 (선형 보간)
        transform.position = Vector3.Lerp(transform.position, targetPosition, fractionOfJourney);

        // 목표 지점에 도달하면 이동 멈추기
        if (fractionOfJourney >= 1f)
        {
            Destroy(gameObject);
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
