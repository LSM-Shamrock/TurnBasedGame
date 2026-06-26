using UnityEngine;

public interface ISceneInstance<T> where T : MonoBehaviour, ISceneInstance<T>
{
    private static T s_sceneInstance;
    public static T SceneInstance
    {
        get
        {
            if (s_sceneInstance == null)
                s_sceneInstance = Component.FindAnyObjectByType<T>();

            return s_sceneInstance;
        }
    }

    public void InitSceneInstance()
    {
        s_sceneInstance = (T)this;
    }
}
