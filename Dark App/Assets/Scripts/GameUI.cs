using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("Windows")]
    [SerializeField] private CanvasScaler canvasScaler;
    [SerializeField] private GameObject StartWindow;
    [SerializeField] private GameObject ReadyWindow;
    [SerializeField] private GameObject ResultRetryWindow;

    [Header("Labels")]
    [SerializeField] private TextMeshProUGUI[] GamesPlayedText;
    [SerializeField] private TextMeshProUGUI[] SecretRevealText;
    [SerializeField] private TextMeshProUGUI ReadyText;
    public TextMeshProUGUI Timer;

    [Header("Animations & Effects")]
    [SerializeField] private Image ResultSymbol;

    public void ShowStartScreen()
    {
        if (!Application.isEditor)
            canvasScaler.scaleFactor = (Screen.dpi / 96.0f) * 0.618f;
        StartWindow.SetActive(true);
        ReadyWindow.SetActive(false);
        ResultRetryWindow.SetActive(false);
    }

    public void ShowReadyScreen()
    {
        StartWindow.SetActive(false);
        ReadyWindow.SetActive(true);
        ResultRetryWindow.SetActive(false);
    }

    public void StartGameScreen()
    {
        StartWindow.SetActive(false);
        ReadyWindow.SetActive(false);
        ResultRetryWindow.SetActive(false);
    }

    public void ShowResultsScreen()
    {
        StartWindow.SetActive(false);
        ReadyWindow.SetActive(false);
        ResultRetryWindow.SetActive(true);
    }

    public void SetResultSymbol(Sprite sprite) => ResultSymbol.sprite = sprite;

    public void SetTexts(int GamesPlayed, int RevealSceretGamesLeft) 
    {
        foreach (var g in GamesPlayedText)
            g.text = string.Format("GAMES PLAYED: {0}", GamesPlayed);
        foreach (var g in SecretRevealText)
            g.text = string.Format("Games left to reveal a secret: {0}", RevealSceretGamesLeft);
    }

    public void SetGameTimer(float GameTimer) => ReadyText.text = $"You'll have {(int)GameTimer} seconds to find your symbol.\nready?";
    
}
