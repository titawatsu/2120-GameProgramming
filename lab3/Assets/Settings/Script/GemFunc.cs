using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemFunc : MonoBehaviour
{
    public GemColor color;
    
    void Start()
    {
        if (TryGetComponent(out GemRandomize gemRandomize))
        {
            color = gemRandomize.color;
        }
    }

    GemColor getColor()
    {
        return this.color;
    }

    void setColor(GemColor color)
    {
        this.color = color;
    }
}
