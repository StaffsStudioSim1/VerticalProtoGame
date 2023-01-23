using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    [SerializeField] private GameManager m_Manager;
    public bool isFlipped;

    public void Flip()
    {
        if(!isFlipped)
        {
            Physics2D.gravity = new Vector2(0, 9.81f);
        }
        else
        {
            Physics2D.gravity = new Vector2(0, -9.81f);
        }

        isFlipped = !isFlipped;

        foreach (var Player in m_Manager.ActivePlayers)
        {
            Player.GetComponent<PlayerMovement>().Flipped = isFlipped;
            Player.GetComponent<Transform>().Rotate(Vector3.forward, 180f);
        }

    }
}
