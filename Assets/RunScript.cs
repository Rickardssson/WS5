using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class KeyBindTest : MonoBehaviour
{
    
    Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        
        playerAnimator.SetBool("running", false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            playerAnimator.SetBool("running", true);
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true;
        }
        
        if (Input.GetKey("d"))
        {
            playerAnimator.SetBool("running", true);
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyUp("a"))
        {
            playerAnimator.SetBool("running", false);
        }
        
        if (Input.GetKeyUp("d"))
        {
            playerAnimator.SetBool("running", false);
        }

    }
}
