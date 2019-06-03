using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPreReq : GoalPrereqs
{
    public MaterialRequirements RequiredMats;
    private List<BuildingMaterial> Mats;
    public override bool RequirementsMet()
    {
        Mats = LandMan.Instance.GetMaterial(RequiredMats.BuildingRequirement);
        if (Mats.Count > RequiredMats.Count)
        {
            return true;
        }

        // Add job to gather resources

        return false;
    }
}
