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
    public GameObject ImageDisplayButton;

    private bool imagePanelDisplayed = false;

    public void StrategyPanelHide()
    {
        strategyPanelOpen = false;
        strategyPanel.SetActive(false);
    }

    public void BackButton()
    { if (strategyPanelOpen)
        {
            StrategyPanelHide();
            ImageDisplayButton.SetActive(false);
        } else {
            SceneManager.LoadScene("MenuScreen");
        }
    }

    public void StrategyImageDisplay()
    {
        strategyImagePanel.SetActive(!imagePanelDisplayed);
        imagePanelDisplayed = !imagePanelDisplayed;
    }

    public void StrategyFavorite()
    {

    }

    public void StrategyUnfavorite()
    {

    }

}
