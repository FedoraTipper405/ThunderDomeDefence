using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    // Property to access the singleton instance
    public static T Instance
    {
        get
        {
            // If the instance is not already set, create a new instance
            if (_instance == null)
            {
                var singletonObject = new GameObject(typeof(T).Name);
                _instance = singletonObject.AddComponent<T>();
                // Make sure the singleton instance persists across scene loads
                //DontDestroyOnLoad(singletonObject);
            }
            // Return the instance
            return _instance;
        }
    }
    // Protected METHODS: -----------------------------------------------------------------------
    // Ensure the instance isn't destryoyed when loading a new scene
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            // If the object has a parent, detach it to prevent it from being destroyed
            if (transform.parent != null)
            {
                transform.SetParent(null);
            }
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another instance already exists, destroy this one
            Destroy(gameObject);
        }
    }
    // Clear the instance when the object is destroyed
    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
