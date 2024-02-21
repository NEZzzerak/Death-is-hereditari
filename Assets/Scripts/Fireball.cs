using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed;
    public float lifetime;
    public float damage = 10;
    public void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }
  
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyFireball();
    }
    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
      
    }
}
