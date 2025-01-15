using Unity.VisualScripting;
using UnityEngine;

public class JudgeManager : MonoBehaviour
{
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode centerKey = KeyCode.UpArrow;
    public KeyCode rightKey = KeyCode.RightArrow;

    public Transform leftLane;
    public Transform centerLane;
    public Transform rightLane;

    public float perfectWindow = 1.0f;
    public float greatWindow = 2.0f;
    public float goodWindow = 3.0f;

    private void Update()
    {
        // Ű �Է¿� ���� �ش� ���ο��� ����
        if (Input.GetKeyDown(leftKey))
            JudgeLane(leftLane);
        if (Input.GetKeyDown(centerKey))
            JudgeLane(centerLane);
        if (Input.GetKeyDown(rightKey))
            JudgeLane(rightLane);
    }

    private void JudgeLane(Transform lane)
    {
        NoteMover closestNote = FindClosestNoteInLane(lane);
        if (closestNote != null)
        {
            // ������ �� ��ġ (endPos)
            Transform endPos = lane.GetChild(0);  // ������ ù ��° �ڽ��� endPos�� ����
            Debug.Log("EndPos position: " + endPos.position);
            Debug.Log("clossesNote position: " + closestNote.transform.position);

            // ��Ʈ�� �� ���� ���� �Ÿ� ���
            float distance = Vector3.Distance(closestNote.transform.position, endPos.position);


            if(distance >= perfectWindow)
            {
                Debug.Log("Perfect! = " + distance);
            }
            else if (distance >= greatWindow)
            {
                Debug.Log("Great! = " + distance);
            }
            else if (distance >= goodWindow)
            {
                Debug.Log("Ok! = " + distance);
            }
            else
            {
                Debug.Log("Bad! = " + distance);
            }

            // ��Ʈ ����
            Destroy(closestNote.gameObject);
        }
        else
        {
            Debug.Log("�����̻�!");
        }
    }


    private NoteMover FindClosestNoteInLane(Transform lane)
    {
        NoteMover closestNote = null;
        float closestDistance = float.MaxValue;

        // ������ �� ���� (endPos)������ �Ÿ��� �������� ���� ����� ��Ʈ�� ã��
        Transform endPos = lane.GetChild(0);  // �� ������ endPos�� �ڽ����� ����

        foreach (Transform child in lane)
        {
            NoteMover note = child.GetComponent<NoteMover>();
            if (note != null) // ���� ������ �������� Ȯ��
            {
                // ��Ʈ�� endPos�� y ��ġ ���̷� �Ÿ��� ���
                float distance = Vector3.Distance(note.transform.position, endPos.position);
                Debug.Log("Distance at Key Press: " + distance);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestNote = note;
                }
            }
        }
        return closestNote; // ���� ����� ��Ʈ�� ��ȯ
    }
}
