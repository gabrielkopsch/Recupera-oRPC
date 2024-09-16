using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor.Experimental.GraphView;

public class Apple : MonoBehaviourPun
{
    const int speed = 5;
    [SerializeField] int score;
    Rigidbody2D rigidbody2D;

    public int Score { get => score; }

   
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
   
    void Update()
    {
        rigidbody2D.velocity = Vector2.down * speed;

         if (transform.position.y < -GameManager.instance.ScreenBounds.y )
        {
            photonView.RPC("DestroyRPC",RpcTarget.All);
        }
    }
    [PunRPC]
    void DestroyRPC()
    {
        Destroy(gameObject);
    }

  

    

}
