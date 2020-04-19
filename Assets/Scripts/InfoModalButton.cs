using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoModalButton : MonoBehaviour
{
    [SerializeField]
    private int conceptIndex;

    private DataController dataController;
    public string modalCategoryTitleText;
    public string modalCategoryBodyText;

    private bool modalInfoOpen = false;
    public GameObject modalWindow;

    public TextMeshProUGUI modalCategoryTitle;
    public TextMeshProUGUI modalCategoryBody;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        modalCategoryTitleText = dataController.GetConceptModalInfoTitle(conceptIndex);
        modalCategoryBodyText = dataController.GetConceptModalInfoDefinition(conceptIndex);
    }

    public void ModalInfoClick()
    {
        if (modalInfoOpen)
        {
            return;
        }
        else
        {
            modalCategoryTitle.text = modalCategoryTitleText;
            modalCategoryBody.text = modalCategoryBodyText;
            modalWindow.SetActive(true);
        }
    }

}
