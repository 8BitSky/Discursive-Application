using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

    private DataController dataController;

    [SerializeField]
    private int conceptIndex;

    GameObject levelInfoPane;

    private void Start()
    {
        dataController = FindObjectOfType<DataController>();
    }

    public void LevelHandleClick()
    {
        dataController.SetCurrentConcept(conceptIndex);
        SceneManager.LoadScene("StrategyScreen");
    }

    public void LevelInfoClick()
    {

        levelInfoPane.SetActive(true);
    }

    public void LevelInfoClose()
    {

    }
}
