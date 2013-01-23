using System;
using UnityEngine;
using System.Xml.Linq;

namespace Uniject.Unity
{
    public class UnityResourceLoader : Uniject.IResourceLoader {
        public IAudioClip loadClip(string path) {
            var result = (AudioClip)Resources.Load(path);
            if (null == result) {
                throw new NullReferenceException();
            }

            return result.ToUniject();
        }

        public IMaterial loadMaterial(string path) {
            return ((Material)Resources.Load(path)).ToUniject();
        }
		
		public XDocument loadDoc(string path) {
            TextAsset textAsset = (TextAsset) Resources.Load(path);
            return XDocument.Parse(textAsset.text);
        }

        public IGameObject instantiate(string path) {
            GameObject obj = (GameObject) GameObject.Instantiate(Resources.Load(path));
            return new UnityGameObject(obj);
        }

        public T loadResource<T>(string path) where T : class, IUnityObject {
            return UnityEngine.Resources.Load(path) as T;
        }
    }
}

