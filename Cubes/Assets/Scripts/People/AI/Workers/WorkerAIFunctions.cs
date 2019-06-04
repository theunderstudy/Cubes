using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerAIFunctions : MonoBehaviour
{
    private NavMeshAgent Agent;
    private NavMeshHit Hit;
    private Vector3 Destination;


    private float currentTimer;
    private float timer;
    public void Wander()
    {
        if (!Agent.hasPath)
        {
            timer += Time.deltaTime;
            if (timer > WanderIdleTime)
            {
                timer = 0;
            }
        }
    }
}
