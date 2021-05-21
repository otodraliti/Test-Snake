using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float poseZ;
    private float poseX;
    private float rotateY;

    [SerializeField] private float Speed;
    [SerializeField] private float SideSpeed;

    public int Crystals;
    public Text count;

    public int Fever;

    // Start is called before the first frame update
    void Start()
    {
        poseZ = transform.position.z;
        poseX = transform.position.x;
        rotateY = transform.rotation.y;
        timerFever = maxFever;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        FeverMain();
        count.text = Crystals.ToString("");

    }

    private float maxFever = 5;
    private float timerFever;
    public bool isFeverActive;
    private void FeverMain()
    {
        if (Fever >= 3)
        {
            if (maxFever > 0)
            {
                isFeverActive = true;
                timerFever -= Time.deltaTime;
                if (timerFever <= 0)
                {
                    Debug.Log("FeverEnds");
                    Fever = 0;
                    timerFever = maxFever;
                }
            }
        }
    }

    private void Movement()
    {

        poseZ += Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            if (poseX <= 4)
            {
                poseX += SideSpeed * Time.deltaTime;
                rotateY += 60 * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, rotateY, 0);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (poseX >= -4)
            {
                poseX -= SideSpeed * Time.deltaTime;
                rotateY -= 60 * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, rotateY, 0);
            }
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            rotateY = 0;
        }
        
        transform.position = new Vector3(poseX, transform.position.y, poseZ);


        Quaternion target = Quaternion.Euler(0, 0, 0);
        Quaternion smoothPose0 = Quaternion.Lerp(transform.rotation, target, 0.05f);
        transform.rotation = smoothPose0;
    }

}
