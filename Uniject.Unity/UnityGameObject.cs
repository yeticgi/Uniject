using System.Collections.Generic;
using System;
using UnityEngine;
using Uniject;
using System.Linq;

namespace Uniject.Unity {
    public class UnityGameObject : IGameObject
	{
		private List<IComponent> components = new List<IComponent>();
		
		public IComponent Bridge { get { return bridge as IComponent; } }
		private UnityBridgeComponent bridge;
		
		public ITransform Transform { get; private set; }

		public readonly GameObject GameObject;

		public UnityGameObject(GameObject gameObject)
		{
			this.GameObject = gameObject;
			this.bridge = gameObject.AddComponent<UnityBridgeComponent>();
			this.bridge.GameObject = this;
			this.Transform = gameObject.transform.ToUniject();
		}
		
		public void RegisterComponent(IComponent component) {
			components.Add(component);
			component.Awake();
		}
		
		public bool destroyed { get; private set; }
		
		public void Update() {
			if (active) {
				for (int t = 0; t < components.Count; t++) {
					IComponent component = components[t];
					component.Update();
				}
			}
		}

		public void DontDestroyOnLoad ()
		{
			GameObject.DontDestroyOnLoad (GameObject);
		}
		
		public void OnGUI() {
			if (active) {
				for (int t = 0; t < components.Count; t++) {
					IComponent component = components[t];
					component.OnGUI();
				}
			}
		}
		
		public IEnumerable<IComponent> GetComponents()
		{
			return components;
		}

		public T[] GetComponentsInChildren<T> () where T : class
		{
			return typeof(GameObject).GetMethod("GetComponentsInChildren").MakeGenericMethod(new [] { typeof(T) }).Invoke(GameObject, new object[0]) as T[];
		}

		public T GetComponentInChildren<T> () where T : class
		{
			return typeof(GameObject).GetMethod("GetComponentInChildren").MakeGenericMethod(new [] { typeof(T) }).Invoke(GameObject, new object[0]) as T;
		}
		
		public void CollisionEnter(Collision c) {
			for (int t = 0; t < components.Count; t++) {
				components[t].CollisionEnter(c);
			}
		}

        public void Destroy() {
			if (!destroyed) {
				foreach (UnityComponent component in this.components) {
					component.OnDestroy();
				}
				destroyed = true;
			}
            GameObject.Destroy (this.GameObject);
        }

        public bool active {
            get { return GameObject.active; }
            set { GameObject.active = value; }
        }

        public string Name {
            get { return GameObject.name; }
            set { GameObject.name = value; }
        }

        public void setActiveRecursively(bool active) {
            GameObject.SetActiveRecursively(active);
        }

        public T GetComponent<T>() where T : class
        {
			for (int t = 0; t < components.Count; t++) {
				IComponent component = components[t];
				if (component is T) {
					return component as T;
				}
			}

            if (GameObject != null)
            {
                var component = GameObject.GetComponents(typeof(T)).FirstOrDefault() as T;
                
                if (component != null)
                {
                    return component;
                }
            }

            return null;
        }


        public int layer {
            get { return GameObject.layer; }
            set { GameObject.layer = value; }
        }
    }
}
