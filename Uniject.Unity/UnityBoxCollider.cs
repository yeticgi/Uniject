using System;
using UnityEngine;

namespace Uniject.Unity {
    public class UnityBoxCollider : IBoxCollider {
        private BoxCollider box;
        private UnityPhysicsMaterial mat;

        public UnityBoxCollider(GameObject obj) {
            box = obj.GetComponent<BoxCollider>();
            if (null == box) {
                box = obj.AddComponent<BoxCollider>();
            }
        }

        public Vector3 center {
            get { return box.center.ToUniject(); }
            set { box.center = value.ToUnity(); }
        }

        public Vector3 size {
            get { return box.size.ToUniject(); }
            set { box.size = value.ToUnity(); }
        }

        public bool enabled {
            get { return box.enabled; }
            set { box.enabled = value; }
        }

        public IPhysicsMaterial material {
            get { return mat; }
            set {
                mat = (UnityPhysicsMaterial) value;
                box.material = mat.material;
            }
        }
    }
}

