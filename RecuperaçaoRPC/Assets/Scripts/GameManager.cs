using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPun
{
    Vector2 screenBounds;
    float score;
    int playersInGame;
    // text

    #region Singleton
    public static GameManager instance;
    const string playerPrefab = "Prefabs/Player";
    public Vector2 ScreenBounds { get => screenBounds;}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

       // screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    [PunRPC]
    private void AddPlayer()
    {
        playersInGame++;
        if (playersInGame == PhotonNetwork.PlayerList.Length)
        {
            CreatePlayer();
        }
    }

    private void CreatePlayer()
    {
        //PlayerController player = NetworkManager.instance.Instantiate(playerPrefab, new Vector3(0, -4), Quaternion.identity).GetComponent<Player>();
        //player.photonView.RPC("Initialize", RpcTarget.All);
    }
    #endregion
    void Start()
    {
        photonView.RPC("AddPlayer", RpcTarget.AllBuffered);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
