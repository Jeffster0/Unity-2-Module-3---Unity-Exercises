using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireProjectile : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletActiveTime = 3;
    public float bulletPower = 10;

    public GameObject firepoint;

    public float maxAmmo = 20;
    public TextMeshProUGUI ammoText;
    public float reloadTime = 3f;

    private float ammoCount;

    void Start()
    {
        ammoCount = maxAmmo;
        ammoText.text = $"Ammo: {ammoCount}";
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && ammoCount > 0)
        {
            // ADD CODE HERE
            GameObject bullet = Instantiate(bulletPrefab);
            Destroy(bullet, bulletActiveTime);
            FireBullet(bullet.GetComponent<BulletScript>());
            ammoCount--;
            // END OF CODE
            ammoText.text = $"Ammo: {ammoCount}";
        }

        if(ammoCount == 0)
        {
            StartCoroutine(Reloading());
        }
    }

    private void FireBullet(BulletScript bullet)
    {
        bullet.transform.position = firepoint.transform.position;
        bullet.FireBullet(this.transform.forward, bulletPower);
    }

    public IEnumerator Reloading()
    {
        ammoText.text = "Reloading...";
        yield return new WaitForSeconds(reloadTime);
        ammoCount = maxAmmo;
        ammoText.text = "Ammo: " + ammoCount.ToString();
    }
}
