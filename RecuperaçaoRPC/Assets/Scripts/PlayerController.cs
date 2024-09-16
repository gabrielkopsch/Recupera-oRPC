using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviourPun
{
    const float velocity = 10;
    float direction;
    Rigidbody2D rigidbody2D;
    bool playerLocal =true ;
    


    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        photonView.RPC("Intializate", RpcTarget.All);
    }

    [PunRPC]
    private void Intializate()
    {
        if (!photonView.IsMine)
        {
            Color color = Color.white;
            color.a = 0.2f;
            GetComponent<SpriteRenderer>().color = color;
            playerLocal = false;
            
        }
       
    }
  // Update is called once per frame
    void Update()
    {
        if (playerLocal) 
        {
            Input.GetKeyDown(KeyCode.LeftArrow);
            Input.GetKeyDown(KeyCode.RightArrow);
            Move();
        } 
    }

    void Move()
    {
       rigidbody2D.velocity = new Vector2 (velocity, direction);
     }


}
