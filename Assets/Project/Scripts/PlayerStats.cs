using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int moveSpeed = 5;
    public float attackSpeed = 5;
    public float damage = 3;
    public int health = 100;
    
    public int coins = 0;
    
    private float defaultAttackSpeed;
    private float defaultDamage;
    
    void Start()
    {
        StartGame();
    }
    
    void StartGame()
    {
        defaultAttackSpeed = attackSpeed;
        defaultDamage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ResetValues()
    {
        attackSpeed = defaultAttackSpeed;
        damage = defaultDamage;
    }
    
    
    
}
