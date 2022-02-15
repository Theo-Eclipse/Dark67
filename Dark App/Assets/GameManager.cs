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
    [SerializeField] private SymbolLoader SymbolsLoader;
    [SerializeField] private TextMeshProUGUI GameTimer;

    private float timer = 0;
    private float lerp = 0;

    private void Start()
    {
        ShowStart();
    }
    private void Update()
    {
        if (timer > 0) 
        {
            GameTimer.text = string.Format("{0}",(int)(timer - Time.time));
            lerp = Mathf.Lerp(1.5f, 1.0f, (timer - Time.time) % 1.0f);
            GameTimer.transform.localScale = lerp * Vector3.one;
            GameTimer.color = new Color(1, 1, 1, (timer - Time.time) % 1.0f);

            if (timer <= Time.time) 
            {
                timer = 0;
                GameTimer.text = GameTimerDelayLength.ToString();
                GameTimer.transform.localScale = Vector3.one;
                GameTimer.color = new Color(1, 1, 1, 1.0f);
                ShowResults();
            }
        }
    }
    //How to + Start => Ready. => Wait 5 Seconds. => Show + Retry

    public void ShowStart() 
    {
        gameUi.ShowStart();
        SymbolsLoader.SetDefaultView();
        gameUi.SetTexts(0, 67);
    }

    public void ShowReady() 
    {
        gameUi.ShowReady();
    }

    public void StartGame()
    {
        SymbolsLoader.LoadSymbolsAndNumbers();
        timer = Time.time + GameTimerDelayLength;      
        gameUi.StartGame();
    }

    public void ShowResults()
    {
        gameUi.SetResultSymbol(SymbolsLoader.GetResult());
        gameUi.ShowResults();
        gameUi.SetTexts(0, 67);
    }


}
