using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    [SerializeField] private GameManager m_Manager;
    private bool m_Flipped;

    public void OnGravityButtonPressed()
    {
        if (!m_Flipped)
        {
            Physics2D.gravity = new Vector2(0f, 9.81f);
            m_Flipped = true;
        }
        else
        {
            Physics2D.gravity = new Vector2(0f, -9.81f);
            m_Flipped = false;
        }

        foreach (var Player in m_Manager.ActivePlayers)
        {
            Player.GetComponent<PlayerMovement>().Flipped = m_Flipped;
            Player.GetComponent<Transform>().Rotate(Vector3.forward, 180f);
        }
        
    }
}
