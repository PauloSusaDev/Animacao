
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private Vector2 inputMovimento;
    private Animator animator;
    private bool estaCorrendo = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

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
    }

    private void Update()
    {
        bool emMovimento = inputMovimento.sqrMagnitude > 0.01f;
        animator.SetBool("iswalking", emMovimento && !estaCorrendo);
        animator.SetBool("Run", emMovimento && estaCorrendo);

    }
}

