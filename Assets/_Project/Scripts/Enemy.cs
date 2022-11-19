using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    private Turret _turret;
    
    private Vector3 steer = Vector3.zero;
    private float _speed = 0.5f;
    [SerializeField]
    [ReadOnly]
    private bool _isShooting = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.TryGetComponent(out Projectile projectile))
        {
            Destroy(projectile.gameObject);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!_isShooting)
        {
            float random = Random.Range(-1f, 1f) * 0.001f;
            steer += transform.right * random * Time.deltaTime;
            if (transform.position.magnitude > 20)
            {
                steer += 0.00001f * Time.deltaTime * -transform.position.normalized;
            }
            else
            {
                if (Random.Range(0, 0.01f) < 0.01f)
                {
                    _isShooting = true;
                    _turret.AimAndShoot();
                }
                steer += 0.001f * Time.deltaTime * transform.position.normalized;
            }

            transform.forward += steer;
            transform.position += transform.forward * Time.deltaTime * _speed;
        }

    }
}
