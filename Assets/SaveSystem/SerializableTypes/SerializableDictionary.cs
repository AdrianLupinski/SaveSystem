using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    private List<TKey> keys = new List<TKey>();
    private List<TValue> values = new List<TValue>();

    public void OnAfterDeserialize()
    {
        keys.Clear();
        values.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnBeforeSerialize()
    {
        this.Clear();

        if (keys.Count != values.Count)
        {
            Debug.LogError("Keys count" +  keys.Count + "is not equals to values count" +  values.Count);
        }

        for (int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }
}
