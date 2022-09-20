using UnityEngine;

public class GamePersistence : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    void Start()
    {
        GameUI.SaveGame += SaveGameData;
        GameUI.LoadGame += LoadGameData;
    }

    public void SaveGameData()
    {
        PlayerPrefs.SetFloat("player1X", player1.transform.position.x);    
        PlayerPrefs.SetFloat("player1Z", player1.transform.position.z);
        
        PlayerPrefs.SetFloat("player2X", player2.transform.position.x);    
        PlayerPrefs.SetFloat("player2Z", player2.transform.position.z);

        PlayerPrefs.Save();
    }

    public void LoadGameData()
    {
        float player1x = PlayerPrefs.GetFloat("player1X", 0);
        float player1z = PlayerPrefs.GetFloat("player1Z", 0);

        float player2x = PlayerPrefs.GetFloat("player2X", 0);
        float player2z = PlayerPrefs.GetFloat("player2Z", 0);

        player1.transform.position = new Vector3(player1x, 0, player1z);
        player2.transform.position = new Vector3(player2x, 0, player2z);
    }

    private void OnDestroy()
    {
        GameUI.SaveGame -= SaveGameData;
        GameUI.LoadGame -= LoadGameData;
    }
}