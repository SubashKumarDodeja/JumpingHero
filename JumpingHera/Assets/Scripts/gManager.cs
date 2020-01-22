using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gManager : MonoBehaviour
{

    public static gManager instance;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject platform;

    private float minX=-2.5f,maxX=2.5f,minY=-4f,maxY=3f;
    private bool lerpCamera;
    private float lertTime = 1.5f, lerpX;
    void Awake()
    {
        MakeInstance();
        
        CreateInitialPlatforms();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    void CreateInitialPlatforms()
    {
        Vector3 temp = new Vector3 (Random.Range(minX, minX + 1.2f), Random.Range(minY, minY+2f),0);
        Instantiate(platform, temp, Quaternion.identity);
        temp.y += 2f;
        Instantiate(player, temp, Quaternion.identity);
        temp = new Vector3(Random.Range(maxX, maxX - 1.2f), Random.Range(minY, minY + 2f), 0);
        Instantiate(platform, temp, Quaternion.identity);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lerpCamera)
        {
            lerpThecamera();
        }
    }
    void lerpThecamera()
    {
        float x = Camera.main.transform.position.x;
        x = Mathf.Lerp(x, lerpX, lertTime * Time.deltaTime);
        Camera.main.transform.position = new Vector3(x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        if(Camera.main.transform.position.x>=(lerpX-0.07f))
        {
            lerpCamera = false;
        }
    }
    public void lerpAndPlatform(float lerpPositon)
    {
        createNewPlatform();
        lerpX = lerpPositon + maxX;
        lerpCamera = true;

    }
    void createNewPlatform()
    {
        float camerX = Camera.main.transform.position.x;
        float newMaxX = (maxX * 2) + camerX;
        Instantiate(platform, new Vector3(Random.Range(newMaxX,newMaxX+1.2f),Random.Range(minY, minY + 2f),0), Quaternion.identity);
    }
}
