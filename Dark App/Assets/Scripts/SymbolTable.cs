using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SymbolTable : MonoBehaviour
{
    [SerializeField] private Sprite DefaultIcon;
    [SerializeField]private List<Sprite> UsedIcons = new List<Sprite>();
    [SerializeField] private Transform[] SymbolRows;
    private int r, index;
    private List<int> SpriteIndexesBuffer = new List<int>();
    private List<int> SpriteRandomizedIndexes = new List<int>();

    private List<Symbol> SymbolElements = new List<Symbol>(90);
    // Start is called before the first frame update
    void Start()
    {
        GetSymbolsInstances();
        LoadSymbolsAndNumbers();
    }

    public void SetDefaultView() 
    {
        foreach (var sym in SymbolElements)
            sym.SetNumberSymbol(DefaultIcon, 67);
    }

    public void LoadSymbolsAndNumbers() 
    {
        SpriteIndexesBuffer.Clear();
        foreach (var sprite in UsedIcons)
            SpriteIndexesBuffer.Add(UsedIcons.IndexOf(sprite));

        SpriteRandomizedIndexes.Clear();
        for (r = 0; r < UsedIcons.Count; r++) 
        {
            index = SpriteIndexesBuffer[Random.Range(0, SpriteIndexesBuffer.Count)];
            SpriteIndexesBuffer.Remove(index);
            SpriteRandomizedIndexes.Add(index);
        }

        foreach (var sym in SymbolElements)
        {
            r = (SymbolElements.IndexOf(sym)) % 9 == 0 ? 0 : 1 + SymbolElements.IndexOf(sym) % (SpriteRandomizedIndexes.Count-1);
            sym.SetNumberSymbol(UsedIcons[SpriteRandomizedIndexes[r]], SymbolElements.IndexOf(sym));
        }
        for (r = 0; r < SymbolRows.Length; r++)
            SymbolRows[Random.Range(0, SymbolRows.Length)].SetAsFirstSibling();
    }

    public Sprite GetResult() 
    {
        if (SpriteRandomizedIndexes.Count > 0)
            return UsedIcons[SpriteRandomizedIndexes[0]];
        else 
            return null;
    }

    private void GetSymbolsInstances() 
    {
        SymbolElements.Clear();
        foreach (var row in SymbolRows)
            SymbolElements.AddRange(row.GetComponentsInChildren<Symbol>(false));
    }
}
