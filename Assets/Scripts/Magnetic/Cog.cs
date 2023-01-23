using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cog : MonoBehaviour
{
    [SerializeField] protected bool m_isFirstCog;
    [SerializeField] protected Cog m_LastCog;
    public bool m_rotating;
    [SerializeField] protected float m_rotateSpeed;
    [HideInInspector] public int m_cogIndex;

    public UnityEvent m_active;
    public UnityEvent m_deactive;

    private void Awake()
    {
        if(m_isFirstCog)
        {
            m_cogIndex = 0;
        }
    }

    private void Start()
    {
        if(m_LastCog != null)
        {
            m_cogIndex = m_LastCog.m_cogIndex + 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_isFirstCog ||(bool) m_LastCog?.m_rotating)
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
        
        if(m_cogIndex % 2 == 0)
        {
            transform.Rotate(Vector3.forward, m_rotateSpeed);
        }
        else
            transform.Rotate(Vector3.forward, -m_rotateSpeed);
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
