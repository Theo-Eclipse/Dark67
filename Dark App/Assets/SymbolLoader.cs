using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SymbolLoader : MonoBehaviour
{
    [SerializeField] private Sprite DefaultIcon;
    [SerializeField]private List<Sprite> UsedIcons = new List<Sprite>();
    private int r, index;
    private List<int> SpriteIndexesBuffer = new List<int>();
    private List<int> SpriteRandomizedIndexes = new List<int>();
    private List<Symbol> SymbolElements = new List<Symbol>(90);
    // Start is called before the first frame update
    void Start()
    {
        LoadSymbolsAndNumbers();
    }

    public void SetDefaultView() 
    {
        GetComponentsInChildren(false, SymbolElements);
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

        GetComponentsInChildren(false, SymbolElements);
        foreach (var sym in SymbolElements)
        {
            r = (10+SymbolElements.IndexOf(sym)) % 9 == 0 ? 0 : 1 + SymbolElements.IndexOf(sym) % (SpriteRandomizedIndexes.Count-1);
            sym.SetNumberSymbol(UsedIcons[SpriteRandomizedIndexes[r]], 10 + SymbolElements.IndexOf(sym));
        }
        for (r = 0; r < transform.childCount; r++)
            transform.GetChild(Random.Range(0, transform.childCount)).SetAsFirstSibling();
    }

    public Sprite GetResult() 
    {
        if (SpriteRandomizedIndexes.Count > 0)
            return UsedIcons[SpriteRandomizedIndexes[0]];
        else 
            return null;
    }
}
