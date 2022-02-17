using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Rules & Settings")]
    [SerializeField] private float GameTimerDelayLength = 5;


    [Header("Scripts & Controll")]
    [SerializeField] private GameUI gameUi;
    [SerializeField] private SymbolTable symbolTable;

    private float timer = 0;
    private float lerp = 0;
    private int GamesPlayed = 0;
    private int GamesLeftToSecret = 67;

    private void Start()
    {
        LoadGameStats();
        ShowStart();
    }
    private void Update()
    {
        if (timer > 0) 
        {
            UpdateTimer();
            if (timer <= Time.time) 
            {
                ResetTimer();
                ShowResults();
            }
        }
    }
    public void ShowStart() 
    {
        gameUi.ShowStartScreen();
        gameUi.SetGameTimer(GameTimerDelayLength);
        symbolTable.SetDefaultView();
        gameUi.SetTexts(GamesPlayed, GamesLeftToSecret);
    }
    public void ShowReady() 
    {
        gameUi.ShowReadyScreen();
    }

    public void StartGame()
    {
        symbolTable.LoadSymbolsAndNumbers();
        timer = Time.time + GameTimerDelayLength;      
        gameUi.StartGameScreen();
    }

    public void ShowResults()
    {
        GamesPlayed++;
        GamesLeftToSecret = GamesLeftToSecret - 1 >= 0 ? GamesLeftToSecret - 1 : 67;// If games amount left is below zero, start again form 67.
        gameUi.SetResultSymbol(symbolTable.GetResult());
        gameUi.ShowResultsScreen();
        gameUi.SetTexts(GamesPlayed, GamesLeftToSecret);
        SaveGameStats();
    }

    private void UpdateTimer() 
    {
        gameUi.Timer.text = string.Format("{0}", (int)(timer - Time.time));
        lerp = Mathf.Lerp(1.5f, 1.0f, (timer - Time.time) % 1.0f);//Lerp for Fade out effect
        gameUi.Timer.transform.localScale = lerp * Vector3.one;// Fade out effect
        gameUi.Timer.color = new Color(1, 1, 1, (timer - Time.time) % 1.0f);// Fade out effect
    }

    private void ResetTimer() 
    {
        timer = 0;
        gameUi.Timer.text = GameTimerDelayLength.ToString();
        gameUi.Timer.transform.localScale = Vector3.one;
        gameUi.Timer.color = new Color(1, 1, 1, 1.0f);
    }

    private void SaveGameStats() 
    {
        PlayerPrefs.SetInt("GAMES_PLAYED", GamesPlayed);
        PlayerPrefs.SetInt("GAMES_LEFT", GamesLeftToSecret);
    }

    private void LoadGameStats()
    {
        GamesPlayed = PlayerPrefs.GetInt("GAMES_PLAYED", 0);
        GamesLeftToSecret = PlayerPrefs.GetInt("GAMES_LEFT", 67);
    }
}
