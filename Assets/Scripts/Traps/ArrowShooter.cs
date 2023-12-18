using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : Trap
{
    [SerializeField] private GameObject _suriken;
    [SerializeField] private float shootForce;
    private bool _isTrapActive = false;



    public void Shoot()
    {
        var suriken = Instantiate(_suriken, transform.position, Quaternion.identity);
        var rb = suriken.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.up * shootForce);
    }
    public override void PlayAnimation(string name)
    {
        if (!_isTrapActive)
        {
            base.PlayAnimation(name);
            Shoot();
            _isTrapActive = true;
        }

    }
}
