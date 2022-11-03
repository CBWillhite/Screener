using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public GameObject groundCheckPosition;
    public GameObject debugTarget;
    public GameObject debugDirection;
    public GameObject rayDebug;
    public Vector3 groundCheckSize = new Vector3(0.75f, 0.2f, 1.0f);
    public List<string> jumpableTags = new List<string>();
    public ContactFilter2D contactFilter2D;
    public CapsuleCollider2D capsuleCollider2D;
    public bool isTouchingGround;
    
    private Ray ray;
    
    void Awake()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void OnDrawGizmosSelected()
    {
        if (isTouchingGround)
            Gizmos.color = new Color(0, 1, 0, 0.5f);
        else
            Gizmos.color = new Color(1, 0, 0, 0.5f);

        //Gizmos.color = (isTouchingGround) ? new Color(0, 1, 0, 0.5f) : new Color(1, 0, 0, 0.5f);

        Gizmos.DrawCube(groundCheckPosition.transform.position, groundCheckSize);

        Gizmos.DrawRay(ray);
    }

    public bool TestMove(Vector2 direction, float offset)
    {
        return TestMove(direction, offset, jumpableTags);
    }

    public bool TestMove(Vector2 direction, float offset, List<string> tags)
    {
        List<RaycastHit2D> results = new List<RaycastHit2D>();

        return TestMove(direction, offset, tags, results);
    }

    public bool TestMove(Vector2 direction, float offset, List<string> tags, List<RaycastHit2D> results)
    {
        Vector2 origin = ((Vector2)transform.position)+capsuleCollider2D.offset+(direction*offset);

        Physics2D.BoxCast(origin, capsuleCollider2D.size*0.6f, 0.0f, Vector2.right, contactFilter2D, results, 0.1f); //new Vector2(capsuleCollider2D.size.x*0.9f, capsuleCollider2D.y*0.9f)

        foreach(RaycastHit2D hit in results)
        {
            if (tags.Contains(hit.collider.gameObject.tag))
            {
                return false;
            }
        }

        return true; //Nothing was hit.
    }

    public bool IsTouchingGround()
    {
        List<RaycastHit2D> results = new List<RaycastHit2D>();

        GroundCheck(results);

        /*if (results.Count > 0)
        {*/
            foreach(RaycastHit2D hit in results)
            {
                if(jumpableTags.Contains(hit.collider.gameObject.tag))
                {
                    return true;
                }
            }
            return false;
        /*}
        else
        {
            return false;
        }*/
    }

    public void GroundCheck(List<RaycastHit2D> results)
    {
        Physics2D.BoxCast(
            new Vector2(groundCheckPosition.transform.position.x, groundCheckPosition.transform.position.y),
            new Vector2(groundCheckSize.x, groundCheckSize.y),
            0.0f,
            Vector2.right,
            contactFilter2D,
            results,
            0.1f
        );
    }
}
