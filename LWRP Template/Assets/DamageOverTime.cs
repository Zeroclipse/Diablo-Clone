using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public Material material;
    public float dps;
    public float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damage += dps * Time.deltaTime;
        material.SetFloat("Vector1_50FD39D0", damage);
    }
}
