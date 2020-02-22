using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour {

    public SimpleObjectPool strategyButtonObjectPool;

    public TextMeshProUGUI strategyTitle;
    public TextMeshProUGUI strategyInfo;
    public GameObject strategyPanel;
    public GameObject strategyImage;
    public GameObject ImageDisplayButton;

    public GameObject strategySelectionPanel;

    public TextMeshProUGUI conceptTitleText;
    public Transform DSSelectionPanel;

    private DataController dataController;
    private ConceptData currentConceptData;
    private StrategyData[] strategyPool;
    private UIController uIController;

    //private int questionIndex;


    private List<GameObject> strategyButtonGameObjects = new List<GameObject>();


	void Start () {
        dataController = FindObjectOfType<DataController>();
        currentConceptData = dataController.GetCurrentConceptData();
        strategyPool = currentConceptData.strategyData;
        uIController = FindObjectOfType<UIController>();
        strategyPanel.SetActive(false);

        conceptTitleText.text = currentConceptData.conceptName;

        ShowStrategies();

    }
	
    private void ShowStrategies()
    {
        RemoveStrategyButtons();

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
        //Set Strategy Position
        Vector3 position = strategyInfo.transform.position;
        position[1] = 0;
        strategyInfo.transform.position = position;
        //Set Strategy Image
        if (data.strategyInfo[0].strategySprite)
        {
            strategyImage.GetComponent<Image>().sprite = data.strategyInfo[0].strategySprite;
            ImageDisplayButton.SetActive(true);
        }
        //Show Strategy Info Panel
        uIController.strategyPanelOpen = true;
        strategyPanel.SetActive(true);
    }

    public void RandomStrategy()
    {
        int rNumber = Random.Range(0, strategyButtonGameObjects.Count);
        StrategyButtonClicked(currentConceptData.strategyData[rNumber]);

    }

}
