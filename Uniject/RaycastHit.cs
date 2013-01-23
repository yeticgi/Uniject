using System;

namespace Uniject
{
	/// <summary>
	/// Testable equivalent to UnityEngine.RaycastHit.
	/// </summary>
	public struct RaycastHit
	{
		public Vector3 point { get; private set; }
		public Vector3 normal { get; private set; }
		public Vector3 barycentricCoordinate { get; private set; }
		public float distance { get; private set; }
		public int triangleIndex { get; private set; }
		public Vector2 textureCoord { get; private set; }
		public Vector2 textureCoord2 { get; private set; }
		public Vector2 lightmapCoord { get; private set; }
		
		/// <summary>
		/// The TestableGameObject we hit, or null if we hit a non Testable.
		/// </summary>
		public IGameObject hit { get; private set; }
		
		/// <summary>
		/// Non testable, included to support legacy game objects.
		/// </summary>
		public ICollider collider { get; private set; }
		
		public RaycastHit(Vector3 point,
		                  Vector3 normal,
		                  Vector3 barycentricCoordinate,
		                  float distance,
		                  int triangleIndex,
		                  Vector2 textureCoord,
		                  Vector2 textureCoord2,
		                  Vector2 lightmapCoord,
		                  IGameObject hit,
		                  ICollider collider) : this() {
			this.point = point;
			this.normal = normal;
			this.barycentricCoordinate = barycentricCoordinate;
			this.distance = distance;
			this.triangleIndex = triangleIndex;
			this.textureCoord = textureCoord;
			this.textureCoord2 = textureCoord2;
			this.lightmapCoord = lightmapCoord;
			this.hit = hit;
			this.collider = collider;
		}
	}
}

