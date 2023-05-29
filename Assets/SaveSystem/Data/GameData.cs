using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //Data to save 
    public SerializableDictionary<string, bool> someDictionaryData;
    public SerializableDictionary<string, bool> anotherDictionaryData;

    //Basic values when we create new GameData

    public GameData()
    {
        someDictionaryData = new SerializableDictionary<string, bool>();
        anotherDictionaryData = new SerializableDictionary<string, bool>();
    }


}
