using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] obsticles;
    public int spawnSpeed = 10000;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }
    async Task Spawn()
    {
        while (true)
        {
            await Task.Delay(spawnSpeed);
            //spawn a random obsticle
            //get our y - 110
            int y = (int)transform.position.y - 110;
            while(!(y > -500 && y < 0)){
                await Task.Delay(10);
                y = (int)transform.position.y - 110;
            }
            int index = Random.Range(0, obsticles.Length);
            Instantiate(obsticles[index], new Vector3(0, y, 0), obsticles[index].transform.rotation);
        }
    }
}
