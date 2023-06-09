using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollider : MonoBehaviour
{
    private int cherries = 0;
    [SerializeField] private TMP_Text wisienki;
    [SerializeField] private AudioSource collectionSound;

     //zderzenie z wiśnią
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            wisienki.text = "Wisienki: " + cherries;
            collectionSound.Play();
        }
    }
}
