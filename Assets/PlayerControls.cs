using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D player;  // player Rbody
    public float jumpThrust = 10;   // jump how high?
    public float runSpeed = 2;  // run how fast?
    public Animator playerAnimations;
    int jumps = 0;
    bool isFalling;
    bool isJumping;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * runSpeed * Time.deltaTime; // consistant movement to the right at the players run speed

        if(player.velocity.y > 0)   // checks if the player is ascending
        {
            isJumping = true;   // VS recognizes that the player is ascending, thus jumping
        }
        else
        {
            isJumping = false;  // VS recognizes that the player is not ascending, thus not jumping
        }

        if (player.velocity.y <= -0.1)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumps < 2) // checks if space was pressed, AND if the player has already jumped twice
        {
            player.AddForce(Vector2.up * jumpThrust, ForceMode2D.Impulse);  // applies force upwards
            playerAnimations.SetBool("Jumping", true);  // applies jumping animation
            isJumping = true;   // VS recognizes the player as jumping
            jumps++;    // counts the number of times the player has jumped
        }

        if (isFalling == false && isJumping == false)   // checks if the player is ascending or descending, and goes forward is neither are happening
        {
            playerAnimations.SetBool("Jumping", false); // applies running animation again
            jumps = 0;  // resets number of jumps, so that the player can jump and double jump again after landing
        }
    }
}
