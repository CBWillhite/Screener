using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjects : MonoBehaviour
{
    public List<GameObject> toLoad;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(GameObject item in toLoad)
        {
            item.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
