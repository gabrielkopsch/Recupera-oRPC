using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviourPun
{
    const float velocity = 10;
    float direction;
    Rigidbody2D rigidbody2D;
    bool playerLocal;
    bool controllerOn = true;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    [PunRPC]
    private void Intializate()
    {
        if (!photonView.IsMine)
        {
            Color color = Color.white;
            color.a = 0.2f;
            GetComponent<SpriteRenderer>().color = color;
            controllerOn = false;
            
        }
       
    }
  // Update is called once per frame
    void Update()
    {
        if (controllerOn) 
        {
            Input.GetAxis("Horizontal");
            Move();
        } 
    }

    void Move()
    {
        

     }

}
