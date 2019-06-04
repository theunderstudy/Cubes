using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Job : MonoBehaviour
{
    public Worker WorkerAssignedToJob;

    public abstract void AssignWorkerToJob(Worker workerToAssign);
}
