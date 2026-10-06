using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpForce = 2f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkDistance = 0.3f;
    [SerializeField] private LayerMask _groundLayer;
  
    public bool isGround {  get; private set; }
    public bool isMove
    {
        get { return _playerInput.movement != 0; }
    
    }

    private PlayerInput _playerInput;

    [SerializeField] private SpriteRenderer _sr;
    [SerializeField ] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        if (_rb == null)
        {
            Debug.Log("Rigidbody2d не назначен в инспекторе");
            _rb = GetComponent<Rigidbody2D>();
        }
        if (_sr == null)
        {
            Debug.Log("SpriteRenderer не назначен в инспекторе");
            _sr = GetComponent<SpriteRenderer>();
        }

        if (_animator == null)
        {
            Debug.Log("Animator не назначен в инспекторе");
            _animator = GetComponent<Animator>();
        }
       
    }


    void Update()
    {
        

        _playerInput.Move();

        isGround = Physics2D.Raycast(_groundCheck.position, Vector2.down, _checkDistance, _groundLayer);
        
        if(_playerInput.movement > 0 )
        {
            _sr.flipX = true;
        }
        if(_playerInput.movement < 0 )
        {
            _sr.flipX = false;
        }

        _rb.linearVelocity = new Vector2(_playerInput.movement * _speed, _rb.linearVelocity.y);

        if(_playerInput.isJump && isGround)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        _animator.SetBool("isMove", isMove);
        _animator.SetBool("isGround", isGround);
        


    }
}
