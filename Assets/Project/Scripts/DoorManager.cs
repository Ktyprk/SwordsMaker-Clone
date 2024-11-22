using System;
using TMPro;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public enum DoorType
    {
        DamageDoor,
        AttackDoor
    }

    public DoorType doorType; 
    public float statIncreaseAmount = 1; 
    public TMP_Text doorText; // Her kapıya özel bir TMP_Text atanmalı

    private float statMultiplier = 1f; // Kapıya özel bir çarpan
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        UpdateDoorText(); // Başlangıçta kapıdaki metni güncelle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            if (playerStats != null)
            {
                if (doorType == DoorType.DamageDoor)
                {
                    playerStats.damage *= statIncreaseAmount;
                    statMultiplier *= statIncreaseAmount;

                    UpdateDoorText(); // Kapının metnini güncelle
                    Destroy(other.gameObject);
                }
                else if (doorType == DoorType.AttackDoor)
                {
                    playerStats.attackSpeed *= statIncreaseAmount;
                    statMultiplier *= statIncreaseAmount;

                    UpdateDoorText(); // Kapının metnini güncelle
                    Destroy(other.gameObject);
                }
            }
        }
    }

    private void UpdateDoorText()
    {
        if (doorText != null)
        {
            doorText.text = "x" + statMultiplier.ToString("F2"); // Çarpan değerini metne yaz
        }
    }
}