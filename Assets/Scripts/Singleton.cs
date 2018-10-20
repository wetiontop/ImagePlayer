using UnityEngine;

public abstract class Singleton<T> where T : class, new() {
    protected static T _instance = null;
    public static T Instance {
        get {
            if (null == _instance) {
                _instance = new T();
            }
            return _instance;
        }
    }

    protected Singleton() {
        if (_instance != null) {
            Debug.LogError("This " + (typeof(T)).ToString() + " Singleton Instance is not null !!!");
        }
        Init();
    }

    public virtual void Init() {

    }
}