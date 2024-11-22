using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalspeed = 5f;    
    public float moveSpeed = 4f;   
    public float maxX = 5f; 
    public float stackDistance = 1f;
    
    private List<GameObject> collectedBoxes = new List<GameObject>();
    private int currentMachineId = 1;

    private void Update()
    {
        transform.Translate(Vector3.forward * verticalspeed * Time.deltaTime);
        
        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        
        float newXPosition = Mathf.Clamp(transform.position.x + horizontalInput, -maxX, maxX);
        
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            CollectBox(other.gameObject);
        }
    }
    
    private void CollectBox(GameObject box)
    {
        collectedBoxes.Add(box);
        
        Vector3 stackPosition = transform.position + Vector3.forward * stackDistance * collectedBoxes.Count;
        box.transform.position = stackPosition;
        
        box.transform.SetParent(transform);
    }
    
    public void RemoveBoxesFrom(GameObject startingBox)
    {
        int startIndex = collectedBoxes.IndexOf(startingBox);
        if (startIndex >= 0)
        {
            for (int i = startIndex; i < collectedBoxes.Count; i++)
            {
                collectedBoxes[i].transform.SetParent(null);
            }
            
            collectedBoxes.RemoveRange(startIndex, collectedBoxes.Count - startIndex);
        }
    }
    
    
    public IEnumerator TemporaryStopAndMoveBack()
    {
        float originalSpeed = verticalspeed; 
        verticalspeed = 0f; 
        
        Vector3 targetPosition = transform.position - Vector3.forward * 2f;
        float moveDuration = 0.2f;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        
        yield return new WaitForSeconds(0.2f);

        verticalspeed = originalSpeed;
    }
}
