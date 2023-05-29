using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveMenager : MonoBehaviour
{

    private GameData gameData;

    [SerializeField]
    private string filename;
    [SerializeField]
    private bool encryptData;

    private FileDataHandler fileHandler;

    private CloudDataHandler cloudDataHandler;

    public List<IUpdateGameData> gameDataObjects;

    public static SaveMenager instance { get; private set; }

    // Create Singelton instance for easy access 
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is a SaveMenager instance!");
        }

        instance = this;
    }

    private void Start()
    {
        this.fileHandler = new FileDataHandler(Application.persistentDataPath, filename, encryptData);
        this.cloudDataHandler = new CloudDataHandler(filename, encryptData);
        gameDataObjects = FindAllUpdateGamaDataObjects();
        LoadGameFromFile();
    }


    public void NewGame()
    {
        gameData = new GameData();
    }

    public void SaveGameToFile()
    {
        foreach (var gameDataObject in gameDataObjects)
        {
            gameDataObject.SaveData(ref gameData);
        }

        fileHandler.SaveGame(gameData);
    }

    public void LoadGameFromFile()
    {
        gameData = fileHandler.Load();

        if (gameData == null)
        {
            Debug.LogError("No SaveData to Load");
            NewGame();
        }

        foreach (var gameDataObject in gameDataObjects)
        {
            gameDataObject.LoadData(gameData);
        }
    }

    public void SaveGameToCloud()
    {
        cloudDataHandler.SaveGame(gameData);
    }

    public void LoadGameFromCloud()
    {
        cloudDataHandler.LoadSomeData();
    }

    private List<IUpdateGameData> FindAllUpdateGamaDataObjects()
    {
        IEnumerable<IUpdateGameData> updateGameDataObjects = FindObjectsOfType<MonoBehaviour>().OfType<IUpdateGameData>();

        return new List<IUpdateGameData>(updateGameDataObjects);
    }


}
