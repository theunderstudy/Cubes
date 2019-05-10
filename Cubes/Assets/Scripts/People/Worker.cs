using UnityEngine;
using UnityEngine.AI;


public class Worker : MonoBehaviour
{
    protected enum WorkerStates { Nil, Idle, Wander, HarvestingResource }

    private delegate void AIFunction();
    private AIFunction CurrentAI;
    private AIFunction NextAI;
    public Transform BuildingMaterialCarryPos;
    #region Navigation General
    private NavMeshAgent Agent;
    private NavMeshHit Hit;
    private Vector3 Destination;
    #endregion
    #region Wander
    public float WanderRadius;
    public float WanderIdleTime;
    #endregion
    #region WorkingResource
    private CubeUpgrade CurrentWorkTarget;
    public float WorkApplied = 1;
    public float TimeBetweenWorks = 2;
    #endregion

    #region Building
    public BuildingMaterial CarriedMaterial;

    #endregion
    private float currentTimer;
    private float timer;
    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        CurrentAI = StartWander;
    }

    private void Update()
    {
        CurrentAI();
    }
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
        if (GetWanderLocation(out Destination))
        {
            Agent.destination = Destination;
            CurrentAI = Wander;
            NextAI = MoveToWorkTarget;
        }
    }
    private void Wander()
    {
        if (!Agent.hasPath)
        {
            timer += Time.deltaTime;
            if (timer > WanderIdleTime)
            {
                timer = 0;
                CurrentAI = NextAI;
            }
        }
    }

    private CubeUpgradeTypes GetDesiredResource()
    {
        return CubeUpgradeTypes.Tree;
    }

    private void Build()
    {
        //check for resrouces
    }
    private void MoveToWorkTarget()
    {
        //get resource from priority list
        //HACK: just use trees for testing
        if (CurrentWorkTarget)
        {
            //check if pathing is done
            if (!Agent.hasPath)
            {
                CurrentAI = WorkTarget;
                NextAI = StartWander;
            }
            return;
        }
        CurrentWorkTarget = LandMan.Instance.GetNearbyUpgrade(this, GetDesiredResource());
        if (!CurrentWorkTarget)
        {

            CurrentAI = StartWander;
            return;
        }
        Agent.SetDestination(CurrentWorkTarget.GetWorkLocation());
    }

    private void WorkTarget()
    {
        timer += Time.deltaTime;
        //time between works
        if (timer < TimeBetweenWorks)
        {
            return;
        }
        timer = 0;
        //work upgrade til work is done
        if (CurrentWorkTarget.WorkUpgrade(CalculateWork()))
        {
            //collect resrouce
            CarriedMaterial = CurrentWorkTarget.TakeMaterial(BuildingMaterialCarryPos);
            CurrentAI = NextAI;
            CurrentWorkTarget = null;
        }
    }


    private float CalculateWork()
    {
        float _workDone = WorkApplied;

        return _workDone;
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
}
