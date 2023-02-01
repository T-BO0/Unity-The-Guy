using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rgb;
    [SerializeField] AudioSource deathSound;
    void Start()
    {
        animator = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Trap"))//check if object's tag is "Trap"
            Death();
    }

    void Death()
    {
        deathSound.Play();
        rgb.bodyType = RigidbodyType2D.Static;//dead man dont move 
        animator.SetTrigger("Death");
    }

    void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);//restart lvl
        
}
