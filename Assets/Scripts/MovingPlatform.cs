using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] PlatformDirection m_moving;
    PlatformDirection m_lastDirection;
    [SerializeField] Vector2 m_positionLeft;
    [SerializeField] Vector2 m_positionRight;
    [SerializeField] float m_bufer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_moving != PlatformDirection.None)
        {
            if (m_moving == PlatformDirection.Left)
            {
                transform.position = Vector2.Lerp(transform.position,(Vector2)transform.position + ( m_positionLeft / m_bufer), Time.deltaTime);

                if (transform.position == (transform.position + (Vector3)(m_positionLeft / m_bufer)))
                {
                    ChangeDirection(PlatformDirection.Right);
                }

            }
            else
            {
                transform.position = Vector2.Lerp(transform.position,transform.position * (m_positionRight / m_bufer), Time.deltaTime);
                if (transform.position == transform.position + (Vector3)(m_positionRight / m_bufer))
                {
                    ChangeDirection(PlatformDirection.Right);
                }
            }

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
            m_moving = newDrirction;
       m_lastDirection = newDrirction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 directionLeft = transform.TransformDirection(transform.position * (m_positionLeft / m_bufer));
        Vector2 directionRight = transform.TransformDirection(transform.position * (m_positionRight / m_bufer));

        Gizmos.DrawLine(directionRight,directionLeft);
    }
}

[System.Serializable]
public enum PlatformDirection
{
    Left,
    None,
    Right,
}