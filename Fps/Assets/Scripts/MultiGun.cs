using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiGun : Gun
{
    // ��Ŭ���� ������ �ִٸ�
    // ������ ���ȿ� �� ���
    protected override void OnMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
}
