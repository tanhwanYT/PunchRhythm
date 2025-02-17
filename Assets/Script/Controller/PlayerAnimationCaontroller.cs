using System.Collections;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) // ������ Ű: ������ ��ġ
        {
            anim.SetTrigger("RightPunchTrigger");
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow)) // ���� Ű: �޼� ��ġ
        {
            anim.SetTrigger("LeftPunchTrigger");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) // ���� Ű: ī����
        {
            anim.SetTrigger("CounterTrigger");
        }


    }
    IEnumerator ResetTrigger(string triggerName)
    {
        yield return new WaitForSeconds(0.1f);
        anim.ResetTrigger(triggerName);
    }
}