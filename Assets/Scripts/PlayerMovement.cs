
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    //[Header("Controle De Velocidade")]
    //[SerializeField] private float speed = 5f;
    //[Header("Força De Pulo")]
    //[SerializeField] private float ForcaPulo = 5f;
    //private Rigidbody rb;
    //private float moveInput;
    //private float moveInputz;
    private Vector2 inputMovimento;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
    }

    // Recebe o movimento do New Input System
    public void OnMove(InputValue value)
    {
        inputMovimento = value.Get<Vector2>();
    }
    public void OnPunchLeft()
    {
        animator.SetTrigger("AtacarL");
    }
    public void OnPunchRight()
    {
        animator.SetTrigger("AtacarR");
    }
    //private void FixedUpdate()
    //{
    //    rb.linearVelocity = new Vector3(moveInput * speed, rb.linearVelocity.y);
    //    rb.linearVelocity = new Vector3(moveInputz * speed, rb.linearVelocity.y);
    //}


    private void Update()
    {
        bool emMovimento = inputMovimento.sqrMagnitude > 0.01f;
        animator.SetBool("iswalking", emMovimento);
    }
}

