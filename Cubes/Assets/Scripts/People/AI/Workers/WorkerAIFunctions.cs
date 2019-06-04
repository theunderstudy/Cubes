using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerAIFunctions : MonoBehaviour
{
    private NavMeshAgent Agent;
    private NavMeshHit Hit;
    private Vector3 Destination;
    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private float currentTimer;
    private float timer;
    #region Wander
    [Header("wander")]
    public float WanderRadius;
    public float WanderIdleTime;
   
    public void StartWander(Worker worker)
    {
        if (GetWanderLocation(out Destination))
        {
            Agent.destination = Destination;
            worker.CurrentAI = Wander;
        }
    }
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
    private bool GetWanderLocation(out Vector3 pos)
    {
        for (int i = 0; i < 10; i++)
        {
            pos = new Vector3(transform.position.x + Random.Range(-WanderRadius, WanderRadius), 0, (transform.position.z + Random.Range(-WanderRadius, WanderRadius)));
            if (NavMesh.SamplePosition(pos, out Hit, 1.0f, NavMesh.AllAreas))
            {
                pos = Hit.position;
                return true;
            }
        }
        pos = Vector3.zero;
        return false;
    }
    #endregion
}
