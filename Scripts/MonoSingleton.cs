using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<Singleton> : MonoBehaviour where Singleton : MonoSingleton<Singleton>
{
    private static Singleton _instance;

    public static Singleton Instance
    {
        get
        {
            if(_instance == null )
            {
                Debug.Log(typeof(Singleton).ToString() + " is Null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = (Singleton)this;
        _instance = this as Singleton;
    }
}
