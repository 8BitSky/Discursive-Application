using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrategyInfoPane : MonoBehaviour {

    public Text strategyText;

    private StrategyInfo strategyInfo;

    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Setup(StrategyInfo data) {
        strategyInfo = data;
        strategyText.text = strategyInfo.strategyText; 
    }

    //public void HandleClick()
    //{
    //    gameController.AnswerButtonClicked(answerData.isCorrect);
    //}
}
