using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public float totalStamina;
    public float stamina;
    public StaminaBar staminaBar;
    private PlayerController player;
    void Start()
    {
        stamina = totalStamina;
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            player.isRunning = true;
            stamina -= 0.05f;
            staminaBar.SetStamina(stamina);
        }
        else
        {
            player.isRunning = false;
        }
        if (stamina < 100 && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += 0.05f;
            staminaBar.SetStamina(stamina);
        }
    }
}
