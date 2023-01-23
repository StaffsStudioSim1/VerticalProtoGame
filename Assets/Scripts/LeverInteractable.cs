using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverInteractable : MonoBehaviour, I_interactable
{
    public SpriteRenderer sprite;

    [SerializeField]
    private Color startColor;

    [SerializeField]
    private Color endColor;

    private bool On = false;

    public UnityEvent Activated;
    public UnityEvent Deactivated;

    public void start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = endColor;
        Deactivated.Invoke();
    }

    public void interact()
    {
        Debug.Log("interacting with lever");
        if (On)
        {
            On = false;
            sprite.color = endColor;
            Deactivated.Invoke();
        }
        else
        {
            On = true;
            sprite.color = startColor;
            Activated.Invoke();
        }

    }

}
