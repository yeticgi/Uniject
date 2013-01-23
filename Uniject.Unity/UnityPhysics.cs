using System;
using Uniject;
using UnityEngine;

namespace Uniject.Unity
{
    /// <summary>
    /// Bridges UnityEngine.Physics to Uniject.Physics.
    /// </summary>
    public class UnityPhysics : IPhysics {

        public bool Raycast(Vector3 origin, Vector3 direction, float distance, int layerMask) {
			return UnityEngine.Physics.Raycast(origin.ToUnity(), direction.ToUnity(), distance, layerMask);
        }

        public bool Raycast(Vector3 origin, Vector3 direction, out Uniject.RaycastHit hitinfo, float distance, int layerMask) {
            UnityEngine.RaycastHit unityHit = new UnityEngine.RaycastHit();
			bool result = UnityEngine.Physics.Raycast(origin.ToUnity(), direction.ToUnity(), out unityHit, distance, layerMask);

            if (result) {

                IGameObject testable = null;
                var bridge = unityHit.collider.gameObject.GetComponent<UnityBridgeComponent>();
                if (null != bridge) {
                    testable = bridge.wrapping;
                }

                hitinfo = new RaycastHit (unityHit.point.ToUniject(),
				                          unityHit.normal.ToUniject(),
                                         unityHit.barycentricCoordinate.ToUniject(),
                                         unityHit.distance,
                                         unityHit.triangleIndex,
                                         unityHit.textureCoord.ToUniject(),
                                         unityHit.textureCoord2.ToUniject(),
                                         unityHit.lightmapCoord.ToUniject(),
                                         testable,
                                         unityHit.collider.ToUniject());
            } else {
                hitinfo = new RaycastHit();
            }

            return result;
        }
    }
}
