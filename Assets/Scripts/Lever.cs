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
    public string examined;

    private void Reset() {
        GetComponent<Collider2D>().isTrigger = true;
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
                break;
            case interaction.GAME:
                SceneManager.LoadScene(win);
                break;
            default:
                break;
        }
    }
}
