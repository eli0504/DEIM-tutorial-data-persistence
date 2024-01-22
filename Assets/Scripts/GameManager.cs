using System.Collections;
using System.Collections.Generic;
using System.IO;
<<<<<<< HEAD
using Unity.VisualScripting;
=======
>>>>>>> 9b4c69be9ce5156b9735aa34de58fde452fe9149
using UnityEngine;

public class GameManager : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private PlayerController playerController; //conectar scripts

    //variables que no van a cambiar nunca -> coordenadas x, y
=======

    [SerializeField] private PlayerController playerController;

>>>>>>> 9b4c69be9ce5156b9735aa34de58fde452fe9149
    private const string PLAYER_POS_X = "PlayerPositionX";
    private const string PLAYER_POS_Y = "PlayerPositionY";
    private const string TOTAL_COINS = "TotalCoins";

<<<<<<< HEAD
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
=======
    private const string SAVE_FILE_PATH = "/save.json";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SaveJson();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadJson();
        }

        // Solo tiene que ver con PlayerPrefs
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Deleted");
            PlayerPrefs.DeleteAll();
        }
    }

    private void Save()
    {
        Debug.Log("Save!");
        
        // POSITION
        Vector3 pos = playerController.GetPosition();
        PlayerPrefs.SetFloat(PLAYER_POS_X, pos.x);
        PlayerPrefs.SetFloat(PLAYER_POS_Y, pos.y);
        Debug.Log($"Position: {pos}");

        // TOTAL COINS
        int totalCoins = playerController.GetTotalCoins();
        PlayerPrefs.SetInt(TOTAL_COINS, totalCoins);
        Debug.Log($"Total Coins: {totalCoins}");
>>>>>>> 9b4c69be9ce5156b9735aa34de58fde452fe9149
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey(PLAYER_POS_X))
        {
<<<<<<< HEAD
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
=======
            Debug.Log("Load!");
            // POSITION
            float x = PlayerPrefs.GetFloat(PLAYER_POS_X);
            float y = PlayerPrefs.GetFloat(PLAYER_POS_Y);
            playerController.SetPosition(new Vector3(x, y, 0));
            Debug.Log($"Position: ({x}, {y})");

            // TOTAL COINS
            int totalCoins = PlayerPrefs.GetInt(TOTAL_COINS, 0);
            playerController.SetTotalCoins(totalCoins);
            Debug.Log($"Total Coins: {totalCoins}");
        }
        else
        {
            // No deberÃ­a de ocurrir NUNCA
            Debug.LogError("No Data");
        }
        
    }


    private void SaveJson()
    {
        Debug.Log("Saved with JSON");
>>>>>>> 9b4c69be9ce5156b9735aa34de58fde452fe9149
        Vector3 pos = playerController.GetPosition();
        int totalCoins = playerController.GetTotalCoins();

        SaveObject saveObject = new SaveObject
        {
            playerPosition = pos,
            coins = totalCoins
        };

<<<<<<< HEAD
        string saveObjectJson = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.dataPath + SAVE_FILE_PATH, saveObjectJson);
=======
        string savedObjectJson = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.dataPath + SAVE_FILE_PATH, savedObjectJson);
>>>>>>> 9b4c69be9ce5156b9735aa34de58fde452fe9149
    }

    private void LoadJson()
    {
<<<<<<< HEAD
        Debug.Log("Loaded with Json");
        if(File.Exists(Application.dataPath + SAVE_FILE_PATH))
        {
            string savedObjectstring = File.ReadAllText(Application.dataPath + SAVE_FILE_PATH);
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(savedObjectstring);
=======
        Debug.Log("Loaded with JSON");
        if (File.Exists(Application.dataPath + SAVE_FILE_PATH))
        {
            string savedObjectString = File.ReadAllText(Application.dataPath + SAVE_FILE_PATH);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(savedObjectString);

>>>>>>> 9b4c69be9ce5156b9735aa34de58fde452fe9149
            playerController.SetPosition(saveObject.playerPosition);
            playerController.SetTotalCoins(saveObject.coins);
        }
        else
<<<<<<< HEAD
        { //aquí no tendríamos que caer nunca
=======
        {
            // AquÃ­ no tendrÃ­amos que caer nunca
>>>>>>> 9b4c69be9ce5156b9735aa34de58fde452fe9149
            Debug.LogError("No save file");
        }
    }
}
