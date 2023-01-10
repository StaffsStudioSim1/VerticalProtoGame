using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MagneticBox : MonoBehaviour , IsMagnetic
{
    Rigidbody2D m_rigidbody;

    public void isBeingMagnetic(Vector2 pushingPlayerPos, Vector2 forceApplyed, PlayerMovment player)
    {
        m_rigidbody.AddForce(forceApplyed,ForceMode2D.Impulse);
    }

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
