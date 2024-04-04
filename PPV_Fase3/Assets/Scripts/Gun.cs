using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float rotationSpeed = 150f; // Velocidad de rotaci�n del ca��n

    private bool rotating = true; // Indica si el ca��n est� rotando o no

    public Transform spawnPoint;

    public GameObject bullet;

    public float shotForce = 1500f;
    public float shotRate = 1f;

    private float shotRateTime = 0;

    void Update()
    {
        if (rotating)
        {
            // Rotar el ca��n continuamente
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // Detectar clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Detener la rotaci�n y disparar el proyectil
            StopRotation();
            Fire();
        }
    }

    void StopRotation()
    {
        rotating = false; // Detener la rotaci�n
        Invoke("ResumeRotation", 1f); // Reanudar la rotaci�n despu�s de un segundo
    }

    void ResumeRotation()
    {
        rotating = true; // Reanudar la rotaci�n
    }

    void Fire()
    {
        if (Time.time > shotRateTime)
        {
            GameObject newBullet;

            newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

            shotRateTime = Time.time + shotRate;

            Destroy(newBullet, 3);
        }
    }
}
