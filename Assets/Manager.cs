using UnityEngine;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class PlayerData{
    public int hp;

    public string Name;
    public float Stamina;
    public List<string> Items = new List<string>();
    public Sprite image;

}





public class Manager : MonoBehaviour
{
    [SerializeField]
    public int hp;

    public string Name;
    public float Stamina;



    PlayerData playerdata = new PlayerData();
    string savepath;
    void Start()
    {
        savepath = Application.persistentDataPath + "/player1data.json";

        playerdata.Name = "Pepe";
        playerdata.Stamina = 100f;
        playerdata.hp = 10;
        playerdata.Items.Add("Escudo");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SaveGaneData()
    {
        PlayerPrefs.SetString("NameKey", Name);
        PlayerPrefs.SetInt("HPKey", hp);
        PlayerPrefs.SetFloat("StaminaKey", Stamina);
        string json = JsonUtility.ToJson(playerdata);
        File.WriteAllText(savepath, json);
    }

    public void LoadGameData() {

       Name= PlayerPrefs.GetString("NameKey");
        hp=PlayerPrefs.GetInt("HPKey");
        Stamina=PlayerPrefs.GetFloat("StaminaKey");

        string loadjson= File.ReadAllText(savepath);
        playerdata = JsonUtility.FromJson<PlayerData>(loadjson);

        Debug.Log("Name" + playerdata.Name);
    }
}
