using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelButton : MonoBehaviour {

    //Allows concept index to be set on button to pull from content array
    //Level is equivalent to card category

    private DataController dataController;

    [SerializeField]
    private int conceptIndex;
   
    private void Start()
    {
        dataController = FindObjectOfType<DataController>();
    }

    public void LevelHandleClick()
    {
        dataController.SetCurrentConcept(conceptIndex);
        SceneManager.LoadScene("StrategyScreen");
    }


}
