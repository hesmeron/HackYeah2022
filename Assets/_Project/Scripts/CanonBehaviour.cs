using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    [SerializeField] 
    private TriggerBehaviour _trigger;

    [SerializeField]
    private ParticleSystem _particleSystem;
    
    [SerializeField]
    private Transform _pivot;

    [SerializeField]
    private GameObject _projectilePrefab;

    void Awake()
    {
        _trigger.onTriggerReleased += Shoot;
    }
    
    public void Shoot()
    {
        GameObject projectile = Instantiate(_projectilePrefab);
        projectile.transform.position = _pivot.transform.position;
        projectile.transform.forward = _pivot.forward;
        _particleSystem.Play();
    }
}
