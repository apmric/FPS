using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGun : Gun
{
    protected override void OnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}
