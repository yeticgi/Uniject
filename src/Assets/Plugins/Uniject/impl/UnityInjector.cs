using System;
using Ninject;
using Ninject.Injection;
using UnityEngine;

public class UnityInjector
{
    private static IKernel kernel;
    
    public static IKernel get() {
        if (null == kernel) {
            kernel = new StandardKernel (new UnityNinjectSettings (), new Ninject.Modules.INinjectModule[] {
                new UnityModule ()
            } );
            
            GameObject listener = new GameObject();
            GameObject.DontDestroyOnLoad(listener);
            listener.name = "LevelLoadListener";
            listener.AddComponent<LevelLoadListener>();
        }
        return kernel;
    }
    
    private static object _levelScope = new object();
    public static object levelScope {
        get { return _levelScope; }
        set
        {
            _levelScope = value;
            kernel = null;
        }
    }

    private static object scoper(Ninject.Activation.IContext context) {
        return levelScope;
    }
}

