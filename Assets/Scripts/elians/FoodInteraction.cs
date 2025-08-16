using UnityEngine;
using TMPro;

public class FoodInteraction : MonoBehaviour
{
    public string requestedFood; // Pedido del NPC
    public GameObject orderUIPrefab; // Prefab UI flotante (TMP)
    private GameObject spawnedUI;

    private void Start()
    {
        // Crear el texto del pedido sobre el NPC
        if (orderUIPrefab != null)
        {
            spawnedUI = Instantiate(orderUIPrefab, transform.position + Vector3.up * 2, Quaternion.identity);
            spawnedUI.GetComponentInChildren<TextMeshProUGUI>().text = requestedFood;
            spawnedUI.transform.SetParent(transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.currentFood == requestedFood)
            {
                Debug.Log("Pedido entregado: " + requestedFood);
                inventory.currentFood = ""; // Limpia la mano del jugador
                Destroy(gameObject); // Elimina NPC
            }
        }
    }
}
