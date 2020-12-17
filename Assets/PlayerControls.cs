using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D player;  // player Rbody
    public float jumpThrust = 10;   // jump how high?
    public float runSpeed = 2;  // run how fast?
    Stopwatch timer = new Stopwatch();
    float jumpVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        // TODO load player assets
        // TODO load bg and enemies if Caleb hasn't
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * runSpeed * Time.deltaTime;
        //player.velocity += Vector2.up*jumpVelocity;

        //jumpVelocity *= .8f;
        //if (jumpVelocity < .02f)
        //    jumpVelocity = 0;
        
        // TODO enemies slow player

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.Debug.Log("Jump");
            //jumpVelocity= jumpThrust;
            player.AddForce(Vector2.up * jumpThrust, ForceMode2D.Impulse);
            // TODO jump animation
        }
    }
}
