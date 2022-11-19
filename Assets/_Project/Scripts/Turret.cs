using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Random = UnityEngine.Random;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private Transform _pivot;

    private float _delay = 3f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, Vector3.zero);
    }
    
    
    [Button]
    private bool AdjustTurret()
    {
        Vector3 raw =  -transform.position;
        float x = Mathf.Lerp(transform.forward.x, raw.x, Time.deltaTime);
        float z = Mathf.Lerp(transform.forward.z, raw.z, Time.deltaTime);
        Vector3 desired = new Vector3(raw.x, 0, raw.z).normalized;
        transform.forward = new Vector3(x, 0, z);
        return (transform.forward - desired).magnitude < 0.5f;
    }

    public void Fire()
    {
        GameObject projectile = Instantiate(_projectile);
        projectile.transform.position = _pivot.position;
        projectile.transform.forward = _pivot.forward;
    }

    public void AimAndShoot()
    {
        StartCoroutine(AimAndShootCoroutine());
    }

    IEnumerator AimAndShootCoroutine()
    {
        while (gameObject)
        {
            
            if(AdjustTurret())
            {
                _delay -= Time.deltaTime;
                if (_delay <= 0)
                {
                    _delay += Random.Range(3, 7f);
                    Fire();
                }
            }
            yield return null;
        }

    }
}
