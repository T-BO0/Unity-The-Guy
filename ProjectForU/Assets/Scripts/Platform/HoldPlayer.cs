using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPlayer : MonoBehaviour
{
    //if object's name is player platform becomes parent
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
            other.gameObject.transform.SetParent(transform);
    }


    //removes player from platform. platform is not parent anymore
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
            other.gameObject.transform.SetParent(null);
    }
}
