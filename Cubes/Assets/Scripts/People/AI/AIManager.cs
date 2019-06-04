using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : Singleton<AIManager>
{
    // Have a series of goals
    public List<Goal> Goals;
    // List of jobs required to achieve a goal
    public List<Job> Jobs;
}
