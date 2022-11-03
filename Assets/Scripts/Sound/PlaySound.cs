using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public string name;
    
    public void soundTest()
    {
        FindObjectOfType<AudioManager>().Play(name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
