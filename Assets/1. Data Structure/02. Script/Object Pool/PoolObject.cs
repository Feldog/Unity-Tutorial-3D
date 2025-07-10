using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private ObjectPoolQueue pool;

    private Rigidbody rb;
    public float shootPower;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if(pool != null)
            Invoke("ReturnPool", 3f);
        if(rb == null)
            rb = GetComponent<Rigidbody>();

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(Vector3.forward * shootPower, ForceMode.Impulse);
    }


    public void SetObjectPoolQueue(ObjectPoolQueue pool)
    {
        this.pool = pool;
    }

    private void ReturnPool()
    {
        pool.EnqueueObject(gameObject);
    }
}
