using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Networking;

public class DataController : MonoBehaviour
{
    private ConceptData[] allConceptData;
    public int conceptIndex;

    private string dataAsJson;

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

    public string GetConceptModalInfoTitle(int index)
    {
        return allConceptData[index].conceptName;
    }
    public string GetConceptModalInfoDefinition(int index)
    {
        return allConceptData[index].conceptDefintion;
    }


    private void LoadGameData()
    {
    #if UNITY_ANDROID || UNITY_WEBGL
        StartCoroutine("androidLoad");
    #endif
    #if UNITY_IOS
       iOSLoad();
    #endif

    }

    IEnumerator androidLoad()
    {
        
        string testPath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        UnityWebRequest www = UnityWebRequest.Get(testPath);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) { 
        Debug.Log(www.error);
        } else {
            dataAsJson = www.downloadHandler.text; 
        }

        GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);
        allConceptData = loadedData.allConceptData;
    }

    private void iOSLoad()
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, gameDataFileName.ToString());
        dataAsJson = System.IO.File.ReadAllText(filePath);
        GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);
        allConceptData = loadedData.allConceptData;

    }
}