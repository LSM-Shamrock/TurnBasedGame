using UnityEngine;

[AutoInjectionTarget]
public class ConfigManager : SingletonBehaviour<ConfigManager>
{
    [field: SerializeField, AssetField]
    public GameData GameData { get; private set; }

    private void Awake()
    {
        InitSingleton();
    }
}
