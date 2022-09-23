using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private float weaponDamage;
    [SerializeField] private Transform weaponBarrel;
    [SerializeField] private LineRenderer lineRenderer;

    public void ShootLaser()
    {
        RaycastHit result;
        bool thereWasHit = Physics.Raycast(weaponBarrel.position, transform.forward, out result, Mathf.Infinity);

        lineRenderer.SetPosition(0, weaponBarrel.position);

        if (thereWasHit)
        {
            PlayerHealth playerHealth = result.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(weaponDamage);
            }

            lineRenderer.SetPosition(1, weaponBarrel.position + transform.forward * 50);
        }
    }
}
