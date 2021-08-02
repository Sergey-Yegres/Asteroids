using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private int poolCount = 3;
    [SerializeField] private bool autoExpand = true;
    [SerializeField] private BulletController bullet;

    private bool reload = false;
    private int numberOfShots = 0;
    public float reloadTime;

    private PoolMono<BulletController> pool;

    public GameObject BulletSpawn;

    private void Start()
    {
        pool = new PoolMono<BulletController>(bullet, poolCount,transform);
        pool.autoExpand = autoExpand;
    }

    private void Update()
    {
        CheckShoot();
    }
    private void CreateBullet()
    {
        
        Vector3 spawnPosition = BulletSpawn.transform.position;
        var bullet = pool.GetFreeElement();
        bullet.transform.rotation = new Quaternion(0,0,0,0); 
        bullet.transform.position = spawnPosition;
    }
    private void CheckShoot()
    {

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !reload)
        {
            CreateBullet();
            numberOfShots++;
            if(numberOfShots >= 3)
            {
                reload = true;
                numberOfShots = 0;
                StartCoroutine(ShootCoroutine());
            }
        }
    }
    private IEnumerator ShootCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);
        reload = false;
        StopCoroutine(ShootCoroutine());
    }
}
