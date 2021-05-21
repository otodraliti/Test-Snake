using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private PlayerTail player;

    public Material green;
    public Material blue;



    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTail>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "Green")
        {
            if (other.gameObject.tag == "Player")
            {
                player.isGreen = true;
                player.isBlue = false;

                player.gameObject.GetComponent<MeshRenderer>().material = green;
                for (int i = 0; i < player.Tail.Count; i++)
                {
                    player.Tail[i].GetComponent<MeshRenderer>().material = green;
                }
            }
        }
        if (this.gameObject.tag == "Blue")
        {
            if (other.gameObject.tag == "Player")
            {
                player.isGreen = false;
                player.isBlue = true;

                player.gameObject.GetComponent<MeshRenderer>().material = blue;
                for (int i = 0; i < player.Tail.Count; i++)
                {
                    player.Tail[i].GetComponent<MeshRenderer>().material = blue;
                }
            }
        }
    }

}
