using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    private ParticleSystem _particleSystem;
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
            StartCoroutine(Sink());
        }
    }
    
    IEnumerator Sink()
    {
        _isShooting = true;
        Destroy(_turret);
        _particleSystem.Stop();
        while (transform.position.y > -5)
        {
            transform.position -= Vector3.up * Time.deltaTime / 3f;
            yield return null;
        }
        Destroy(gameObject);
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
            Vector3 desiredPosition = transform.forward * Time.deltaTime * _speed;
            transform.position += new Vector3(desiredPosition.x, 0, desiredPosition.z);
            //transform.position = new Vector3(transform.position.x, -2.71f, transform.position.z);
        }

    }
}
