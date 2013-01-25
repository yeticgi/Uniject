using System;
using UnityEngine;

namespace Uniject.Unity
{
	class UnityCollider : ICollider
	{
		public readonly Collider Collider;

		public UnityCollider(Collider collider)
		{
			this.Collider = collider;
		}

		public bool enabled {
			get;
			set;
		}

		public IPhysicsMaterial material {
			get;
			set;
		}
	}

}

