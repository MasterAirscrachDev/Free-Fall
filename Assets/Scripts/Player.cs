using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    Rigidbody RB;
    [SerializeField] Vector3 velocity;
    bool counterUnlocked = true, iFrames = false;
    [SerializeField] float movespeed = 10f, timeAlive, maxYSpeed = 10f;
    int hp = 3;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<UIManager>().SetHP(hp);
        RB = GetComponent<Rigidbody>();
        Timer();
    }

    // Update is called once per frame
    void Update()
    {
        //if y is below -500 set it to 100
        if (transform.position.y < -500)
        {
            transform.position = new Vector3(transform.position.x, 100, transform.position.z);
        }
        velocity = RB.velocity;
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input *= movespeed;
        input.y = RB.velocity.y;
        input.y = Mathf.Clamp(input.y, -maxYSpeed, 0);
        RB.velocity = input;
    }
    bool IsApproximately(float a, float b, float tolerance)
    {
        return Mathf.Abs(a - b) < tolerance;
    }
    async Task Timer()
    {
        while (hp > 0 || (velocity.y < -1 || timeAlive < 0.5f))
        {
            await Task.Delay(100);
            timeAlive += 0.1f;
            if(counterUnlocked){
                GetComponent<Spawner>().spawnSpeed--;
                //if spawnSpeed is a multiple of 1000
                if(GetComponent<Spawner>().spawnSpeed % 200 == 0){
                    counterUnlocked = false;
                    Restartcounter();
                }
            }
            
            //if timeAlive is a multiple of 10 then add 1 to maxYSpeed
            //round timeAlive to 1 decimal place
            timeAlive = Mathf.Round(timeAlive * 10) / 10;
            if (timeAlive % 10 == 0)
            {
                maxYSpeed += 1;
            }
            FindObjectOfType<UIManager>().SetTimeAlive(timeAlive);
        }
    }
    async Task Restartcounter(){
        await Task.Delay(GetComponent<Spawner>().spawnSpeed);
        if(GetComponent<Spawner>().spawnSpeed > 500){
            counterUnlocked = true;
        }
    }
    async Task ClearIFrames()
    {
        await Task.Delay(1000);
        iFrames = false;
    }

    void OnCollisionEnter(){
        if(!iFrames){
            hp--;
            iFrames = true;
            ClearIFrames();
            FindObjectOfType<UIManager>().SetHP(hp);
            if(hp == 0){
                FindObjectOfType<UIManager>().GameOver();
                RB.constraints = RigidbodyConstraints.None;
            }
        }
    }
}
