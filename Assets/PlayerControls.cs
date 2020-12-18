using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D player;  // player Rbody
    public float jumpThrust = 10;   // jump how high?
    public float runSpeed = 2;  // run how fast?
    public Animator playerAnimations;
    Stopwatch timer = new Stopwatch();
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * runSpeed * Time.deltaTime;
        
        // TODO enemies slow player

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.AddForce(Vector2.up * jumpThrust, ForceMode2D.Impulse);
            playerAnimations.SetBool("Jumping", true);
            // TODO after you land change back to running animation
        }
    }
}
