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

    // �ִ� ��ź��
    public int maxBulletCount;    

    // ���� ���� ź���� ��
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

    // �Ѿ� ����()
    private void CreateBullet()
    {
        GameObject temp = GameManager.Instance.pool.GetPool(PoolFlag.bullet);
        temp.transform.position = bulletPos.position;

        Physics.Raycast(cam.position, cam.forward, out hit, 1000);
        temp.transform.LookAt(hit.point);
    }

    // �� �� �� ���()
    protected void Shoot()
    {
        if (currentBulletCount > 0)
        {
            currentBulletCount--;
            CreateBullet();
            //gm.UpdateBullet(currentBulletCount);
        }
    }

    // ������()
    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
            currentBulletCount = maxBulletCount;
    }

    // ��Ŭ���ߴ°�()
    protected virtual void OnMouseClick()
    {
        Shoot();
    }
}