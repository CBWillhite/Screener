using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Lever : MonoBehaviour
{
    public enum interaction {NONE,LEVER,EXAMINE,LEVEL,GAME}
    public interaction type;
    public List<GameObject> doors;
    public Text wins;
    public string win;
    public string level;
    public string examined;
    public bool toggleUIFade = false;
    public GameObject obj;

    [SerializeField] private CanvasGroup aUIGroup;
    [SerializeField] private CanvasGroup NextSceneFade;
    [SerializeField] private GameObject aUIGroupObj;
    [SerializeField] private GameObject NextSceneFadeObj;

    [SerializeField] private bool inFade = false;
    [SerializeField] private bool outFade = false;

    private void Reset() {
        GetComponent<Collider2D>().isTrigger = true;
    }

    public void FadeIn()
    {
        inFade = true;
    }

    public void FadeOut()
    {
        outFade = true;
    }

    public void locationReset()
    {
        obj.transform.position = new Vector3(0,0,0);
    }

    private void Awake() {
        if(toggleUIFade) {
            FadeOut();
            while(outFade)
            {
                if(aUIGroup.alpha>=0)
                {
                    aUIGroup.alpha -= (Time.deltaTime);
                    if(aUIGroup.alpha==0)
                    {
                        outFade = false;
                    }
                }
            }
        }
    }

    public void Interact() {
        switch(type)
        {
            case interaction.LEVER:
                foreach(GameObject doo in doors){
                    if(doo.activeSelf)
                    {
                        doo.SetActive(false);
                    }
                    else{
                        doo.SetActive(true);
                    }
                }
                break;
            case interaction.EXAMINE:
                break;
            case interaction.LEVEL:
                NextSceneFade.alpha=0;
                aUIGroupObj.SetActive(false);
                FadeIn();
                while(inFade)
                {
                    if(NextSceneFade.alpha<1)
                    {
                        NextSceneFade.alpha += (Time.deltaTime);
                        if(NextSceneFade.alpha>=1)
                        {
                            inFade = false;
                        }
                    }
                }
                NextSceneFadeObj.SetActive(true);
                locationReset();
                SceneManager.LoadScene(level);
                break;
            case interaction.GAME:
                Destroy(obj);
                SceneManager.LoadScene(win);
                break;
            default:
                break;
        }
    }
}
