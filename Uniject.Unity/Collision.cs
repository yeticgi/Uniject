using System;
using UnityEngine;

namespace Uniject {
    public class Collision : ICollision
	{
        public Vector3 relativeVelocity { get; private set; }
        public ITransform transform { get; private set; }
        public IGameObject gameObject { get; private set; }
        public ContactPoint[] contacts { get; private set; }

        public Collision(Vector3 relativeVelocity,
                         ITransform transform,
                         IGameObject gameObject,
                         ContactPoint[] contacts)
		{
            this.relativeVelocity = relativeVelocity;
            this.transform = transform;
            this.gameObject = gameObject;
            this.contacts = contacts;
        }
    }
}

