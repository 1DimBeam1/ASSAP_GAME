using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfScript : MonoBehaviour
{
    Rigidbody2D phys;
    public Transform player;
    public Transform localPoint;
    Animator anim;

    public float speed;
    public float agroDist;

    bool agro = false;
    bool home = true;

    private void Start()
    {
        phys = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(25, 25, true);
    }

    private void Update()
    {
        Chill();
        Hunt();
        GoBack();
    }

    public int protectArea;

    void Chill()
    {
        if (!agro && home)
        {
            float distPoint = Vector2.Distance(transform.position, localPoint.position);

            if (distPoint > protectArea)
            {
                phys.velocity = new Vector2(0, 0);
                phys.transform.localScale *= new Vector2(-1, 1);
            }

            if (phys.transform.localScale.x > 0)
            {
                phys.velocity = new Vector2(-speed, 0);
            }
            else
            {
                phys.velocity = new Vector2(speed, 0);
            }
        }

    }

    void Hunt()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroDist)
        {
            agro = true;
            home = false;
            if (player.position.x < transform.position.x)
            {
                phys.velocity = new Vector2(-speed, 0);
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                phys.velocity = new Vector2(speed, 0);
                transform.localScale = new Vector2(-1, 1);
            };

        }
        else
        {
            agro = false;
        }
    }

    bool flip = true;
    void GoBack()
    {
        float distPoint = Vector2.Distance(transform.position, localPoint.position);
        if (!agro && !home)
        {
            phys.velocity = new Vector2(-transform.localScale.x * speed, 0);
            if (flip)
            {
                phys.transform.localScale *= new Vector2(-1, 1);
                flip = false;
            }

        }
        else { flip = true; }
        if (distPoint < protectArea)
        {
            home = true;
        }
    }

    public int damage = 50;
    bool attakOn = true;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Hero" && attakOn)
        {
            anim.StopPlayback();
            anim.Play("WolfAttak");
            other.GetComponent<HeroCondition>().TakeDamage(damage);
            attakOn = false;
            Invoke("AttakON", 1.5f);
        }
    }
    void AttakON()
    {
        attakOn = true;
    }
}
