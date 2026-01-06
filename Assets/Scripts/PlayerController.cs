/*using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float RotationSpeed = 10f;
    [SerializeField] private float jumpForce = 8.5f;
    
    private Animator _animator;
    private Rigidbody _rigidbody;
    private GroundChecker _groundChecker;
    private float _currentRotationY = 0f;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    void HandleInput()
    {
        if (Input.GetButtonDown("Jump") && _groundChecker.isGround)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _animator.SetTrigger("Jump");
        }

        if (Input.GetButton("Fire1"))
        {
            _animator.SetInteger("Attack", 1);
        }
        else if (Input.GetButton("Fire2"))
        {
            _animator.SetInteger("Attack", 2);
        }
        else
        {
            _animator.SetInteger("Attack", 0);
        }
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        _currentRotationY = horizontal * RotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, _currentRotationY, 0);
        
        Vector3 direction = transform.forward * vertical * Speed;
        //direction.y = _rigidbody.linearVelocity.y;
        _rigidbody.linearVelocity = direction;
    }

    void HandleAnimation()
    {
        bool isGroundCheck = _groundChecker.isGround;
        _animator.SetBool("isGround", isGroundCheck);
        
        float horizontal = Mathf.Abs(Input.GetAxis("Horizontal"));
        float vertical = Mathf.Abs(Input.GetAxis("Vertical"));
        _animator.SetFloat("Speed", horizontal + vertical);
    }

    void Update()
    {
        HandleInput();
        HandleAnimation();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }
    
    
}
*/