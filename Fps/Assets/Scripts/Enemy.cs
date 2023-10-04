using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    Transform target;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
