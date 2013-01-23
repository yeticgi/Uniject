using System;
using UnityEngine;

namespace Uniject.Unity
{
    public class UnityTransform : ITransform {

        private Transform transform { get; set; }

        public UnityTransform (Transform transform) {
            this.transform = transform;
        }

        public Vector3 Position {
            get { return transform.position.ToUniject(); }
            set { transform.position = value.ToUnity(); }
        }

        public Vector3 localScale {
            get { return transform.localScale.ToUniject(); }
            set { transform.localScale = value.ToUnity(); }
        }

        public Quaternion Rotation {
            get { return transform.rotation.ToUniject(); }
            set { transform.rotation = value.ToUnity(); }
        }

        public Vector3 Forward {
            get { return transform.forward.ToUniject(); }
            set { transform.forward = value.ToUnity(); }
        }

        public Vector3 Up {
            get { return transform.up.ToUniject(); }
            set { transform.up = value.ToUnity(); }
        }

        private ITransform actualParent;
        public ITransform Parent {
            get { return actualParent; }
            set {
                this.transform.parent = ((UnityTransform)value).transform;
                this.actualParent = value;
            }
        }

        public void Translate(Vector3 byVector) {
            transform.Translate(byVector.ToUnity());
        }

        public void LookAt(Vector3 point) {
            transform.LookAt(point.ToUnity());
        }

        public Vector3 TransformDirection(Vector3 dir) {
            return transform.TransformDirection(dir.ToUnity()).ToUniject();
        }
    }
}

