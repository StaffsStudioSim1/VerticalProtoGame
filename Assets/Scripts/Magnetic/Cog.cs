using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cog : MonoBehaviour
{
    [SerializeField] protected bool m_firstCog;
    [SerializeField] protected Cog m_LastCog;
    [SerializeField] protected Cog m_NextCog;
    public bool m_rotating;
    [SerializeField] protected float m_rotateSpeed;

    public UnityEvent m_active;
    public UnityEvent m_deactive;
   

    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_firstCog ||(bool) m_LastCog?.m_rotating)
        {
            Rotating();
        }
        else if(!m_LastCog.m_rotating)
        {
           NotRotating();
           
        }       
         
    }

    protected void Rotating()
    {
        if (!m_rotating)
        {
            m_rotating = true;
            m_active?.Invoke();
        }
        //transform.rotation.Set(transform.rotation.x, transform.rotation.y, transform.rotation.z + m_rotateSpeed, transform.rotation.w);
        transform.Rotate(Vector3.forward, m_rotateSpeed);
    }

    protected void NotRotating()
    {
        if (m_rotating)
        {
            m_rotating = false;
            m_deactive?.Invoke();
        }
    }
}
