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
        if (Input.GetKeyDown(KeyCode.RightArrow)) // 오른쪽 키: 오른손 펀치
        {
            anim.SetTrigger("RightPunchTrigger");
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow)) // 왼쪽 키: 왼손 펀치
        {
            anim.SetTrigger("LeftPunchTrigger");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) // 위쪽 키: 카운터
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