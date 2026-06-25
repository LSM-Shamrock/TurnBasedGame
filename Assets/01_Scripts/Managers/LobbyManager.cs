using UnityEngine;
using System.Linq;

public class LobbyManager : SingletonBehaviour<LobbyManager>
{
    private UnitData[] _selectedUnits;
    public UnitData[] SelectedUnits
    {
        get
        {
            if (_selectedUnits == null)
                _selectedUnits = ConfigManager.Instance.GameData.UnitData.List.Take(3).ToArray();

            return _selectedUnits;
        }
    }

    private void Awake()
    {
        InitSingleton();
    }
}
