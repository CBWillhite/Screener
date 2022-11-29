using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAndOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup aUIGroup;

    [SerializeField] private bool inFade = false;
    [SerializeField] private bool outFade = false;

    public void FadeIn()
    {
        inFade = true;
    }

    public void FadeOut()
    {
        outFade = true;
    }

    private void Update()
    {
        if(inFade)
        {
            if(aUIGroup.alpha<1)
            {
                aUIGroup.alpha += (Time.deltaTime)*2;
                if(aUIGroup.alpha>=1)
                {
                    inFade = false;
                }
            }
        }

        if(outFade)
        {
            if(aUIGroup.alpha>=0)
            {
                aUIGroup.alpha -= (Time.deltaTime)*2;
                if(aUIGroup.alpha==0)
                {
                    outFade = false;
                }
            }
        }
    }
}
