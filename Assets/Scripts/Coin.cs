using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//Task 2 (week 13): coins are randomly created on the screen, player can pick them up for +10 to their score
public class Coin : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject coinPrefab;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame

    //coin deletes after 3 seconds
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            Destroy(this.gameObject);
        }
    }

    //if coin comes into contact with player, it is destroyed and rewards them 10 points
    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        if (whatHitMe.tag == "Player")
        {
            gameManager.AddScore(10);
            Destroy(this.gameObject);
        }
    }

}
