using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _rotationSpeed = 5f;

    private Rigidbody _rigidBody;
    private Vector3 _movementInput;
    private Vector3 _orientationInput;

    private const string HORIZONTAL_INPUT_NAME = "Horizontal";
    private const string VERTICAL_INPUT_NAME = "Vertical";
    private const string ORIENTATION_HORIZONTAL_NAME = "HorizontalOrientation";
    private const string ORIENTATION_VERTICAL_NAME = "VerticalOrientation";

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _movementInput.x = Input.GetAxisRaw(HORIZONTAL_INPUT_NAME);
        _movementInput.y = 0f;
        _movementInput.z = Input.GetAxisRaw(VERTICAL_INPUT_NAME);
        _orientationInput.x = Input.GetAxis(ORIENTATION_HORIZONTAL_NAME);
        _orientationInput.y = 0f;
        _orientationInput.z = Input.GetAxis(ORIENTATION_VERTICAL_NAME);

        if (_orientationInput.sqrMagnitude > 0f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_orientationInput);
            Quaternion lookRotation = Quaternion.Lerp(_rigidBody.rotation, targetRotation, Time.fixedDeltaTime * _rotationSpeed);
            _rigidBody.MoveRotation(lookRotation);
        }
    }

    private void LateUpdate()
    {

    }

    private void FixedUpdate()
    {
        Vector3 _clampedPlayerInput = Vector3.ClampMagnitude(_movementInput, 1f);
        _rigidBody.velocity = _clampedPlayerInput * _speed;
    }
}
