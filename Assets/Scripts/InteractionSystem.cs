using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public Transform detectPoint;
    private const float detectRadius = 0.4f;
    public LayerMask detectLayer;
    public GameObject detectObj;

    void Update()
    {
        if(DetectObject() && InteractInput()){
            detectObj.GetComponent<Lever>().Interact();
        }
    }

    bool InteractInput() {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject() {
        Collider2D obj = Physics2D.OverlapCircle(detectPoint.position,detectRadius,detectLayer);
        if(obj==null)
        {
            detectObj = null;
            return false;
        }
        else
        {
            detectObj = obj.gameObject;
            return true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectPoint.position,detectRadius);
    }
}
