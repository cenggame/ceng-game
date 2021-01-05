using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public bool isFiring;
    public BulletController bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    public float shotCounter;
    public Transform firePoint;
    private AudioSource mAudioSrc;
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Text ammoText;
    int ammoDif;
    public static bool isMenuOpen;

    public AudioSource[] sounds;
    public AudioSource soundFire;
    public AudioSource soundReload;

    // Start is called before the first frame update
    void Start()
    {
        isMenuOpen = false;
        mAudioSrc = GetComponent<AudioSource>();
        maxAmmo = 20;
        currentAmmo = 10;
        showAmmo();


        sounds = GetComponents<AudioSource>();
        soundFire = sounds[0];
        soundReload = sounds[1];
    }
    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0 && maxAmmo > 0 || ( Input.GetKeyDown(KeyCode.R) && currentAmmo < 10 ) )
        {
            StartCoroutine(Reload());
            return;
        }
        if (isFiring)
        {
            if (currentAmmo > 0 && (isMenuOpen == false))
            {
                shot();
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
    IEnumerator Reload()
    {
        soundReload.Play();
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
       
        if(maxAmmo!=0)
        { 

        if(maxAmmo >= 10)
        { 
        ammoDif = 10 - currentAmmo;
        currentAmmo += ammoDif;
        maxAmmo -= ammoDif;
        }
        else 
        {
                if(maxAmmo+currentAmmo <= 10 )
                {
                    currentAmmo = currentAmmo + maxAmmo;
                    maxAmmo = 0;
                }
                else
                {
                    ammoDif = 10 - currentAmmo;
                    currentAmmo += ammoDif;
                    maxAmmo -= ammoDif;
                }
        }
        }

        showAmmo();
        isReloading = false; 
    }
    public void showAmmo()
    {
        ammoText = GameObject.Find("Ammo").GetComponent<Text>();
        ammoText.text = currentAmmo + "/" + maxAmmo;
    }
    void shot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            if (currentAmmo > 0)
            {
                currentAmmo--;
            }
            showAmmo();
            shotCounter = timeBetweenShots;
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.speed = bulletSpeed;
            mAudioSrc.Play();
            soundFire.Play();
            

            Destroy(newBullet, 8f);
        }
    }
}