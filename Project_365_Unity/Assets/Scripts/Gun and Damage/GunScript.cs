using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    private Camera _camera;
    private ParticleSystem _particle;
    private LayerMask _shootableMask;


    void Start()
    {
        _camera = Camera.main;
        _particle = GetComponentInChildren<ParticleSystem>();
        _shootableMask = LayerMask.GetMask("Shootable");

    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range, _shootableMask))

        {

            print("hit " + hit.collider.gameObject);
           // Debug.Log(hit.transform.name);
            _particle.Play();

            TreeDamage target = hit.transform.GetComponent<TreeDamage>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

        }
    }
}





//if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
//{
//    Debug.Log(hit.transform.name);


        //}