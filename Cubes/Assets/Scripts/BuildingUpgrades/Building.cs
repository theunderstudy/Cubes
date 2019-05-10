using System.Collections.Generic;
public abstract class Building : CubeUpgrade
{
    public struct MaterialRequirements
    {
        public MaterialTypes BuildingRequirement;
        public int Count;
    }
    public List<MaterialRequirements> RequiredMats;
    
}
