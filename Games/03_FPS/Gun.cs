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
    public Text ammoText; //prikaz koliko imamo metaka

    [Header("About weapon:")]
    public float fireRate; //Koliki je vremenski razmak između metaka
    float fireRateRestart;//Resetira pocetno vrijeme za fireRate
    public float accuracy;//Preciznost oružja u pikselima
    public float reloadTime;//Brzina mjenjanaj municije
    float reloadTimeReset;//Restart vremena mjenjanja municije
    public float recoil;// Trzaj - Ne koristimo DZ
    public Camera mainCamera; //Playerova FP camera
    public Camera scopeCamera;//Scope kamera

    [Header("Bullet info:")]
    public Rigidbody bulletPrefab;//Prefab metka kojeg puca ta puška
    public Transform bulletSpawnPosition;//Mjesto gdje se metak stvara (najčešće izlaz cijevi na oružju)
    AudioSource bulletSound;//Zvuk ispucaja - mora komponenta biti na oružju
    Bullet bulletScript;

    [Header("Fire Mode: *Single Fire mode is default*")]
    public bool singleFire = true;//Pucamo jedan metak po kliku - num 0
    public bool automaticFire;//Pucamo metke dok god držimo klik miša - num 1
    public bool burstFire;//Pucamo po 3 metka po kliku miša - num 2
    int fireMode = 0;// numerirana vrsta pucanja 

    private void Start()
    {
        currentAmmo = maxAmmo; //Postavljamo da na početku imamo maksimalni iznos metaka
        ShowAmmo();//Prikazuje na UI iznos metaka
        fireRateRestart = fireRate;//Postavljamo restart vrijednost za fireRate
        reloadTimeReset = reloadTime;//Postavljamo vrijednost za reload
        bulletSound = GetComponent<AudioSource>();//Dodjeljujemo komponentu audioSource
        bulletScript = bulletPrefab.gameObject.GetComponent<Bullet>(); //Uzmimamo pristup Bullet skripti preko prefaba

        if(singleFire == true)
        {
            fireMode = 0;
        }
        else if(automaticFire == true)
        {
            fireMode = 1;
        }
        else if(burstFire == true) //DZ
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

    //Metoda za prikaz municije
    public void ShowAmmo()
    {
        ammoText.text = currentAmmo + "/" + maxAmmo;
    }
}
