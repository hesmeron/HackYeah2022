using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.TryGetComponent(out Projectile projectile))
        {
            Destroy(projectile.gameObject);
            Destroy(gameObject);
        }
    }
}
