using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteractable : MonoBehaviour, I_interactable
{
    public SpriteRenderer sprite;

    [SerializeField]
    private Color startColor;

    [SerializeField]
    private Color endColor;

    private bool On = false;


    public void start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void interact()
    {
        Debug.Log("interacting with lever");
        if (On)
        {
            On = false;
            sprite.color = endColor;
        }
        else
        {
            On = true;
            sprite.color = startColor;
        }

    }

}
