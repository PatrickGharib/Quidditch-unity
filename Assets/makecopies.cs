using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makecopies : MonoBehaviour
{
    public GameObject x;
     // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++) {
            Instantiate(x, new Vector3 (i,0,0), Quaternion.identity);

        };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
