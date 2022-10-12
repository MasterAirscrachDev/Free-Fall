using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    [SerializeField] Material mat;
    float hsv = 0;
    // Start is called before the first frame update
    void Start()
    {
        hsv = Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        mat.color = Color.HSVToRGB(hsv, 1, 1);
        hsv += Time.deltaTime / 50;
        if (hsv > 1)
        {
            hsv = 0;
        }
    }
}
