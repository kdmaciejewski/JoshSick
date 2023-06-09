using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        //jeżeli player jest na platformiee to rusza sie tak jak ona
        if(other.gameObject.name == "Player"){
            other.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
          if(other.gameObject.name == "Player"){
            other.gameObject.transform.SetParent(null);
        }
    }
}   
