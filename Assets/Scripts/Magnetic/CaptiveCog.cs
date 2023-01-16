using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptiveCog : MonoBehaviour , IsMagnetic
{
    [SerializeField] Transform m_limitLeft;
    [SerializeField] Transform m_limitRight;
    [SerializeField] [Range(0,1)] float m_moveSpeed;

    /*public void isBeingMagnetic(Vector2 pushingPlayerPos, Vector2 forceApplied,
        PlayerMovement player)
    {
        if (forceApplied.y < 0)
        {
            //move left untill stop point
            gameObject.transform.position = Vector3.Lerp(transform.position, m_limitLeft.position, 2);
        }
        else if(forceApplied.y > 0)
        {
            //move right untill stoped
            gameObject.transform.position = Vector3.Lerp(transform.position, m_limitRight.position, 2);

        }
        else
        {
            //no movemnt
        }
    }
    */
    public void isBeingMagnetic(Vector2 pushingPlayerPos, directionOfMagnet forceDirection, PlayerMovement player)
    {
        Vector2 forceApplied = (pushingPlayerPos - (Vector2)transform.position);
        forceApplied.Normalize();
        Debug.Log("Needs to be done");
        if (forceApplied.x < 0)
        {
            //move left untill stop point
            if(forceDirection == directionOfMagnet.TOWARDS)
                gameObject.transform.position = Vector3.Lerp(transform.position, m_limitLeft.position, m_moveSpeed);
            else
                gameObject.transform.position = Vector3.Lerp(transform.position, m_limitRight.position, m_moveSpeed);
        }
        else if (forceApplied.x > 0)
        {
            //move right untill stoped
            if (forceDirection == directionOfMagnet.TOWARDS)
            gameObject.transform.position = Vector3.Lerp(transform.position, m_limitRight.position, m_moveSpeed);
            else
                gameObject.transform.position = Vector3.Lerp(transform.position, m_limitLeft.position, m_moveSpeed);

        }
        else
        {
            //no movemnt
        }
    }
    
}

