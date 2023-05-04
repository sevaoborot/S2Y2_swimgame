using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InisializeLevel : MonoBehaviour
{
    [SerializeField] Transform[] playerSpawn;
    [SerializeField] string[] playerTypeOfMovement;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] bool isTeamBattle;

    // Start is called before the first frame update
    void Start()
    {
        var PlayerConfigs = PlayerConfigManager.Instance.GetPlayerConfigurations().ToArray();
        Debug.Log("Regular mode enabled");
        for (int i = 0; i < PlayerConfigs.Length; i++)
        {
            var player = Instantiate(playerPrefab, playerSpawn[i].position, playerSpawn[i].rotation, gameObject.transform);
            player.GetComponent<MovementInput>().InitializePlayer(PlayerConfigs[i]);
            player.GetComponent<MovementSystem>().SetMovementType(playerTypeOfMovement[i]); //there is a mistake of out of range, but it works, so i dont care rn, maybe fix it later
        }
    }
}
