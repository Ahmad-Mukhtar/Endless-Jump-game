using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformcollector : MonoBehaviour
{
    private GameObject panel;
    private void Awake()
    {
        panel = GameObject.Find("GameoverPanel");
        panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Platform")
        {
            collision.gameObject.SetActive(false);
        }
        if(collision.tag=="Player")
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
        }
    }
}
