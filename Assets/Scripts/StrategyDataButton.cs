using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StrategyDataButton : MonoBehaviour {

    public TextMeshProUGUI strategyNameText;

    private StrategyData strategyData;

    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Setup(StrategyData data) {
        strategyData = data;
        strategyNameText.text = strategyData.strategyName;
        
    }

    public void HandleStrategyClick()
    {
        gameController.StrategyButtonClicked(strategyData);
    }
}
