
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
    private bool estaCorrendo = false;

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
    public void OnRun(InputValue value)
    {
        estaCorrendo = value.isPressed;
        Debug.Log("Esta correndo: " + estaCorrendo);
        animator.SetBool("Run" +  estaCorrendo, true);
    }

    private void Update()
    {
        bool emMovimento = inputMovimento.sqrMagnitude > 0.01f;
        animator.SetBool("iswalking", emMovimento);
    }
}

