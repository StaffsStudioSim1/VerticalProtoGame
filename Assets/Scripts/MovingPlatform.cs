using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Platform Control")]
    [SerializeField] PlatformDirection m_moving;
    PlatformDirection m_lastDirection;
    [SerializeField] Vector2 m_positionLeft;
    [SerializeField] Vector2 m_positionRight;
    [SerializeField] float m_speed;
    Vector3 m_origin;
    [Tooltip("1 if the positons are in the middle of the tile, 1.5 if bounce at definitve end for a 3 tile width")]
    [SerializeField] Vector2 m_boundrys;

    [Header("PlayerEntrapment")]
    [SerializeField] Vector2 m_boxSize;
    [SerializeField] Vector2 m_boxCenter;
    [SerializeField] List<GameObject> m_PlayersTrapped;

    // Start is called before the first frame update
    void Start()
    {
        m_origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_moving != PlatformDirection.None)
        {
            Vector3 startPos = transform.position; 
            if (m_moving == PlatformDirection.Left)
            {
                transform.position = Vector2.MoveTowards(transform.position,((Vector2)m_origin + m_positionLeft) + m_boundrys, Time.deltaTime * m_speed);
                
                if (transform.position == (m_origin + (Vector3)m_positionLeft) + (Vector3)m_boundrys)
                {
                    ChangeDirection(PlatformDirection.Right);
                }

            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position,((Vector2)m_origin + m_positionRight) + -m_boundrys, Time.deltaTime * m_speed);
                
                if (transform.position == (m_origin + (Vector3)m_positionRight) + -(Vector3)m_boundrys)
                {
                    ChangeDirection(PlatformDirection.Left);
                }
            }
            Vector3 endPos = transform.position;
            
        }
    }

   
    public void Activate()
    {
        m_moving = m_lastDirection;
    }

    public void Deactivate()
    {
        m_moving = PlatformDirection.None;
    }

    public void ChangeDirection(PlatformDirection newDrirction)
    {
        
       if(m_moving != PlatformDirection.None)
            m_lastDirection = newDrirction;
        m_moving = newDrirction;
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>() != null)
        {
            GameObject player = collision.gameObject;
            m_PlayersTrapped.Add(player);
            player.transform.parent = transform;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(m_PlayersTrapped.Contains(collision.gameObject))
        {
            GameObject player = collision.gameObject;
            m_PlayersTrapped.Remove(player);
            player.transform.parent = transform.parent;
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 directionLeft = new Vector2();
        Vector2 directionRight = new Vector2();

        
        if(!Application.isPlaying)
        {
            directionLeft = transform.TransformDirection(transform.position + (Vector3)m_positionLeft);
            directionRight = transform.TransformDirection(transform.position + (Vector3)m_positionRight);
            Gizmos.color = Color.red;
        }
        else
        {
            directionLeft = transform.TransformDirection(m_origin + (Vector3)m_positionLeft);
            directionRight = transform.TransformDirection(m_origin + (Vector3)m_positionRight);
            Gizmos.color = Color.yellow;

        }


        Gizmos.DrawLine(directionRight, directionLeft);

        

        //Gizmos.DrawRay(transform.position, m_boxCenter);
        //Gizmos.DrawWireCube(transform.position + (Vector3)(m_boxCenter), m_boxSize);
    }
}

[System.Serializable]
public enum PlatformDirection
{
    Left,
    None,
    Right,
}