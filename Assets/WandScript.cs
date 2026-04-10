using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject Fireball;
    public GameObject WandTip;
    public float FireballSpeed;
    private Vector3 Force;
    private Vector3 Origin;
    private Vector3 Target;
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
        Vector3 point = new Vector3();
        Event   currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = Camera.main.pixelHeight - currentEvent.mousePosition.y;

        point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 2.0f));

        // GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        // GUILayout.Label("Screen pixels: " + Camera.main.pixelWidth + ":" + Camera.main.pixelHeight);
        // GUILayout.Label("Mouse position: " + mousePos);
        // GUILayout.Label("World position: " + point.ToString("F3"));
        // GUILayout.EndArea();
    
        Event e = Event.current;
        if (e.type == EventType.KeyDown & e.keyCode ==  KeyCode.E)
        {
            GameObject FireBallInstance = Instantiate(Fireball, WandTip.transform.position, Quaternion.identity);
            Rigidbody rb = FireBallInstance.GetComponent<Rigidbody>();
            Force = (WandTip.transform.position - Camera.main.transform.position) * FireballSpeed;
            Debug.Log(Force);
            rb.AddForce(Force, ForceMode.VelocityChange);
            Destroy(FireBallInstance, 5.0f);
        }
        Target = point;
    }
}
