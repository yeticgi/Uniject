using System;
using UnityEngine;

namespace Uniject.Unity
{
	public class LevelLoadListener : MonoBehaviour {
	    
	    public void Start() {
	        DontDestroyOnLoad(this.gameObject);
	    }
	    
	    public void OnLevelWasLoaded() {
	        UnityInjector.levelScope = new object ();
	    }
	}
}