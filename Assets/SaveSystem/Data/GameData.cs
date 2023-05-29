using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //Data to save 

    public int someInt;

    SerializableDictionary<string, bool> someDictionaryData;

    SerializableDictionary<string, bool> anotherDictionaryData;

    //Basic values when we create new GameData
    public GameData()
    {
        this.someInt = 0;
        someDictionaryData = new SerializableDictionary<string, bool>();
        anotherDictionaryData = new SerializableDictionary<string, bool>();
    }


}
