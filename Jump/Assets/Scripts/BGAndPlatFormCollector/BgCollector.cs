using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgCollector : MonoBehaviour
{
    private GameObject[] bg;
    private float firsty;
    // Start is called before the first frame update
    void Awake()
    {
        bg = GameObject.FindGameObjectsWithTag("BackGround");
        firsty = bg[0].transform.position.y;
        for(int i=0;i<bg.Length;i++)
        {
            if(firsty<bg[i].transform.position.y)
            {
                firsty = bg[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BackGround")
        {
            Vector3 temp = collision.transform.position;
            float height = ((BoxCollider2D)collision).size.y;

            temp.y = firsty + height;
            collision.transform.position = temp;
            firsty = temp.y;
        }
    }
}
