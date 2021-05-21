using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private GameObject player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "Green" && player.GetComponent<PlayerTail>().isGreen == true)
            {
                player.GetComponent<Player>().Fever = 0;
                Destroy(gameObject);
            }
            else if (this.gameObject.tag == "Blue" && player.GetComponent<PlayerTail>().isBlue == true)
            {
                player.GetComponent<Player>().Fever = 0;
                Destroy(gameObject);
            }
            else
            {
                if (player.GetComponent<Player>().isFeverActive == true)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Death");
                }
            }
        }
    }




}
