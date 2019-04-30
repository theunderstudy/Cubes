using UnityEngine;
using UnityEngine.AI;


public class Worker : MonoBehaviour
{
    protected enum WorkerStates { Nil, Idle, Wander, HarvestingResource }

    private delegate void AIFunction();
    private AIFunction CurrentAI;
    private AIFunction NextAI;
    #region Navigation General
    private NavMeshAgent Agent;
    private NavMeshHit Hit;
    private Vector3 Destination;
    #endregion
    #region Wander
    public float WanderRadius;
    public float WanderIdleTime;
    #endregion
    private float currentTimer;
    private float timer;
    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
    private Transform target;

    private void Idle()
    {
        timer += Time.deltaTime;
        if (timer > currentTimer)
        {
            CurrentAI = NextAI;
            timer = 0;
        }
    }

    private void StartWander()
    {
        if (GetLocation(out Destination))
        {
            Agent.destination = Destination;

        }
    }
    private void Wander()
    {
        if (!Agent.hasPath)
        {

        }
    }

    private void Harvest()
    {

    }

    private bool GetLocation(out Vector3 pos)
    {
        for (int i = 0; i < 10; i++)
        {
            pos = new Vector3(transform.position.x + Random.Range(0, WanderRadius), 0, (transform.position.z + Random.Range(0, WanderRadius)));
            if (NavMesh.SamplePosition(pos, out Hit, 1.0f, NavMesh.AllAreas))
            {
                pos = Hit.position;
                return true;
            }
        }
        pos = Vector3.zero;
        return false;
    }
}
