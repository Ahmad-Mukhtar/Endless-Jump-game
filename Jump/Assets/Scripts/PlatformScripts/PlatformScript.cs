using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private float speed = 1f;
    private float boundleft = -0.26f,boundright=3.24f;
    private bool left;

    // Start is called before the first frame update
    void Awake()
    {
        Randomize();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Randomize()
    {

        if (Random.Range(0, 2) == 0)
           left = true;
        else
            left= false;
    }
    private void Move()
    {
        if(left==true)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
            if(transform.position.x<boundleft)
            {
                left = false;
            }
        }
        else
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
            if (transform.position.x >boundright)
            {
                left = true;
            }
        }

    }


}
