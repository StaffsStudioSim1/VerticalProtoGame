using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : MonoBehaviour
{
    [SerializeField] bool m_firstCog;
    [SerializeField] bool m_lastCog;
    [SerializeField] Cog m_LastCog;
    [SerializeField] Cog m_NextCog;
    bool m_rotating;
    [SerializeField] float m_rotateSpeed;

   

    // Update is called once per frame
    void Update()
    {
        if(m_firstCog || m_LastCog.m_rotating)
        {
            if(!m_rotating)
            {
                m_rotating = true;
            }
            transform.rotation.Set(transform.rotation.x, transform.rotation.y, transform.rotation.z + m_rotateSpeed,transform.rotation.w);
        }
        else if(!m_LastCog.m_rotating)
        {
            if (m_rotating)
            {
                m_rotating = false;
            }
           
        }
        
        if(m_lastCog && m_rotating)
        {
              
        }
    }
}
