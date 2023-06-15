using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private TMP_Text zycia;
    public static int LifeCounter = 3;

    private void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        zycia.text = "Zycia: " + LifeCounter + "/3";
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Trap")){
            Die();
        }
    }

    public void Die(){
        LifeCounter = LifeCounter - 1;

        if(LifeCounter == 0){
            SceneManager.LoadScene(3);
            LifeCounter = 3;
        }
        else{
            zycia.text = "Zycia: " + LifeCounter + "/3";
            rb.bodyType = RigidbodyType2D.Static;
            deathSound.Play();
            anim.SetTrigger("death");
        }       
    }

    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
