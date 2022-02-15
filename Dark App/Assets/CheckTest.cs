using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTest : MonoBehaviour
{
    private List<int> FoundNumbers = new List<int>();
    private int ex = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 10; i < 100; i++) 
        {
           ex = Extract(i);
            if (!FoundNumbers.Contains(ex)) 
            {
                FoundNumbers.Add(ex);
                Debug.Log($"Extract: {i} - ({i / 10} + {i % 10}) = {ex}");
            }
        }
    }
    private int Extract(int value) 
    {
        if (value >= 10)
            return value - (value / 10 + value % 10);
        else return value;
    }
}
