using UnityEngine;

public class Enemy : MonoBehaviour
{
    public DieAnimation dieAnimation;   

    public void Die()
    {
        //dieAnimation.InitAndDestroy(2f);
        Destroy(gameObject);
    }
}
