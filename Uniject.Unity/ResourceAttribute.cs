using System;

namespace Uniject.Unity
{
	/// <summary>
	/// Denotes a parameter should be loaded as a Resource from a specified path.
	/// Suitable for prefabs, audio clips etc.
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Parameter)]
	public class ResourceAttribute : Attribute {
		public string Path { get; private set; }
		public ResourceAttribute(string path) {
			this.Path = path;
		}
	}
}

