using System;
using UnityEngine;

namespace Uniject.Unity
{
	public class UnityApplication : IApplication
	{
		public RuntimePlatform Platform {
			get {
				return (RuntimePlatform)Application.platform;
			}
		}
	}
}

