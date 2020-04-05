using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreenController : MonoBehaviour {

    [SerializeField] private GameObject menuPanel;
    private bool menuActive = false;

	public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToggleMenu()
    {
        menuActive = !menuActive;
        menuPanel.SetActive(menuActive);
    }
}
