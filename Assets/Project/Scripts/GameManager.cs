using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject secondGame;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RunFinishLine(other.gameObject);
        }
    }
    
    private void RunFinishLine(GameObject player)
    {
        foreach (Transform child in player.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
