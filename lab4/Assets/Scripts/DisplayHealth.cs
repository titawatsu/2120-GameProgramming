using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    public void HealthUpdate(int playerLife) => healthText.text = $"Lives: {playerLife}";


}
