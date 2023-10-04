using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody rb;

    public float damage = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(TimeOut());
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IHit hit = collision.gameObject.GetComponent<IHit>();

        if (hit == null)
            return;

        hit.OnHit(damage);

        ReturnObject();
    }

    public void ReturnObject()
    {
        rb.velocity = Vector3.zero;
        this.transform.position = Vector3.zero;
        GameManager.Instance.pool.SetPool(PoolFlag.bullet, this.gameObject);
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(1f);

        ReturnObject();
    }
}