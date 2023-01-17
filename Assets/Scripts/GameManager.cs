using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public List<GameObject> ActivePlayers;
    public List<PlayerInfo> m_playerInfos;    

    public void OnPlayerJoined(PlayerInput input)
    {
        GameObject initPlayer = input.gameObject;
        ActivePlayers.Add(initPlayer);
        
        int currentPlayerID = ActivePlayers.Count - 1;

        if(m_playerInfos.Count > currentPlayerID)
        {
            input.defaultActionMap = m_playerInfos[currentPlayerID].actionMap;
            input.SwitchCurrentActionMap(m_playerInfos[currentPlayerID].actionMap);
            initPlayer.GetComponent<SpriteRenderer>().color = m_playerInfos[currentPlayerID].PlayerColour;
            initPlayer.GetComponent<PlayerMagnet>().m_directionOfMagnet = m_playerInfos[currentPlayerID].DirectionOfMagnet;
            initPlayer.transform.position = m_playerInfos[currentPlayerID].StartFlag.position;
        }

        //Give player 2 the correct controls and change colour (just to differentiate them)
        //TODO: magnet settings
        else
        {
            input.defaultActionMap = "Player2";
            input.SwitchCurrentActionMap("Player2");
            initPlayer.GetComponent<SpriteRenderer>().color = Color.cyan;
            initPlayer.GetComponent<PlayerMagnet>().m_directionOfMagnet = directionOfMagnet.AWAY;
        }
    }
}


[System.Serializable]
public struct PlayerInfo
{
   public Transform StartFlag;
   public Color PlayerColour;
   public directionOfMagnet DirectionOfMagnet;
   public string actionMap;
}