using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{   
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject player;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //wyznaczamy odległośc od playera żeby widzieć kiedy zacząć strzelać
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 8){
            timer += Time.deltaTime;
            if(timer > 4){
                timer = 0;
                shoot();
            }
        }
       
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
