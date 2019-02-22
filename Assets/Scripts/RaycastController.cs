using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{

    public static RaycastController instance;
    public Transform gunFlashTarget;
    public float fireRate = 1.6f;
    private bool nextShot = true;
    private string objName = "";
    public GameObject birdAsset;
    public GameObject gunFlashPrefab;
    public GameObject boomPrefab;

    AudioSource audio;
    public AudioClip[] clips;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void playSound(int sound)
    {
        audio.clip = clips[sound];
        audio.Play();
    }


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(spawnNewBird());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if (nextShot)
        {
            StartCoroutine(takeShoot());
            nextShot = false;//すぐにショットできない
        }
    }

    private IEnumerator takeShoot()
    {
        GunScript.instance.fireSound();

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        int layer_mask = LayerMask.GetMask("birdLayer");//他のコライダーとrayが当たる可能性があるので、衝突物を制限する

        if (Physics.Raycast(ray,out hit, Mathf.Infinity, layer_mask))
        {
            objName = hit.collider.gameObject.name;

            Vector3 birdPosition = hit.collider.gameObject.transform.position;
            //if(objName == "Bird_Asset(Clone)")
            if (objName == "Bird_Asset(Clone)")
                {
                GameObject Boom = Instantiate(boomPrefab) as GameObject;
                Boom.transform.position = birdPosition;

                Destroy(hit.collider.gameObject);
                StartCoroutine(spawnNewBird());
            }
        }


        GameObject gunFlash = Instantiate(gunFlashPrefab) as GameObject;
        gunFlash.transform.position = gunFlashTarget.position;

        yield return new WaitForSeconds(fireRate);
        nextShot = true;//fireRate後にショットできる
    }

    private IEnumerator spawnNewBird()
    {
        yield return new WaitForSeconds(3f);

        GameObject newBird = Instantiate(birdAsset) as GameObject;
        newBird.transform.SetParent(GameObject.Find("ImageTarget").transform);

        //newBird.transform.localScale = new Vector3(10f,10f, 10f);
        newBird.transform.localScale = new Vector3(1f, 1f, 1f);

        Vector3 tmp;
        tmp.x = Random.Range(-48f, 48);
        tmp.y = Random.Range(10f, 50f);
        tmp.z = Random.Range(-48f, 48f);
        newBird.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

    }
}
