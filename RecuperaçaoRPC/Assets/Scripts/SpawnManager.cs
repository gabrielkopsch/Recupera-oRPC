using Photon.Pun.Demo.Asteroids;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    string apple1Prefab = "Prefabs/Apple1";
    string apple2Prefab = "Prefabs/Apple2";
    string apple3Prefab = "Prefabs/Apple3";

    float timer;
    const float cooldown = 1f;
    float appleIndex;

    string appleSelected;
    void Update()
    {
        if (Photon.Pun.PhotonNetwork.IsMasterClient)
        {
            spawn();
        }
    }
   
    void spawn()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            appleIndex = Random.Range(0f, 1f);
            if (appleIndex <= 0.5)
            {
                appleSelected = apple1Prefab;
            }
            else
        if (appleIndex > 0.5 && appleIndex <= 0.8)
            {
                appleSelected = apple2Prefab;
            }
            else
        if (appleIndex > 0.8)
            {
                appleSelected = apple3Prefab;
            }
            
           // NetworkManager.instance.Instantiate(appleSelected, new Vector2(GameManager.instance.ScreenBounds.x, Random.Range(-2, 2)), Quaternion.identity);
            NetworkManager.instance.Instantiate(appleSelected, new Vector2(Random.Range(-4, 4), GameManager.instance.ScreenBounds.y), Quaternion.identity);


            timer = cooldown;
        }
       


    }
    Vector2 screenBounds;
    Vector2 GeneratePosition(GameObject objectSelected)
    {
        Vector2 spriteBounds = objectSelected.GetComponent<SpriteRenderer>().bounds.size / 2;

        Vector2 bounds = new Vector2(screenBounds.x - spriteBounds.x, screenBounds.y + spriteBounds.y);

        Debug.Log(spriteBounds);
        Debug.Log(bounds);
        return new Vector2(Random.Range(-bounds.x, bounds.x), bounds.y);
    }
}
