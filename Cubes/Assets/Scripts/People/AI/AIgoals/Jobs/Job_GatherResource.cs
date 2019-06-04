using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job_GatherResource : Job
{
    public override void AssignWorkerToJob(Worker workerToAssign)
    {
        WorkerAssignedToJob = workerToAssign;
        // Implement AI for worker

    }
}
