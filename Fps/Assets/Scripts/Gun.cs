using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //public static GunManager gm;

    [SerializeField]
    Transform bulletPos;

    // 최대 장탄수
    public int maxBulletCount;    

    // 현재 남는 탄알의 수
    private int CurrentBulletCount = 0;
    public int currentBulletCount
    {
        get
        {
            return CurrentBulletCount;
        }
        private set
        {
            CurrentBulletCount = value;
            //gm.UpdateBullet(currentBulletCount);
        }
    }

    Transform cam;

    RaycastHit hit;

    void Awake()
    {
        currentBulletCount = maxBulletCount;
        cam = Camera.main.transform;
    }

    void Update()
    {
        OnMouseClick();
        Reload();
    }

    // 총알 생성()
    private void CreateBullet()
    {
        GameObject temp = GameManager.Instance.pool.GetPool(PoolFlag.bullet);
        temp.transform.position = bulletPos.position;

        Physics.Raycast(cam.position, cam.forward, out hit, 1000);
        temp.transform.LookAt(hit.point);
    }

    // 총 한 발 쏘기()
    protected void Shoot()
    {
        if (currentBulletCount > 0)
        {
            currentBulletCount--;
            CreateBullet();
            //gm.UpdateBullet(currentBulletCount);
        }
    }

    // 재장전()
    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
            currentBulletCount = maxBulletCount;
    }

    // 좌클릭했는가()
    protected virtual void OnMouseClick()
    {
        Shoot();
    }
}