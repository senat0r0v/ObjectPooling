using UnityEngine;

public class CharacterController : MonoBehaviour 
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotSpeed = 80.0f;
    
    // cached variables
    private Transform _cachedTransform;
    private float _deltaTime;
    private bool _isEscapePressed;

    Rigidbody rb;
    
    private void Awake()
    {
        // caching transform when script runs
        _cachedTransform = transform;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {

        rb.MovePosition((_cachedTransform.forward * speed  * Input.GetAxis("Vertical") ) + _cachedTransform.position);
        rb.rotation *= Quaternion.Euler(0, (rotSpeed ) * Input.GetAxis("Horizontal"), 0);

        // assigning cached bool
        _isEscapePressed = Input.GetKeyDown(KeyCode.Escape);
        if (_isEscapePressed)
        {
            Cursor.lockState = CursorLockMode.None;
         }
        
    }
    
}