using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(bobobo))]
public class Cohesion1 : MonoBehaviour
{
    private bobobo wizard;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        wizard = GetComponent<bobobo>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] neighbors = Physics.OverlapSphere(transform.position, radius);
        Vector3 average = Vector3.zero;
        int players = neighbors.Length;
        foreach (var neighbor in neighbors)
        {
            var temp = neighbor.transform.position - transform.position;
            average += temp;
            
        }
        average = average / players;
        wizard.velocity += Vector3.Lerp(Vector3.zero, average, average.magnitude / radius);
    }
}
