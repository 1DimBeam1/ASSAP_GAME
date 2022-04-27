using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lader : MonoBehaviour
{
    Animator anim;
    Animator animHr;
    bool on = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("ON", on);
    }

    [SerializeField]
    int speed ;

     void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.name == "Hero")
        {
            animHr = other.GetComponent<Animator>();
            if (Input.GetKey(KeyCode.E))
            {
                on = true;
                anim.SetBool("ON", on);
            }
            if (on)
            {
                other.GetComponent<Rigidbody2D>().gravityScale = 0;
                if (Input.GetKey(KeyCode.W))
                {
                    other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
                    animHr.StopPlayback();
                    animHr.Play("UpTree");
                }
                else if ((Input.GetKey(KeyCode.S)))
                {
                    other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
                    animHr.StopPlayback();
                    animHr.Play("UpTree");
                }
                else { other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); }
            }
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Hero")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 2;
        }
    }

}

