using UnityEngine;

public class NoteMover : MonoBehaviour
{
    public bool inJudgeZone = false;
    public float moveSpeed; // �̵� �ӵ�
    private Vector3 targetPosition;
    private float startTime;
    public void SetTarget(Vector3 target, float noteTime, float speed)
    {
        targetPosition = target;
        float journeyLength = Vector3.Distance(transform.position, targetPosition);
        moveSpeed = journeyLength / speed; // ���� �ӵ� ����
        startTime = Time.time; // ���� �ð��� ����
    }

    void Update()
    {
        float distanceCovered = (Time.time - startTime) * moveSpeed;
        float fractionOfJourney = distanceCovered / Vector3.Distance(transform.position, targetPosition);

        // ��Ʈ �̵� (���� ����)
        transform.position = Vector3.Lerp(transform.position, targetPosition, fractionOfJourney);

        // ��ǥ ������ �����ϸ� �̵� ���߱�
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
