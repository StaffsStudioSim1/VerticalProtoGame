using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject obJectToInteractWith;
    private bool on;
    private int collisionCount;
    public UnityEvent m_Activated;
    public UnityEvent m_Deactivated;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionCount++;
        if(collisionCount == 1)
        {
            on = true;
            m_Activated.Invoke();
        }
        Debug.Log("Collision entered - turned on");
        Debug.Log(collisionCount);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        collisionCount--;
        if(collisionCount == 0)
        {
            on = false;
            m_Deactivated.Invoke();
        }
        Debug.Log("Collision exit - turned off");
        Debug.Log(collisionCount);
    }

}
