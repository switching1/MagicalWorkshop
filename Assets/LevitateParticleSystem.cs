using UnityEngine;

public class LevitateParticleSystem : MonoBehaviour
{
    public Vector3 EndPosition; 
    public float speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, EndPosition, speed * Time.deltaTime);
        if(Mathf.Abs((transform.position-EndPosition).magnitude) <= 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
