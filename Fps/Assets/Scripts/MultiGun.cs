using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiGun : Gun
{
    // 좌클릭을 누르고 있다면
    // 누르는 동안에 총 쏘기
    protected override void OnMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
}
