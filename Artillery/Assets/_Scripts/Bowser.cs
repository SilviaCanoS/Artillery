using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowser : BloqueSorpresa
{
    // Start is called before the first frame update
    void Start()
    {
        resistencia = 1000;
    }

    private void Update()
    {
        if (resistencia <= 500)
        {
            this.transform.localScale = new Vector3(12, 12.35f, 1);
            this.transform.position = new Vector3(0, -11.65f, 0);
        }
        if (resistencia <= 0) Destroy(this.gameObject);
    }
}
