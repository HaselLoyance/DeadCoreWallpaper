using UnityEngine;

public class sceneController : MonoBehaviour
{
    public float spawnEachS = 1.0f;
    public float spawnTopCloudEachS = 1.0f;
    public float spawnBottomCloudEachS = 1.0f;
    public float xSpawnRange = 5.0f;

    public GameObject cube;
    public GameObject cloud;

    float lastXSpawn = 0.0f;

    void Start ()
    {
        InvokeRepeating("SpawnCube", 0.0f, spawnEachS);
        InvokeRepeating("SpawnTopCloud", 0.0f, spawnTopCloudEachS);
        InvokeRepeating("SpawnBottomCloud", 0.0f, spawnBottomCloudEachS);
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void SpawnTopCloud()
    {
        GameObject cloudGo = Instantiate(cloud, new Vector3(6.0f, Random.Range(0.8f,1.8f), Random.Range(3.901f, 3.99f)), Quaternion.identity);
        cloudGo.GetComponent<Cloud>().Begin(Random.Range(-0.5f, -0.1f), Random.Range(5.0f, 7.0f), -6.0f);
    }

    void SpawnBottomCloud()
    {
        GameObject cloudGo = Instantiate(cloud, new Vector3(-6.0f, Random.Range(-2.5f, -1.55f), Random.Range(1.85f,3.7f)), Quaternion.identity);
        cloudGo.GetComponent<Cloud>().Begin(Random.Range(0.2f, 0.6f), Random.Range(5.0f, 7.0f), 6.0f);
    }

    void SpawnCube()
    {
        float xCoord = 0.0f;
        if (lastXSpawn >= 0.0f)
            xCoord = Random.Range(-xSpawnRange, lastXSpawn - 1.0f);
        else
            xCoord = Random.Range(lastXSpawn + 1.0f, xSpawnRange);

        lastXSpawn = xCoord;

        GameObject cubeGo = Instantiate(cube, new Vector3(xCoord, Random.Range(-2.0f, -1.65f), 1.0f), Quaternion.identity);
        cubeGo.GetComponent<Cube>().Begin(Random.Range(15.0f, 25.0f));
    }
}
