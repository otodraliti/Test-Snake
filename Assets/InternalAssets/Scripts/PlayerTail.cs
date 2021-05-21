using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTail : MonoBehaviour
{
    public List<GameObject> Tail;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float SmoothSpeed;
    public GameObject target;



    public bool isGreen;
    public bool isBlue;
    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Tail.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        TailMovement();
    }


    private void TailMovement()
    {
        Vector3 smoothPose0 = Vector3.Lerp(Tail[0].transform.position, target.transform.position + offset, SmoothSpeed);
        Tail[0].transform.position = smoothPose0;

        for (int i = 1; i < Tail.Count; i++)
        {
            Vector3 smoothPose = Vector3.Lerp(Tail[i].transform.position, Tail[i - 1].transform.position + offset, SmoothSpeed);
            Tail[i].transform.position = smoothPose;
        }
    }
}
