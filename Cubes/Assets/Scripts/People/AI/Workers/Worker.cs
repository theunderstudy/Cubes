using UnityEngine;
using UnityEngine.AI;


public class Worker : MonoBehaviour
{
    public delegate void AIFunction();
    public AIFunction CurrentAI;

    public Transform BuildingMaterialCarryPos;
    #region Navigation General
  
    #endregion
    #region Wander
    #endregion
    #region WorkingResource
    private CubeUpgrade CurrentWorkTarget;
    public float WorkApplied = 1;
    public float TimeBetweenWorks = 2;
    #endregion

    #region Building
    public BuildingMaterial CarriedMaterial;

    #endregion
  
    private void Awake()
    {
      
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

  
}
