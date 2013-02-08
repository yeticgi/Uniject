using System;
using System.Collections;

namespace Uniject.Unity
{
    public class UnityComponent : IComponent
	{
		public IGameObject GameObject { get; private set; }

        public bool enabled { get; set; }

        public UnityComponent(IGameObject obj) {
            this.enabled = true;
            this.GameObject = obj;
            obj.RegisterComponent(this);
        }

        public IGameObject Obj {
            get { return GameObject; }
            set { GameObject = value; }
        }

        public void OnUpdate() {
            if (enabled) {
                Update();
            }
        }

        public void StartCoroutine(string coroutine, params object[] args)
        {
            GameObject.Bridge.StartCoroutine (this, coroutine, args);
        }

		public void StartCoroutine (string coroutine)
		{
			GameObject.Bridge.StartCoroutine(this, coroutine, new object[0]);
		}

        public void StartCoroutine(IEnumerator coroutine)
        {
            GameObject.Bridge.StartCoroutine(coroutine);
        }

        public void StopCoroutines()
        {
            GameObject.Bridge.StopCoroutine("CoroutineBridge");
        }

		public void StopCoroutine(string coroutine)
		{
			GameObject.Bridge.StopCoroutine(coroutine);
		}

        public virtual void Awake()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void OnDestroy()
        {
        }

        public virtual void OnGUI()
        {
        }

        public virtual void CollisionEnter(ICollision collision)
        {
        }
    }
}

