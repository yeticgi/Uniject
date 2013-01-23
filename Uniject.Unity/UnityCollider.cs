using System;
using UnityEngine;

namespace Uniject.Unity
{
	class UnityCollider : ICollider
	{
		public readonly Collider Collider;

		public UnityCollider(Collider c)
		{
			throw new NotImplementedException ();
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

