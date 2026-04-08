using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Vector3 Origin;
    private Vector3 Target;
    private float range = 0.0f;
    private float speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target, speed * Time.deltaTime);
    }

    void OnGUI()
    {
        range = range + Time.deltaTime;

        if (range > 0.1f)
        {
            Event e = Event.current;
            Debug.Log(e.mousePosition);
            range = 0.0f;
            Vector3 ToAdd = new Vector3(e.mousePosition.x * 0.01f, -e.mousePosition.y * 0.01f, 0);
            Target = Origin + ToAdd;
        }
    }
}
