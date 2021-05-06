using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject btn;

    private bool hasjumped,platformbound;

    [SerializeField]
    private Text askore;

    private int score = 0;

    private Rigidbody2D mybody;
    private GameObject parent;
    public delegate void Movecamera();
    public static event Movecamera move;
    // Start is called before the first frame update
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        askore.text = score.ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
      
            if (hasjumped && mybody.velocity.y == 0)
            {
            if (!platformbound)
            {
       
                hasjumped = false;
                score++;
                askore.text = score.ToString();
                transform.SetParent(parent.transform);
                gampplaycontroller.instance.createPlatform();
                if (move != null)
                {
                    move();
                }
            }
            else if (parent != null)
            {
                transform.SetParent(parent.transform);
            }
        }
    
    }


    public void jump()
    {

        if (mybody.velocity.y == 0)
        {
            mybody.velocity = new Vector2(0, 10);
            transform.SetParent(null);
            hasjumped = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Platform")
        {
           
            parent = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            parent = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
            platformbound = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
            platformbound = false;
    }
}
