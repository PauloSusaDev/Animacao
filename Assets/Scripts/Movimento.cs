using UnityEngine;
using UnityEngine.InputSystem;

public class Movimento : MonoBehaviour
{
    private Vector2 inputMovimento;
    private Vector3 movimento;
    private CharacterController character;
    [SerializeField] private float velocidade = 5f;
    void Start()
    {
        character = GetComponent<CharacterController>();
    }
    public void OnMove (InputValue value)
    {
        inputMovimento = value.Get<Vector2>();
        Debug.Log("tecla pressionada: " + inputMovimento);
    }
    void Update()
    {
        movimento.Set(inputMovimento.x, 0, inputMovimento.y);
        character.Move(movimento * Time.deltaTime * velocidade);

        transform.forward = Vector3.Lerp(transform.forward, movimento, Time.deltaTime * 10f);
    }
}
