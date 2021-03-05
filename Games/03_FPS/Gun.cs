using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
    [Header("Ammo:")]
    public int maxAmmo; //Iznos koliko na početku imamo municije
    int currentAmmo; //koliko imamo u trenutku municije
    public Text ammoText;

    [Header("About weapon:")]
    public float fireRate; //Koliki je vremenski razmak između metaka
    float fireRateRestart;
    public float accuracy;
    public float reloadTime;
    float reloadTimeReset;
    public float recoil;
    public Camera mainCamera;
    public Camera scopeCamera;

    [Header("Bullet info:")]
    public Rigidbody bulletPrefab;
    public Transform bulletSpawnPosition;
    AudioSource bulletSound;
    Bullet bulletScript;

    [Header("Fire Mode: *Single Fire mode is default*")]
    public bool singleFire = true;
    public bool automaticFire;
    public bool burstFire;
    int fireMode = 0;

    private void Start()
    {
        currentAmmo = maxAmmo;
        ShowAmmo();
        fireRateRestart = fireRate;
        reloadTimeReset = reloadTime;
        bulletSound = GetComponent<AudioSource>();
        bulletScript = bulletPrefab.gameObject.GetComponent<Bullet>();

        if(singleFire == true)
        {
            fireMode = 0;
        }
        else if(automaticFire == true)
        {
            fireMode = 1;
        }
        else if(burstFire == true)
        {
            fireMode = 2;
        }
        else
        {
            fireMode = 0;
        }
    }

    private void Update()
    {
        fireRate -= Time.deltaTime;
        reloadTime -= Time.deltaTime;

        //Pucanje za Single Fire Mode
        if(Input.GetMouseButtonDown(0) && fireMode == 0 && currentAmmo > 0 && fireRate <= 0)
        {
            Fire();
            fireRate = fireRateRestart;
        }
        //Pucanej za automatic
        if(Input.GetMouseButton(0) && fireMode == 1 && currentAmmo > 0 && fireRate <= 0)
        {
            Fire();
            fireRate = fireRateRestart;
        }
        //Burst fire dz

        //reload
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && reloadTime <= 0)
        {
            currentAmmo = maxAmmo;
            reloadTime = reloadTimeReset;
            ShowAmmo();
        }

        if(Input.GetMouseButton(1))
        {
            mainCamera.enabled = false;
            scopeCamera.enabled = true;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            mainCamera.enabled = true;
            scopeCamera.enabled = false;
        }
    }

    void Fire()
    {
        float x = Screen.width / 2;
        float y = Screen.height / 2;

        float xAcc = Random.Range(x - accuracy, x + accuracy);
        float yAcc = Random.Range(y - accuracy, y + accuracy);

        var ray = Camera.main.ScreenPointToRay(new Vector3(xAcc, yAcc, 0));

        Rigidbody cloneBullet;

        currentAmmo--;
        ShowAmmo();
        bulletSound.Play();
        cloneBullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        cloneBullet.velocity = bulletScript.speed * ray.direction;
    }

    public void ShowAmmo()
    {
        ammoText.text = currentAmmo + "/" + maxAmmo;
    }
}
