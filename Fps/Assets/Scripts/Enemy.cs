using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IHit
{
    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    Transform target;

    float hp = 5f;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    public void OnHit(float damage)
    {
        hp -= damage;

        if (hp <= 0)
            Destroy(this.gameObject);
    }
}
