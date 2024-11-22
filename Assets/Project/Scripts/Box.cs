using UnityEngine;

public class Box : MonoBehaviour
{
    public int developmentPoints = 0; 

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Machine"))
        {
            Machine machine = other.GetComponent<Machine>();
            if (machine != null)
            { 
                CheckBoxesForMachine(machine);
            }
        }
        
        if (other.CompareTag("Obstacle"))
        {
            PlayerController playerController = GetComponentInParent<PlayerController>();
            if (playerController != null)
            {
                playerController.RemoveBoxesFrom(gameObject);
                StartCoroutine(playerController.TemporaryStopAndMoveBack());

            }
        }
    }
    
    private void CheckBoxesForMachine(Machine machine)
    {
        if (developmentPoints == machine.requiredDevelopmentPoints)
        {
            if ( machine.requiredDevelopmentPoints == 0 || machine.requiredDevelopmentPoints == 1 || machine.requiredDevelopmentPoints == 2)
            {
                GetComponent<Renderer>().material.color = machine.colorChange;
            }
            else if (machine.requiredDevelopmentPoints == 3)
            {
                GetComponent<Renderer>().material.color = machine.colorChange;
                Vector3 newScale = transform.localScale;
                newScale.y = 0.05f;
                transform.localScale = newScale;
            }
            else if (machine.requiredDevelopmentPoints == 4)
            {
                GetComponent<Renderer>().material.color = machine.colorChange;
                Vector3 newScale = transform.localScale;
                newScale.x = 0.05f;
                transform.localScale = newScale;
            }

            developmentPoints++; 
        }
    }

}