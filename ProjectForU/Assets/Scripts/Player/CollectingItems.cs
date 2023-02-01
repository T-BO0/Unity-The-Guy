using UnityEngine;
using UnityEngine.UI;

public class CollectingItems : MonoBehaviour
{
    int oranges;
    [SerializeField] Text orangeCounter;
    [SerializeField] AudioSource collectingSound;
    void OnTriggerEnter2D(Collider2D collision) 
    {
        //if object's name is "Orange" play sound, destroy the orange and orangeCounter + 1
        if(collision.gameObject.CompareTag("Orange"))
        {
            collectingSound.Play();
            Destroy(collision.gameObject);
            oranges++;
            orangeCounter.text = "Orange: " + oranges;
        }
    }
}
