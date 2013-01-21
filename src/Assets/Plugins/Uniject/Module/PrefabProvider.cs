using Ninject;
using System;
using Uniject;
using System.Linq;
using UnityEngine;

/// <summary>
/// Denotes a parameter should be loaded as a Resource from a specified path.
/// Suitable for prefabs, audio clips etc.
/// </summary>
using System.Collections.Generic;
using Uniject.Impl;


[System.AttributeUsage(System.AttributeTargets.Parameter)]
public class Resource : System.Attribute {
    public string Path { get; private set; }
    public Resource(string path) {
        this.Path = path;
    }
}

/// <summary>
/// A <c>Provider</c> that instantiates Unity prefabs wrapped as <c>TestableGameObject</c>.
/// </summary>
public class PrefabProvider : Ninject.Activation.Provider<TestableGameObject> {

    private IResourceLoader loader;

    public PrefabProvider(IResourceLoader loader) {
        this.loader = loader;
    }

    protected override TestableGameObject CreateInstance(Ninject.Activation.IContext context)
    {
        Resource attrib = (Resource)context.Request.Target.GetCustomAttributes(typeof(Resource), false).FirstOrDefault();
        if (attrib == null)
        {
            return new UnityGameObject(new GameObject());
        }
        return loader.instantiate(attrib.Path);
    }
}
