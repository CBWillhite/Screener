using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyonLoad : MonoBehaviour
{
    
    public static DontDestroyonLoad instance;

    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
