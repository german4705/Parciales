using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponContext : MonoBehaviour
{
    private IWeapon currentWeapon;
    private List<IWeapon> weapons;
    private int currentWeaponIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<IWeapon>
        {
            new Pistol(),
            new Shotgun(),
            new Rifle()
        };

        currentWeapon = weapons[currentWeaponIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeapon();
        }
    }

    private void ChangeWeapon()
    {
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count; // me devuelve el resto de la division osea 0. cuando llega al indice 3 , lo va a dividir por 3 y el resto es 0 , vuelve al inicio de la lista.

        currentWeapon = weapons[currentWeaponIndex];
        Debug.Log("Weapon changed to: " + currentWeapon.GetType().Name);
    }
}
