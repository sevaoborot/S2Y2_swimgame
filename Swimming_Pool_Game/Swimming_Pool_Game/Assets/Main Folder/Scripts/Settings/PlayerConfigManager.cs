using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

/* Class that detects what character/imput player is choosing
 * Using pattern SINGLETONE
 */

public class PlayerConfigManager : MonoBehaviour
{
    List<PlayerConfiguration> PlayerConfigList; //list of players' configurations
    [SerializeField] int maxPlayers;
    public static PlayerConfigManager Instance { get; private set; }
    
    //Creating ONE unique character with uniwue settings
    private void Awake()
    {
        if (Instance != null) Debug.Log("SINGLETONE - Trying to create a new Instance, but it already exists!");
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            PlayerConfigList = new List<PlayerConfiguration>(); 
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigurations()
    {
        return PlayerConfigList;
    }

    public void SetPlayerColour(int index, Material color)
    {
        PlayerConfigList[index].playerMaterial = color;
    }

    public void isReadyToPlay(int index)
    {
        PlayerConfigList[index].isReadyToPlay = true;
        if (PlayerConfigList.Count == maxPlayers && PlayerConfigList.All(p => p.isReadyToPlay == true)) SceneManager.LoadScene("TestSceneLoad"); //load game if all the players are ready
    }

    public void HandlePlayerJoin(PlayerInput _pi)
    {
        Debug.Log("Player joined: " + _pi.playerIndex);
        if (!PlayerConfigList.Any(p => p.playerIndex == _pi.playerIndex))
        {
            PlayerConfigList.Add(new PlayerConfiguration(_pi));
            _pi.transform.SetParent(transform); //new character will be the child of this config game object
        }
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration (PlayerInput _pi)
    {
        playerIndex = _pi.playerIndex;
        playerInput = _pi;

    }
    public PlayerInput playerInput;
    public int playerIndex;
    public bool isReadyToPlay;
    public Material playerMaterial; //TODO: change it to different mesh
}
