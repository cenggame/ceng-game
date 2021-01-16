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

    public ParticleSystem muzzle;
    float nextFireTime = 0.17f;
    float cooldownTime = 0.17f;

    // Start is called before the first frame update
    void Start()
    {
        isMenuOpen = false;
        mAudioSrc = GetComponent<AudioSource>();
        muzzle = GetComponent<ParticleSystem>();
        maxAmmo = 30;
        currentAmmo = 30;
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
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < 30 && maxAmmo > 0 || (currentAmmo == 0 && maxAmmo!=0 ))
        {
            StartCoroutine(Reload());
            return;
        }
        if (isFiring)
        {
            if (currentAmmo > 0 && (isMenuOpen == false))
            {
                shot();
                muzzleShot();
            }
        }
        else
        {
            muzzle.Stop();
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

        if(maxAmmo >= 30)
        { 
        ammoDif = 30 - currentAmmo;
        currentAmmo += ammoDif;
        maxAmmo -= ammoDif;
        }
        else 
        {
                if(maxAmmo+currentAmmo <= 30 )
                {
                    currentAmmo = currentAmmo + maxAmmo;
                    maxAmmo = 0;
                }
                else
                {
                    ammoDif = 30 - currentAmmo;
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

    void muzzleShot()
    {
        if (Time.time > nextFireTime)
        {
            muzzle.Play();
            nextFireTime = Time.time + cooldownTime;
        }
        
    }
}