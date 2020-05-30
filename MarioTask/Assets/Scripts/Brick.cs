using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject brickBreakParticles;
    public AudioClip brickBounce;
    public AudioClip brickBreak;

    private AudioSource source;
    private Animator anim;
    ScoreManager sm;

    public void DestroyBricks()
    {
        Vector3 pos = transform.position;
        source.PlayOneShot(brickBreak);
        GetComponentInParent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        //The clone should be destroyed after it's action
        GameObject newBricKParticle = Instantiate(brickBreakParticles, pos, Quaternion.Euler(-90, 0, 0));
        Destroy(newBricKParticle, 0.6f);

        Destroy(this.gameObject,0.6f);
        
    }

    void Awake()
    {
        sm = FindObjectOfType<ScoreManager>();
        source = GetComponent<AudioSource>();
        anim = GetComponentInParent<Animator>();
        anim.SetBool("EmptyBlock", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && IsPlayerBelow(collision.gameObject, this.gameObject))
        {
            collision.gameObject.GetComponent<PlayerController>().isJumping = false;

            if (collision.transform.GetComponent<PlayerController>().poweredUp)
            {
             
                DestroyBricks();
                
                sm.Brick();
       
            }
            else
            {
                anim.SetTrigger("GotHit");
                source.PlayOneShot(brickBounce);
            }
        }
    }

    public bool IsPlayerBelow(GameObject go, GameObject current)
    {
        if ((go.transform.position.y + 1.4f < current.transform.position.y))
            return true;
        if ((go.transform.position.y + 0.4f < current.transform.position.y) && !go.transform.GetComponent<PlayerController>().poweredUp)
            return true;
        return false;
    }

    
}
