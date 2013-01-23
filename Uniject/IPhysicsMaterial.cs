using System;

namespace Uniject
{
    public interface IPhysicsMaterial : IUnityObject
	{
        float dynamicFriction { get; set; }
        float staticFriction { get; set; }
        float bounciness { get; set; }
        Vector3 frictionDirection2 { get; set; }
        float dynamicFriction2 { get; set; }
        float staticFriction2 { get; set; }
        PhysicMaterialCombine frictionCombine { get; set; }
        PhysicMaterialCombine bounceCombine { get; set; }
    }
}

