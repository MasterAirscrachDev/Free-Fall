using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Heart1, Heart2, Heart3;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHP(int hp){
        if(hp == 3){ Heart1.SetActive(true); Heart2.SetActive(true); Heart3.SetActive(true); }
        if(hp == 2){ Heart1.SetActive(true); Heart2.SetActive(true); Heart3.SetActive(false); }
        if(hp == 1){ Heart1.SetActive(true); Heart2.SetActive(false); Heart3.SetActive(false); }
        if(hp == 0){ Heart1.SetActive(false); Heart2.SetActive(false); Heart3.SetActive(false); }
    }
    public void GameOver(){
        //show game over text
        //show restart button
    }
    public void SetTimeAlive(float time){
        scoreText.text = time.ToString("0.0");
    }
}
