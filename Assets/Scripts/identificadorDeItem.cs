using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class identificadorDeItem : MonoBehaviour
{
    
    private bool item = false;

    public TextMeshProUGUI textoItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
                textoItem.enabled = false;
        textoItem = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int layer = LayerMask.GetMask("Ignore Raycast");
        Vector2 posicaoMouse = Mouse.current.position.ReadValue();
        Ray raio = Camera.main.ScreenPointToRay(posicaoMouse);
        if (Physics.Raycast(raio, out RaycastHit hit, 50, ~layer))
        {
            if (hit.collider.CompareTag("Item") && item)
            {
                textoItem.enabled = true;
                Debug.Log("item");
                Debug.Log("numero do ayer: " + layer);
                //textoItem.text = "Item: " + hit.collider.name;
            }

            if (!hit.collider.CompareTag("Item") && item)
            {
                textoItem.enabled = false;
            }
            Debug.DrawLine(raio.origin, hit.point, Color.red, 1f);

        }
    }
}
