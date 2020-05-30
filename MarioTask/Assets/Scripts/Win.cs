using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Win : MonoBehaviour
{
    public PlayableDirector tinyMarioDirector;
    public PlayableDirector bigMarioDirector;

    public bool gameHasEnded ;

    public void Start()
    {
        gameHasEnded = false;
    }
    public  void OnCollisionEnter2D(Collision2D collision)
    {     
        if (collision.gameObject.CompareTag("Player"))
        {
            gameHasEnded = true;
            if ( FindObjectOfType<PlayerController>().poweredUp)
            {
                bigMarioDirector.Play();
            }
           else
            {
                tinyMarioDirector.Play();
            }
           
        }
    }
}
