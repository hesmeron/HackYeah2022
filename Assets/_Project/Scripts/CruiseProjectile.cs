using UnityEngine;

public class CruiseProjectile : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10f;
        if (transform.position.magnitude < 2.5f)
        {
            Player.Instance.GetHit();
            Instantiate(_particleSystem).transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
