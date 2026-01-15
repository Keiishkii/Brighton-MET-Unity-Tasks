using System;
using UnityEngine;

public class TestEntity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.AddForce(Vector2.right * 5, ForceMode2D.Force);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.AddForce(Vector2.left * 5, ForceMode2D.Force);
        }
                
        Vector3 rayOrigin = transform.position + new Vector3(0, 0, 0);
        Vector3 rayDirection = new Vector3(0, -1f, 0);
        float distance = 1f;

LayerMask mask = LayerMask.GetMask("Floor");
RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, distance, mask);
        if (hit)
        {
            Debug.Log($"Name: {hit.collider.gameObject.name}");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        other.gameObject.tag = "Player";

        if (other.gameObject.tag == "Hazard")
        {
            
        }
        
        
        
        Debug.Log(other.gameObject.name);
        
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        transform.position = new Vector3(-3.25f, 1.25f, 0);
        rigidbody.linearVelocity = new Vector3(0, 0, 0);
    }

    public void OnDrawGizmos()
    {
        Vector3 rayOrigin = transform.position + new Vector3(0, 0, 0);
        Vector3 rayDirection = new Vector3(0, -1f, 0);
        float distance = 1f;
        
        Gizmos.DrawLine(rayOrigin, rayOrigin + rayDirection * distance);
    }
}
