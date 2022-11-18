using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grabable : InteractiveBehaviour
{
    [SerializeField] 
    private Transform _hmd;
    private Rigidbody _rigidbody;
    private Vector3 _targetPosition;
    private Quaternion targetRotation;
    private bool _isGrabbed = false;
    private GrabbableSocket _socket;
    [SerializeField] 
    private MeshRenderer _renderer;

    [SerializeField] private LineRenderer _line;

    private Material material;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _targetPosition = transform.position;
        material = new Material(_renderer.material);
        _renderer.material = material;
    }
    
    protected void  Update()
    {
        if (_isGrabbed){
            float speed = 4f;
            float x = Mathf.Lerp(transform.position.x, _targetPosition.x, Time.deltaTime * speed);
            float y = Mathf.Lerp(transform.position.y, _targetPosition.y, Time.deltaTime * speed);
            float z = Mathf.Lerp(transform.position.z, _targetPosition.z, Time.deltaTime * speed);
            transform.Translate( new Vector3(x, y, z) - transform.position, Space.World);
            
            if(Physics.Raycast(new Ray(transform.position, _hmd.transform.forward), out RaycastHit hit))
            {
                _line.enabled = true;
                Vector3[] positions = new[] {transform.position, hit.point};
                _line.SetPositions(positions);
                if (hit.collider.gameObject.TryGetComponent(out GrabbableSocket socket))
                {
                    _socket = socket;
                    material.color = Color.green;
                }
                material.color = Color.red;
                _socket = null;
            }
            else
            {
                _line.enabled = false;
                material.color = Color.red;
                _socket = null;
            }
        }
    }

    private void SetTargetPosition(Vector3 position)
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.rotation = Quaternion.Euler(Vector3.zero);
        _targetPosition = position;
    }

    public virtual void Translate(Vector3 translation)
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _targetPosition = transform.position + translation;
    }

    public override void Grab()
    {
        _rigidbody.useGravity = false;
        _isGrabbed = true;
    }

    public override void InteractWithRotation(float angle)
    {
        
    }

    public override void InteractWithPosition(Vector3 position)
    {
        SetTargetPosition(position);
    }

    public override void InteractWithVector(Vector3 vector)
    {
        Translate(vector);
    }

    public override void Drop()
    {
        _rigidbody.useGravity = true;
        _isGrabbed = false;
        if (_socket)
        {
            transform.position = _socket.transform.position;
        }
    }
}
