using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Unity.Services.CloudSave;

public class CloudDataHandler : MonoBehaviour
{
    private string dataFileName;
    private bool encryptData;

    public CloudDataHandler(string dataDirName, bool encryptData)
    {
        this.dataFileName = dataDirName;
        this.encryptData = encryptData;
    }

    public async void LoadSomeData()
    {
        Dictionary<string, string> savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { "Save" });

        Debug.Log("Done: " + savedData["Save"]);
    }

    public async void SaveGame(GameData gameData)
    {
        string dataToStore = JsonUtility.ToJson(gameData, true);
        var data = new Dictionary<string, object> { { "Save", dataToStore } };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
    }
}
