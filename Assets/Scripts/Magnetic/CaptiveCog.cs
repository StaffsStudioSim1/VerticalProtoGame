using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptiveCog : MonoBehaviour , IsMagnetic
{
    [SerializeField] Transform m_limitLeft;
    [SerializeField] Transform m_limitRight;

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
        Debug.Log("Needs to be done");
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
