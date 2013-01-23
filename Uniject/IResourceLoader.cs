using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

namespace Uniject {
    public interface IResourceLoader {
        IAudioClip loadClip(string path);
        IMaterial loadMaterial(string path);
		XDocument loadDoc(string path);
        IGameObject instantiate(string path);
        T loadResource<T>(string path) where T : class, IUnityObject;
    }
}

