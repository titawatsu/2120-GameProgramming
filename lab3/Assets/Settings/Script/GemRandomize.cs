using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRandomize : MonoBehaviour
{
    public GemColor color;

    [SerializeField] private Sprite[] spritesArray;

    [SerializeField] private int randInterger;

    [SerializeField] private SpriteRenderer sRenderer;

    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();

        randInterger = Random.Range(0, spritesArray.Length);

        switch (randInterger)
        {
            case 0: 
                color = GemColor.Red; 
                break;
            case 1: 
                color = GemColor.Green; 
                break;
            case 2:
                color = GemColor.Blue;
                break;
        }
        sRenderer.sprite = spritesArray[randInterger];
    }
}
