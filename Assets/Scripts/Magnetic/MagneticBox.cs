using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MagneticBox : MonoBehaviour , IsMagnetic
{
    Rigidbody2D m_rigidbody;
    [SerializeField] float m_pushForce = 10;

    public void isBeingMagnetic(Vector2 pushingPlayerPos, directionOfMagnet forceDirection, PlayerMovement player)
    {
       switch (forceDirection) {
            case directionOfMagnet.TOWARDS:

                m_rigidbody.AddForce((pushingPlayerPos - (Vector2)transform.position)*m_pushForce,ForceMode2D.Force);

                break;
            case directionOfMagnet.AWAY: 
                
                m_rigidbody.AddForce(-(pushingPlayerPos - (Vector2)transform.position)*m_pushForce,ForceMode2D.Force);

                break;
                default:
                Debug.Log("Box: No Valid Push direction");
                break;
                   
        }  
    }

    //m_rigidbody.AddForce(forceApplyed,ForceMode2D.Impulse);



    // Start is called before the first frame update
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
