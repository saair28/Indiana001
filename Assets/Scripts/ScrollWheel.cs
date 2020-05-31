using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWheel : MonoBehaviour
{
    public GameObject Weapons1;

    public GameObject Weapons2;

    public GameObject Weapons3;


   /* // Start is called before the first frame update
    void Start()
    {
        var Weapons : GameObject[];

        var CurrentWeapon : GameObject;

        var WeaponNumber = 0;

        CurrentWeapon = Weapons[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel"))
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                WeaponNumber = (WeaponNumber + 1);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                WeaponNumber = (WeaponNumber - 1);
            }
        }

        CurrentWeapon = Weapons[WeaponNumber];
    }*/
}
