using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth = 200;
    public int maxHealth = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer(int damageToGive) {
        currentHealth -= damageToGive;
        if (currentHealth <= 0) {
            gameObject.SetActive(false);
        }
    }
}
