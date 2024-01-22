using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController; //conectar scripts

    //variables que no van a cambiar nunca -> coordenadas x, y
    private const string PLAYER_POS_X = "PlayerPositionX";
    private const string PLAYER_POS_Y = "PlayerPositionY";
    private const string TOTAL_COINS = "TotalCoins";

    private const string SAVE_FILE_PATH = "/save.txt";

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SaveJson();
        }
        
        {
            if(Input.GetKeyUp(KeyCode.L))
            LoadJson();
        }
        
        { //solo PlayerPref
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                PlayerPrefs.DeleteAll(); //borra todos los datos
            }
        }
    }

    //GUARDAR Y CARGAR DATOS
    private void Save()
    {
        Debug.Log("save"); //comprobar que funciona

        //guardar pos de player
        Vector3 pos = playerController.GetPosition();
        PlayerPrefs.SetFloat(PLAYER_POS_X, pos.x);
        PlayerPrefs.SetFloat(PLAYER_POS_Y, pos.y);

        //total coins
        int totalCoins = playerController.GetTotalCoins();
        PlayerPrefs.SetInt(TOTAL_COINS, totalCoins);
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey(PLAYER_POS_X))
        {
            Debug.Log("load");
            //POSITION
            float x = PlayerPrefs.GetFloat(PLAYER_POS_X);
            float y = PlayerPrefs.GetFloat(PLAYER_POS_Y);
            playerController.SetPosition(new Vector3(x, y));

            //TOTAL COINS
            int totalCoins = PlayerPrefs.GetInt(TOTAL_COINS, 0);
            playerController.SetTotalCoins(totalCoins);
        }
        else
        {
            Debug.Log("NO DATA");
        }
    }

    private void SaveJson()
    {
        Debug.Log("Saved with Json");
        Vector3 pos = playerController.GetPosition();
        int totalCoins = playerController.GetTotalCoins();

        SaveObject saveObject = new SaveObject
        {
            playerPosition = pos,
            coins = totalCoins
        };

        string saveObjectJson = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.dataPath + SAVE_FILE_PATH, saveObjectJson);
    }

    private void LoadJson()
    {
        Debug.Log("Loaded with Json");
        if(File.Exists(Application.dataPath + SAVE_FILE_PATH))
        {
            string savedObjectstring = File.ReadAllText(Application.dataPath + SAVE_FILE_PATH);
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(savedObjectstring);
            playerController.SetPosition(saveObject.playerPosition);
            playerController.SetTotalCoins(saveObject.coins);
        }
        else
        { //aquí no tendríamos que caer nunca
            Debug.LogError("No save file");
        }
    }
}
