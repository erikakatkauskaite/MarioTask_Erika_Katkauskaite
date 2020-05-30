using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlock : MonoBehaviour
{
    public GameObject InvisibleBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (FindObjectOfType<Brick>().IsPlayerBelow(collision.gameObject, this.gameObject)))
        {
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            //I am replacing the invisible trigger with the questionBrick prefab in case we want to use it more than once but if we would like to show the certain object from the hierarchy we could do that as well by writing this and setting the wanted object in the inspector. We would only need to switch the Instantiate line with this one below
            //InvisibleBox.SetActive(true);
            Instantiate(InvisibleBox,this.transform.position, Quaternion.identity);
            
        }
    }
}
