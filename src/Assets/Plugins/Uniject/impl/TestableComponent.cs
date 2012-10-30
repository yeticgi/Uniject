using System;
using System.Collections;

namespace Uniject {
    public class TestableComponent {
        private TestableGameObject obj;

        public bool enabled { get; set; }

        public TestableComponent(TestableGameObject obj) {
            this.enabled = true;
            this.obj = obj;
            obj.registerComponent(this);
        }
        
        public TestableGameObject Obj {
            get { return obj; }
            set { obj = value; }
        }

        public void OnUpdate() {
            if (enabled) {
                Update();
            }
        }

        public void StartCoroutine(IEnumerator cr)
        {
            obj.bridge.StartCoroutine(cr);   
        }


        public virtual void Update() {
        }

        public virtual void OnDestroy() {
        }

        public virtual void OnCollisionEnter(Collision collision) {
        }
    }
}

