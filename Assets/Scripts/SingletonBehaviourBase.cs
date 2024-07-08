using UnityEngine;
    
public class SingletonBehaviourBase<T> : MonoBehaviour where T: SingletonBehaviourBase<T>
{
    public static T instance { get; protected set; }
     
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            throw new System.Exception("An instance of this singleton already exists.");
        }
        instance = (T)this;
    }
}
