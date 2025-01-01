using UnityEngine;

public class NoteMover : MonoBehaviour
{
    private float scrollSpeed;
    private Vector3 targetPosition;

    public void Initialize(float speed, int lane)
    {
        scrollSpeed = speed;

        if (lane == 0) // ���� ����
        {
            targetPosition = new Vector3(-2f, -5f, 0f);
        }
        else if (lane == 1) // �߰� ī���� ����
        {
            targetPosition = new Vector3(0f, -5f, 0f);
        }
        else if (lane == 2) // ������ ����
        {
            targetPosition = new Vector3(2f, -5f, 0f);
        }
    }

    private void Update()
    {
        // ��Ʈ�� targetPosition���� �̵�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, scrollSpeed * Time.deltaTime);

        // ��ǥ ��ġ�� �����ϸ� ����
        if (transform.position == targetPosition)
        {
            Destroy(gameObject);
        }
    }
}
