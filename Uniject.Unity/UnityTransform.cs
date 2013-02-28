using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Uniject.Unity
{
    public class UnityTransform : UnityComponent, ITransform
    {
        public Transform Transform { get; set; }

        public UnityTransform(Transform transform) : base(transform.gameObject.ToUniject())
        {
            this.Transform = transform;
        }

        public Vector3 Position {
            get { return Transform.position.ToUniject(); }
            set { Transform.position = value.ToUnity(); }
        }

        public Vector3 LocalScale {
            get { return Transform.localScale.ToUniject(); }
            set { Transform.localScale = value.ToUnity(); }
        }

        public Quaternion Rotation {
            get { return Transform.rotation.ToUniject(); }
            set { Transform.rotation = value.ToUnity(); }
        }

        public Vector3 Forward {
            get { return Transform.forward.ToUniject(); }
            set { Transform.forward = value.ToUnity(); }
        }

        public Vector3 Up {
            get { return Transform.up.ToUniject(); }
            set { Transform.up = value.ToUnity(); }
        }

        public ITransform Parent {
            get { return Transform.parent.ToUniject(); }
            set { Transform.parent = value.ToUnity(); }
        }

        public void Translate(Vector3 byVector) {
            Transform.Translate(byVector.ToUnity());
        }

        public void LookAt(Vector3 point) {
            Transform.LookAt(point.ToUnity());
        }

        public ITransform Find(string name)
        {
          return Transform.Find (name).ToUniject();
        }

        public Vector3 TransformDirection(Vector3 dir) {
            return Transform.TransformDirection(dir.ToUnity()).ToUniject();
        }

        public IEnumerator<ITransform> GetEnumerator()
        {
          return (from UnityEngine.Transform child in Transform
              select child.ToUniject() as ITransform).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
          return this.GetEnumerator();
        }
    }
}

