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

    float moveVector;
    bool flicCl = true;
    void Chill()
    {
        if (!agro && home)
        {
            float distPoint = Vector2.Distance(transform.position, localPoint.position);
            moveVector = phys.velocity.x;
            if (distPoint >= protectArea)
            {
                if (moveVector > 0 && flicCl) { phys.transform.localScale *= new Vector2(-1, 1); flicCl = false; }
                else if (moveVector < 0 && flicCl) { phys.transform.localScale *= new Vector2(-1, 1); flicCl = false; }
            }
            else { flicCl = true; }

            phys.velocity = new Vector2(-phys.transform.localScale.x * speed, 0);

        }
    }

    void Hunt()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroDist)
        {
            agro = true;
            home = false;
            phys.velocity = new Vector2(-phys.transform.localScale.x * speed, 0);
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

    void GoBack()
    {
        float distPoint = Vector2.Distance(transform.position, localPoint.position);
        if (!agro && !home)
        {

            if (localPoint.position.x < transform.position.x)
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
        if (distPoint < protectArea)
        {
            home = true;
        }
    }

    public int damage = 50;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.StopPlayback();
            anim.Play("WolfAttak");
            other.GetComponent<HeroCondition>().TakeDamage(damage);
        }
    }
}
