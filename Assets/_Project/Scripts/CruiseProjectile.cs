using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CruiseProjectile : MonoBehaviour
{
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10f;
        if (transform.position.magnitude < 1.5f)
        {
            Player.Instance.GetHit();
            Destroy(this.gameObject);
        }
    }
}
