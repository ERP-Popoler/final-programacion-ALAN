using UnityEngine;
using TMPro;

public class OrderUIManager : MonoBehaviour
{
    public TextMeshProUGUI orderText;

    public void ShowOrder(string food)
    {
        orderText.text = "Pedido: " + food;
    }

    public void ClearOrder()
    {
        orderText.text = "";
    }
}
