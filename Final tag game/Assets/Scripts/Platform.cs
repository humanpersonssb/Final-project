using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] float speed = 1f;
    [SerializeField] [Range(0, 100)] float range = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yPos = (Mathf.PingPong(Time.time * speed, 1) * range) - 1;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
