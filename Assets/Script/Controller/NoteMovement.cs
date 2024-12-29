using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public float scrollSpeed = 5f; // ��Ʈ�� �������� �ӵ�

    void Update()
    {
        // Y�� �������� ���� �ӵ��� �̵�
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // ȭ�� �Ʒ��� ����� ��� ���� (�ɼ�)
        if (transform.position.y < -10f) // ȭ�� �Ʒ� ���� �� (-10)
        {
            Destroy(gameObject);
        }
    }
}