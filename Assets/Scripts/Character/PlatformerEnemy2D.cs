using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerEnemy2D : CharacterController2D
{
    public float speed = 10.0f;
    public float collisionTestOffset;
    public Rigidbody2D rigidbody2D;
    public Vector2 direction = Vector2.right;
    public bool startRight = true;
    public int damage = 2;
    public List<string> tagsToDamage;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 motion = rigidbody2D.velocity;
        isTouchingGround = IsTouchingGround();

        if(isTouchingGround) {
            //Attack


            //Direction Change

            //wall
            if(!TestMove(direction, collisionTestOffset)) {
                direction *= -1;
            }

            rigidbody2D.velocity = direction * speed;
        }
    }
}
