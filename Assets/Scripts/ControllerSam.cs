using System;
using UnityEngine;


public class ControllerSam : MonoBehaviour, IPlayer
{
    public event Action OnKilled;
   
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private KeyCode _jumpButton;
    [SerializeField] private SpriteRenderer _spriteSam;
    [SerializeField] private float _dampingSpeed;
    
    
    public void MakeDamage()
    {
        _rb.AddForce(Vector2.up * _jumpForce);
        GetComponent<Collider2D>().isTrigger = true;
        OnKilled?.Invoke();
        enabled = false;     
    }
    void Update()
    {
        CharacterMovement();
    }
 
    private void CharacterMovement()
    {
        float inputDir = Input.GetAxis("Horizontal");

        _spriteSam.flipX = inputDir < 0;

        _animator.SetFloat("MoveSpeed", Mathf.Abs(inputDir));


        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + inputDir, transform.position.y, 0), Time.deltaTime * _moveSpeed);

        if (Input.GetKeyDown(_jumpButton))
        {
            _rb.AddForce(Vector2.up * _jumpForce);
        }
    }
  
}


