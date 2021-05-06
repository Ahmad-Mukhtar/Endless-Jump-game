using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    private bool canmove;
    private float distanc = 4f;
   

    private float destination;
    // Update is called once per frame
    void Update()
    {
        moveCamera();
       
    }
    void OnEnable()
    {
        PlayerScript.move += Move;
       
    }
    void OnDisable()
    {
        PlayerScript.move -= Move;
      
    }

    private void moveCamera()
    {
        if (canmove)
        {
            Vector3 temp = transform.position;
            Vector3 camhandling=transform.position;
            temp.y += 3f*Time.deltaTime;

            transform.position = temp;


            if (transform.position.y >=destination)
            {
               
                camhandling.y = destination;
                transform.position= camhandling;
                canmove = false;
            }
        }
    }
  void Move()
    {
       
        destination = transform.position.y + distanc;
        canmove = true;
    }
}
