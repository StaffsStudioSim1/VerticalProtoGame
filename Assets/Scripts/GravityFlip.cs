using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    [SerializeField] private GameManager m_Manager;
    public bool isFlipped;


    public void EnableGravityFlip()
    {
        isFlipped = true;
        Physics2D.gravity = new Vector2(0, 9.81f);

        foreach (var Player in m_Manager.ActivePlayers)
        {
            Player.GetComponent<PlayerMovement>().Flipped = isFlipped;
            Player.GetComponent<Transform>().Rotate(Vector3.forward, 180f);
        }
    }

    public void DisableGravityFlip()
    {
        isFlipped = false;
        Physics2D.gravity = new Vector2(0, -9.81f);

        foreach (var Player in m_Manager.ActivePlayers)
        {
            Player.GetComponent<PlayerMovement>().Flipped = isFlipped;
            Player.GetComponent<Transform>().Rotate(Vector3.forward, 180f);
        }
    }
}
