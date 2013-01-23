using System;

namespace Uniject {
	
    /// <summary>
    /// Extracted from UnityEngine.Physics.
    /// </summary>
    public interface IPhysics {

        bool Raycast(Vector3 origin, Vector3 direction, float distance, int layerMask);
        bool Raycast(Vector3 origin, Vector3 direction, out Uniject.RaycastHit hitinfo, float distance, int layerMask);
    }
}

