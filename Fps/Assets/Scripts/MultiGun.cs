using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiGun : Gun
{
    [SerializeField]
    float attackCycle; // 공격 주기
    float coolTime = 0;

    Coroutine antiFastClickCoru;
    Coroutine spandCoolTimeCoru;

    bool coolIsDone = true;

    // 좌클릭을 누르고 있다면
    // 누르는 동안에 총 쏘기
    protected override void OnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
           antiFastClickCoru = StartCoroutine(AntiFastClick());
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCoroutine(antiFastClickCoru);

            if(spandCoolTimeCoru != null)
                StopCoroutine(spandCoolTimeCoru);

            spandCoolTimeCoru = StartCoroutine(SpandCoolTime());
        }
    }

    IEnumerator AntiFastClick()
    {
        while(!coolIsDone)
        {
            yield return null;
        }

        while(true)
        {
            if (coolTime <= 0)
            {
                Shoot();
                coolTime = attackCycle;
                yield return null;
            }
            coolTime -= Time.deltaTime;
            yield return null;
        }        
    }

    IEnumerator SpandCoolTime()
    {
        coolIsDone = false;
        while (coolTime > 0)
        {
            coolTime -= Time.deltaTime;
            yield return null;
        }
        coolIsDone = true;
    }
}
