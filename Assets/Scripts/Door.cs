using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public GameObject doorClosed;
    public GameObject doorOpened;
    public string targetTag;
    public UnityEvent doorOpenEvent;
    private bool isDoorOpen = false;

    void Awake()
    {
        if (doorOpenEvent == null)
        {
            doorOpenEvent = new UnityEvent();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isDoorOpen)
        {
            return;
        }

        if (col.gameObject.tag == targetTag)
        {
            isDoorOpen = true;

            doorClosed.SetActive(false);
            doorOpened.SetActive(true);

            doorOpenEvent.Invoke();
        }
    }
}
