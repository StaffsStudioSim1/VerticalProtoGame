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
    [SerializeField] public directionOfMagnet m_directionOfMagnet;
    [FormerlySerializedAs("m_magnetPower")] public float m_magnetPowerLength;
    [SerializeField] Vector2 m_boxSize;
    Vector2 m_facingVector = Vector2.right;

    private void Awake()
    {
        m_magnetActive = false;
        
    }

    private void FixedUpdate()
    {
        if(m_magnetActive) 
        {
            
            RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position + (Vector3)m_facingVector * m_magnetPowerLength, m_boxSize, 0f, Vector2.right,0);
           
            
            foreach (RaycastHit2D hit in hits)
            {
                hit.transform.GetComponent<IsMagnetic>()?.isBeingMagnetic(transform.position,m_directionOfMagnet,transform.GetComponent<PlayerMovement>());                                  
            }
            
        }
    }

    public void ChangeDirection(FaceingDirection direction)
    {
        switch (direction)
        {
            case FaceingDirection.LEFT:
                m_facingVector = -Vector2.right;
                break;
            case FaceingDirection.RIGHT:
                m_facingVector = Vector2.right;
                break;
            default:
                Debug.Log("ChangeDirection failed in player magnet");
                break;
        }
    }

        public void MagnetButton(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            m_magnetActive = true;
            Debug.Log("Magent on");
        }
        if(context.canceled)
        {
            m_magnetActive = false;
            Debug.Log("Magent off");

        }
    }
    private void OnDrawGizmos()
    {
        switch(m_directionOfMagnet)
        {
            case directionOfMagnet.TOWARDS:
                Gizmos.color = Color.red;
                break;
            case directionOfMagnet.AWAY:
                Gizmos.color = Color.green;
                break;
            default:
                Gizmos.color = Color.black;
                break;
        }
        Vector2 direction = transform.TransformDirection(m_facingVector) * m_magnetPowerLength;
        
        Gizmos.DrawRay(transform.position, direction);
        Gizmos.DrawWireCube(transform.position + (Vector3)m_facingVector * m_magnetPowerLength, m_boxSize);
    }

    
}