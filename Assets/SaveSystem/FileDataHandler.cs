using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler : MonoBehaviour
{
    private string dataDirPath;
    private string dataFileName;
    private bool encryptData;

    public FileDataHandler(string dataDirPath, string dataDirName, bool encryptData)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataDirName;
        this.encryptData = encryptData;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                return loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch(Exception e)
            {
                Debug.LogError("Failed to load a data from path " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void SaveGame(GameData gameData)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(gameData, true);

            //if (encryptData)
            //{
            //    dataToStore = EncryptData(dataToStore)
            //}

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed save data in" + fullPath + "\n" + e);
        }
    }

    //private string EncryptData(string Data)
    //{

    //}
}
