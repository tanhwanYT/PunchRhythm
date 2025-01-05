using UnityEngine;

public class NoteMover : MonoBehaviour
{
    private Vector3 targetPosition; // �̵��� ��ǥ ��ġ
    public float spawnTime; // ��Ʈ�� ������ �ð�
    private float speed; // �̵� �ӵ�
    public bool inJudgeZone = false;


    public void SetTarget(Vector3 target, float time, float speed)
    {
        targetPosition = target;
        spawnTime = time;
        this.speed = speed;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime; // �� �����Ӵ� �̵� �Ÿ�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // ��ǥ ��ġ�� �������� ���
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject); // ��Ʈ ����
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
