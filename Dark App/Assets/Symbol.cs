using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Symbol : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI number;
    [SerializeField] private Image image;
    // Start is called before the first frame update
    public void SetNumberSymbol(Sprite symbol, int number) 
    {
        this.number.text = number.ToString();
        image.sprite = symbol;
    }
}
