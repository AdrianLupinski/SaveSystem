using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdateGameData
{
    //Interface to implement for a classes that need to update data when we save or load game

    public void SaveData(ref GameData data);

    public void LoadData(GameData data);


}
