using System.Collections.Generic;

public struct MaterialRequirements
{
    public MaterialTypes BuildingRequirement;
    public int Count;
}
public abstract class Building : CubeUpgrade
{
    public List<MaterialRequirements> RequiredMats;
    
}
