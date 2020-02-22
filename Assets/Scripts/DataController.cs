using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour
{
    private ConceptData[] allConceptData;
    public int conceptIndex;


    private PlayerProgress playerProgress;

    private string gameDataFileName = "data.json";

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadGameData();
        SceneManager.LoadScene("MenuScreen");
    }

    public void SetCurrentConcept(int selectedConcept)
    {
        conceptIndex = selectedConcept;
    }

    public ConceptData GetCurrentConceptData()
    {
        return allConceptData[conceptIndex];
    }

     private void LoadGameData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

            allConceptData = loadedData.allConceptData;

        } else
        {
            Debug.LogError("Cannot Load Game Data!");
        }
    }
}
