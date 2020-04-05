using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.Networking;

public class GameController : MonoBehaviour {

    public SimpleObjectPool strategyButtonObjectPool;

    public TextMeshProUGUI strategyTitle;
    public TextMeshProUGUI strategyInfo;
    public GameObject strategyPanel;

    public GameObject strategyImageGO;
    public Image stratImage;
    private FileInfo[] allFiles;


    public RectTransform strategyScrollView;
    public GameObject strategySelectionPanel;

    public TextMeshProUGUI conceptTitleText;
    public Transform DSSelectionPanel;

    private DataController dataController;
    private ConceptData currentConceptData;
    private StrategyData[] strategyPool;
    private UIController uIController;

    //private int questionIndex;


    private List<GameObject> strategyButtonGameObjects = new List<GameObject>();
    private string currentImageName;

    void Start()
    {
        //References
        dataController = FindObjectOfType<DataController>();
        currentConceptData = dataController.GetCurrentConceptData();
        strategyPool = currentConceptData.strategyData;
        uIController = FindObjectOfType<UIController>();
        //Disable overlay
        strategyPanel.SetActive(false);
        //Set Header Text
        conceptTitleText.text = currentConceptData.conceptName;
        //Populate Strategy Buttons
        ShowStrategies();
        //Attempt to get images loading
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        //Debug.Log("Streaming Assets Path: " + Application.streamingAssetsPath);
        allFiles = directoryInfo.GetFiles("*.*");
        //foreach (FileInfo file in allFiles) { 
        //Debug.Log(file);
        //}

    }
	
    private void ShowStrategies()
    {
        //Return buttons to obj pool
        RemoveStrategyButtons();
        //Create new buttons from obj pool
        for (int i = 0; i < strategyPool.Length; i++)
        {
            GameObject strategyButtonGameObject = strategyButtonObjectPool.GetObject();
            strategyButtonGameObjects.Add(strategyButtonGameObject);
            strategyButtonGameObject.transform.SetParent(DSSelectionPanel, false);
            StrategyDataButton strategyDataButton = strategyButtonGameObject.GetComponent<StrategyDataButton>();
            strategyDataButton.Setup(strategyPool[i]);
        }
    }

    private void RemoveStrategyButtons()
    {
        while(strategyButtonGameObjects.Count > 0)
        {
            strategyButtonObjectPool.ReturnObject(strategyButtonGameObjects[0]);
            strategyButtonGameObjects.RemoveAt(0);
        }
    }


    public void StrategyButtonClicked(StrategyData data)
    {
        //Set Strategy Data
        strategyTitle.text = data.strategyName;
        strategyInfo.text = data.strategyInfo[0].strategyText;
        currentImageName = data.strategyInfo[0].strategySpriteName;

        //Set Strategy Position
        Vector3 position = strategyInfo.transform.position;
        position[1] = 0;
        strategyInfo.transform.position = position;
        
        //Set Strategy Image
        if (currentImageName != "")
        {
            if (Application.platform == RuntimePlatform.WindowsEditor) {
                foreach (FileInfo file in allFiles)
                {
                    if (file.Name.Contains(currentImageName))
                    {
                        StartCoroutine("LoadStrategyImage", file);
                    }
                }
            } else if (Application.platform == RuntimePlatform.Android) { 
                StartCoroutine("LoadStrategyImageAndroid", currentImageName);
            }
        StrategyImageDisplay();
        }
        else
        {
            StrategyImageHide();
        }

        //Display Strategy Panel
        uIController.strategyPanelOpen = true;
        strategyPanel.SetActive(true);
    }



    private void StrategyImageDisplay()
    {
        strategyImageGO.SetActive(true);
    }


    private void StrategyImageHide()
    {
        strategyImageGO.SetActive(false);
    }


    IEnumerator LoadStrategyImage(FileInfo file)
    {
        if (file.Name.Contains("meta"))
        {
            yield break;
        }
        else
        {
            string wwwImageFilePath = "file://" + file.ToString();
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(wwwImageFilePath);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Texture2D imageTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
                stratImage.sprite = Sprite.Create(imageTexture, new Rect(0, 0, imageTexture.width, imageTexture.height), new Vector2(0.5f, 0.5f));
            }
        }
    }


    IEnumerator LoadStrategyImageAndroid(string fileName)
    {
        Debug.Log(fileName);
        Debug.Log("LoadStrategyImageAndroid Started 1");
        string wwwImageFilePath = Path.Combine(Application.streamingAssetsPath + "/", fileName);
        Debug.Log("Image Path: " + wwwImageFilePath);
       UnityWebRequest www = UnityWebRequestTexture.GetTexture(wwwImageFilePath);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Attempting To create sprite 2");
            Texture2D imageTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
            stratImage.sprite = Sprite.Create(imageTexture, new Rect(0, 0, imageTexture.width, imageTexture.height), new Vector2(0.5f, 0.5f));
            Debug.Log("Sprite created 3");
        }
    }
}




