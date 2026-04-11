using UnityEngine;

public class CoussinScript : MonoBehaviour
{
    private Vector3 origin; 
    public float speed;
    public float amplitude;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        origin = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =new Vector3(origin.x, amplitude * Mathf.Sin(speed * Time.time) + origin.y, origin.z);
    }
}
