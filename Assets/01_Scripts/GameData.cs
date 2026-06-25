using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[Serializable] 
public class UnitData : TableData
{
    public override int Key => UnitId;
    public int UnitId;
    public string CodeName;
    public string DisplayName;
    public int Health;
    public float Speed;
}

public abstract class TableData
{
    public abstract int Key { get; }
}
public class Table<T> where T : TableData
{
    public IReadOnlyList<T> List { get; }
    public IReadOnlyDictionary<int, T> Dictionary { get; }
    public Table(IReadOnlyList<T> datas)
    {
        List = datas;
        Dictionary = datas.ToDictionary(e => e.Key);
    }
}

[ExcelAsset]
public class GameData : ScriptableObject
{
    [SerializeField]
    private List<UnitData> Unit;

    private Dictionary<Type, object> _tables = new();

    public Table<UnitData> UnitData => GetOrCreateTable(Unit);

    private Table<T> GetOrCreateTable<T>(IReadOnlyList<T> datas) where T : TableData
    {
        if (_tables.TryGetValue(typeof(T), out var obj))
        {
            return (Table<T>)obj;
        }
        else
        {
            var table = new Table<T>(datas);

            _tables.Add(typeof(T), table);

            return table;
        }
    }
}
