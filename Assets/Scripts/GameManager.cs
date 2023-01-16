using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public List<GameObject> ActivePlayers;

    public void OnPlayerJoined(PlayerInput input)
    {
        GameObject initPlayer = input.gameObject;
        ActivePlayers.Add(initPlayer);

        //Give player 2 the correct controls and change colour (just to differentiate them)
        //TODO: magnet settings
        if (ActivePlayers.Count == 2)
        {
            input.defaultActionMap = "Player2";
            input.SwitchCurrentActionMap("Player2");
            initPlayer.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
}
