using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerCharacter2D : CharacterController2D
{
    public float speed = 10.0f;
    public float collisionTestOffset;
    public float jumpStrength = 5.0f;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rigidbody2D;
    private float jumpInputLastFrame = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        isTouchingGround = IsTouchingGround();
        Vector2 motion = rigidbody2D.velocity;

        // Test before moving
        if (xInput != 0.0f)
        {

            if((!TestMove(Vector2.right, collisionTestOffset) && xInput > 0.0f)&&!isTouchingGround) 
            {
                motion.x = -xInput * (speed * 0.01f);
                if ((Input.GetAxis("Jump") > 0.0f)){
                    motion.y = jumpStrength;
                    motion.x = -speed+2.5f;
                    isTouchingGround = false;
                }
                
            } else if((!TestMove(Vector2.left, collisionTestOffset) && xInput < 0.0f)&&!isTouchingGround) 
            {
                motion.x = -xInput * (speed * 0.01f);
                if ((Input.GetAxis("Jump") > 0.0f)){
                    motion.y = jumpStrength;
                    motion.x = speed+2.5f;
                    isTouchingGround = false;
                }
            } else 
            {
                motion.x=xInput*speed;
            }
            
        }
        if ((Input.GetAxis("Jump") > 0.0f) && isTouchingGround){
            motion.y = jumpStrength;
        }

        rigidbody2D.velocity = motion;
    }
}
