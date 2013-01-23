using System;
using UnityEngine;

namespace Uniject.Unity
{
	class UnityMaterial : IMaterial
	{
		public readonly Material Material;

		public UnityMaterial(Material material)
		{
			this.Material = material;
		}
	}

}

