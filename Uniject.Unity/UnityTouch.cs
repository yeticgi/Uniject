using System;
using UnityEngine;

namespace Uniject.Unity
{
	public class UnityTouch : ITouch
	{
		public readonly Touch Touch;

		public UnityTouch(Touch touch)
		{
			this.Touch = touch;
		}

		public Vector2 Position {
			get {
				return Touch.position.ToUniject ();
			}
		}
	}

}

