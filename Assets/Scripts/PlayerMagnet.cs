using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMagnet : MonoBehaviour
{
    GameObject m_Player;
    bool m_magnetActive;
    [SerializeField] directionOfMagnet m_directionOfMagnet;
    [FormerlySerializedAs("m_magnetPower")] public float m_magnetPowerLength;

    private void Awake()
    {
        m_magnetActive = false;
    }

    private void FixedUpdate()
    {
        if(m_magnetActive) 
        {
           
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.right,m_magnetPowerLength);
            foreach(RaycastHit2D hit in hits)
            {
                if(hit.transform.GetComponent<IsMagnetic>() != null)
                {
                    Debug.Log(hit.transform.name);
                    hit.transform.GetComponent<IsMagnetic>()?.isBeingMagnetic(transform.position,m_directionOfMagnet,
                        transform.GetComponent<PlayerMovement>());
                    hit.transform.GetComponent<IsMagnetic>()?.isBeingMagnetic(transform.position,m_directionOfMagnet,transform.GetComponent<PlayerMovement>());
                }
            }
        }
    }

    public void MagnetButton(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            m_magnetActive = true;
            Debug.Log("MAgent on");
        }
        if(context.canceled)
        {
            m_magnetActive = false;
            Debug.Log("MAgent off");

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 direction = transform.TransformDirection(Vector2.right) * m_magnetPowerLength;

        Gizmos.DrawRay(transform.position, direction);
    }

}
