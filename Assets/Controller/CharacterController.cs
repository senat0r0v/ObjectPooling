using UnityEngine;

public class CharacterController : MonoBehaviour 
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotSpeed = 80.0f;
    
    // cached variables
    private Transform _cachedTransform;
    private float _deltaTime;
    private float _translation;
    private float _rotation;
    private bool _isEscapePressed;
    
    private void Awake()
    {
        // caching transform when script runs
        _cachedTransform = transform;
    }

    private void Update() 
    {
        // assigning cached deltaTime
        _deltaTime = Time.deltaTime;

        // assigning cached inputs 
        _translation = Input.GetAxis("Vertical") * speed * _deltaTime;
        _rotation = Input.GetAxis("Horizontal") * rotSpeed * _deltaTime;
        _cachedTransform.Translate(0, 0, _translation);
        _cachedTransform.Rotate(0, _rotation, 0);

        // assigning cached bool
        _isEscapePressed = Input.GetKeyDown(KeyCode.Escape);
        if (_isEscapePressed)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
}