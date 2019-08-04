﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    #region MOVEMENT
    [SerializeField] float jumpVelocity = 5f;
    [SerializeField] float groundedSkin = 0.05f;
    [SerializeField] LayerMask mask;

    [Space] 

    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;

    Rigidbody2D rb;
    bool jumpRequest, grounded;
    Vector2 playerSize, boxSize;
    #endregion

    #region GAME LOOP
    bool firstJump;
    int jumpMultiplier = 1;
    #endregion

    void Awake() {
        rb = GetComponent<Rigidbody2D>();

        //get player size and box ground check size
        playerSize = GetComponent<BoxCollider2D>().bounds.size;
        boxSize = new Vector2(playerSize.x, groundedSkin);
    }

    void Update() {
        //sets jump for the next fixed update
        if (Input.GetButtonDown("Jump")) {
            jumpRequest = true;

            //hide main menu and start game on first screen
            if (!firstJump) {
                firstJump = true;
                MatchManager.instance.StartGame();
            }
        }        
    }

    void FixedUpdate() {
        //ground check
        Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxSize.y) * 0.5f;
        grounded = (Physics2D.OverlapBox(boxCenter, boxSize, 0f, mask) != null);

        //executes jump in correct physics time
        if (jumpRequest && grounded) {
            rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            jumpRequest = false;

            //add jump counter
            MatchManager.instance.CountJump(jumpMultiplier);
        }

        if (rb.velocity.y < 0) {
            rb.gravityScale = fallMultiplier; //quicker fall for snappier jump
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.gravityScale = lowJumpMultiplier; //different heights depending on time holding button
        }
        else {
            rb.gravityScale = 1f; //normal scale
        }
    }

    //collision with objects
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            firstJump = false;
            MatchManager.instance.EndGame();
        }
    }
}