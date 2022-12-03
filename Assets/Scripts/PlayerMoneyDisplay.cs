using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoneyDisplay : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<PlayerMoney>().ChangeMoneyTextReference(GetComponent<TextMeshProUGUI>());
    }
}
