using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("abc");
        var enemy = collision.GetComponent<Enemy>();

        if (enemy != null && enemy.CompareTag("Trap"))
        {
            Debug.Log("egf");
            enemy.Die();
            Destroy(gameObject);
        }
    }
}
