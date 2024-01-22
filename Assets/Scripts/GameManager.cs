using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;

    private const string PLAYER_POS_X = "PlayerPositionX";
    private const string PLAYER_POS_Y = "PlayerPositionY";
    private const string TOTAL_COINS = "TotalCoins";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Borrar los datos de PlayerPrefs
        }
    }

    private void Save()
    {
        Debug.Log("Save!");
        
        // POSITION
        Vector2 pos = playerController.GetPosition();
        PlayerPrefs.SetFloat(PLAYER_POS_X, pos.x);
        PlayerPrefs.SetFloat(PLAYER_POS_Y, pos.y);
        Debug.Log($"Position: {pos}");

        // TOTAL COINS
        int totalCoins = playerController.GetTotalCoins();
        PlayerPrefs.SetInt(TOTAL_COINS, totalCoins);
        Debug.Log($"Total Coins: {totalCoins}");
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey(PLAYER_POS_X))
        {
            Debug.Log("Load!");
            // POSITION
            float x = PlayerPrefs.GetFloat(PLAYER_POS_X);
            float y = PlayerPrefs.GetFloat(PLAYER_POS_Y);
            playerController.SetPosition(new Vector2(x, y));
            Debug.Log($"Position: ({x}, {y})");

            // TOTAL COINS
            int totalCoins = PlayerPrefs.GetInt(TOTAL_COINS, 0);
            playerController.SetTotalCoins(totalCoins);
            Debug.Log($"Total Coins: {totalCoins}");
        }
        else
        {
            Debug.LogError("No Data");
        }
        
    }
}
