using System;
using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody bombRb;

    public float bombTime = 4f;
    public float bombRange = 10f;
    public LayerMask targetLayer;


    private void Awake()
    {
        bombRb = GetComponent<Rigidbody>();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(bombTime);

        BombForce();
    }

    private void BombForce()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRange, targetLayer);

        foreach(Collider collider in colliders)
        {
            if(collider.TryGetComponent<Rigidbody>(out Rigidbody targetRb))
            {
                targetRb.AddExplosionForce(10f, transform.position, bombRange, 1f, ForceMode.Impulse);
            }
        }

        Destroy(gameObject);
    }
}
