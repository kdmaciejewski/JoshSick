using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAnimation : MonoBehaviour
{
    public void InitAndDestroy(float delay)
    {
        //Instantiate(gameObject);
        Destroy(gameObject, delay);
    }
}
