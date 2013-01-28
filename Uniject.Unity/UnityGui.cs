using System;
using UnityEngine;

namespace Uniject.Unity
{
	public class UnityGui : IGui
	{
		public string TextArea (Rect position, string text, int maxLength)
		{
			return GUI.TextArea(position.ToUnity(), text, maxLength);
		}

		public string TextField (Rect position, string text, int maxLength)
		{
			return GUI.TextField(position.ToUnity(), text, maxLength);
		}

		public void SetNextControlName (string name)
		{
			GUI.SetNextControlName(name);
		}

		public void FocusControl (string name)
		{
			GUI.FocusControl(name);
		}
	}
}

