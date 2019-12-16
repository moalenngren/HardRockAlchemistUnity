using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    private string _text;
    private Sprite _sprite;
    private string _flavorText;
   // private string info;
   // private Vector2 location;


    void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>(true).text;
        _sprite = GetComponent<SpriteRenderer>().sprite;
        _flavorText = GetFlavorText();
    } 

    public Element(string itemName, Sprite image, string flavor)
    {
        _text = itemName;
        _sprite = image;
        _flavorText = flavor;
    }

    public void SetSprite(Sprite image)
    {
        GetComponent<SpriteRenderer>().sprite = image;
        _sprite = image;
    }

    public void SetText(string name)
    {
        GetComponentInChildren<TextMeshProUGUI>(true).text = name;
        _text = name;
    }

    public string GetText()
    {
        return _text;
    }

    public Sprite GetSprite()
    {
        return _sprite;
    }

    public string GetFlavorText()
    {
        for (int i = 0; i < AllItems.allItems.Count; i++)
        { 
            if (AllItems.allItems[i][0] == _text)
            {
                return AllItems.allItems[i][3];
            }
        }
        return "";
    }
}
