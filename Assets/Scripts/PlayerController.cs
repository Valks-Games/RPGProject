using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed = 500f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool walkingNorth;
    private bool walkingSouth;
    private bool walkingWest;
    private bool walkingEast;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)){
            speed = 1000f;
            anim.speed = 2f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = 500f;
            anim.speed = 1f;
        }

        if (Input.GetKey(KeyCode.W) && !walkingEast && !walkingWest && !walkingSouth)
        {
            walkingNorth = true;
            anim.Play("WalkNorth");
            return;
        }
        if (Input.GetKey(KeyCode.S) && !walkingEast && !walkingWest && !walkingNorth)
        {
            walkingSouth = true;
            anim.Play("WalkSouth");
            return;
        }
        if (Input.GetKey(KeyCode.D) && !walkingNorth && !walkingSouth && !walkingWest)
        {
            walkingEast = true;
            anim.Play("WalkHorz");
            spriteRenderer.flipX = false;
            return;
        }
        if (Input.GetKey(KeyCode.A) && !walkingNorth && !walkingSouth && !walkingEast)
        {
            walkingWest = true;
            anim.Play("WalkHorz");
            spriteRenderer.flipX = true;
            return;
        }
        else {
            if (Input.GetKeyUp(KeyCode.W))
            {
                walkingNorth = false;
                anim.Play("IdleNorth");
                return;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                walkingSouth = false;
                anim.Play("IdleSouth");
                return;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                walkingEast = false;
                spriteRenderer.flipX = false;
                anim.Play("IdleHorz");
                return;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                walkingWest = false;
                spriteRenderer.flipX = true;
                anim.Play("IdleHorz");
                return;
            }

            walkingNorth = false;
            walkingSouth = false;
            walkingWest = false;
            walkingEast = false;
        }
    }

    private void FixedUpdate()
    {
        if (walkingNorth) {
            rb.AddForce(new Vector2(0, speed * Time.deltaTime));
        }
        if (walkingSouth) {
            rb.AddForce(new Vector2(0, -speed * Time.deltaTime));
        }
        if (walkingEast) {
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0));
        }
        if (walkingWest) {
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("HouseTrigger")){
            SceneManager.LoadScene("Structure");
        }
    }
}
