using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : MonoBehaviour
{
    private Player player;
    int i = 0;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            player.Fever += 1;
            InvokeRepeating("AddValue", 0.1f, 0.1f); // function string, start after float, repeat rate float
        }
    }
    private void AddValue()
    {
        if (i < 10)
        {
            player.Crystals++;
            i++;
        }
    }
}
