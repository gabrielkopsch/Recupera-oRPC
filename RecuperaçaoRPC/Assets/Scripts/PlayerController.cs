using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerController : MonoBehaviourPun
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] bool controllerOn = true;
    [SerializeField] Vector2 direction;
    [SerializeField] float speed = 10;
    [SerializeField] Rigidbody2D rb;

    Apple apple;
    GameManager gameManager;

    private void Update()
    {
        if (controllerOn)
        {
            direction.x = Input.GetAxis("Horizontal");
            Movement();
           
        }
    }

    void Movement()
    {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        Vector2 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, -GameManager.instance.ScreenBounds.x, GameManager.instance.ScreenBounds.x);

        transform.position = playerPosition;
    }


    [PunRPC]
    public void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!photonView.IsMine)
        {
            Color newColor = spriteRenderer.color;
            newColor.a = 0.2f;
            spriteRenderer.color = newColor;
            controllerOn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Apple")
        {
            PhotonNetwork.Destroy(collision.gameObject);
            GameManager.instance.photonView.RPC("SetScore", RpcTarget.All, 5);
        }
    }

}