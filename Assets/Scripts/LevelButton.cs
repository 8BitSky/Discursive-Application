using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

    //Allows concept index to be set on button to pull from content array
    //Level is equivalent to card category

    private DataController dataController;

    [SerializeField]
    private int conceptIndex;

    //Going to use this to allow for "i" button to display card category description
    //See LevelInfoClick()
    //GameObject levelInfoPane;

    private void Start()
    {
        dataController = FindObjectOfType<DataController>();
    }

    public void LevelHandleClick()
    {
        dataController.SetCurrentConcept(conceptIndex);
        SceneManager.LoadScene("StrategyScreen");
    }

    //public void LevelInfoClick()
    //{
    //    levelInfoPane.SetActive(true);
    //}

}
