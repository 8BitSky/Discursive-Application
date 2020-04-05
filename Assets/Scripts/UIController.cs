using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public GameObject strategyPanel;
    public GameObject strategyImagePanel;
    public bool strategyPanelOpen = false;

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                BackButton();
                //Application.Quit();
            }
        }
    }

    public void StrategyPanelHide()
    {
        strategyPanelOpen = false;
        strategyPanel.SetActive(false);
    }

    public void BackButton()
    { if (strategyPanelOpen)
        {
            StrategyPanelHide();
        } else {
            SceneManager.LoadScene("MenuScreen");
        }
    }

}
