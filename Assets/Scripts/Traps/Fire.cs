using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Trap
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _damage;


    protected override void KillPlayer(IPlayer player)
    {
        MakeDamage();
        base.KillPlayer(player);
    }

    public void MakeDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2);

        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb)
            {
                Vector2 direction = rb.position - (Vector2)transform.position;
                float distance = direction.magnitude;
                float force = 1 - (distance / _damage);
                rb.AddForce(direction.normalized * _damage * force);
            }
        }

    }
}
