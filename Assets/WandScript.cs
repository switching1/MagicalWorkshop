using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    public int handPointIndex = 8;
    public GameObject Fireball;
    public GameObject WandTip;
    public float FireballSpeed;
    private Vector3 Force;
    private Vector3 Origin;
    private Vector3 Target;
    private List<Vector3> handPointsArray = new List<Vector3>();
    public Vector3 OffsetWand;
    public AudioSource fireSound;    
    private float speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // string data = udpReceive.data;

        // data = data.Remove(0, 1);
        // data = data.Remove(data.Length-1, 1);
        // //print(data);
        // string[] points = data.Split(',');

        // float x = 7-float.Parse(points[handPointIndex * 3])/100;
        // float y = float.Parse(points[handPointIndex * 3 + 1]) / 100;
        // float z = float.Parse(points[handPointIndex * 3 + 2]) / 100;

        // for ( int i = 0; i<21; i++)
        // {

        //     float xx = 7-float.Parse(points[i * 3])/100;
        //     float yy = float.Parse(points[i * 3 + 1]) / 100;
        //     float zz = float.Parse(points[i * 3 + 2]) / 100;
        //     handPointsArray.Add(new Vector3(xx,yy,zz));

        // }
        // Vector3 difference_petitdoigt_poignet = new Vector3(
        //     handPointsArray[20].x - handPointsArray[0].x,
        //     handPointsArray[20].x - handPointsArray[0].x,
        //     handPointsArray[20].x - handPointsArray[0].x);

        // Vector3 difference_annuaire_poignet = new Vector3(
        //     handPointsArray[16].x - handPointsArray[0].x,
        //     handPointsArray[16].x - handPointsArray[0].x,
        //     handPointsArray[16].x - handPointsArray[0].x);

        //             Vector3 difference_majeur_poignet = new Vector3(
        //     handPointsArray[12].x - handPointsArray[0].x,
        //     handPointsArray[12].x - handPointsArray[0].x,
        //     handPointsArray[12].x - handPointsArray[0].x);

        //     Debug.Log("diff maj poignet" + difference_majeur_poignet);

        // Target = new Vector3(x, y, z) + OffsetWand;
        Debug.Log(Target);
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

   
        Event e = Event.current;
        if (e.type == EventType.KeyDown & e.keyCode ==  KeyCode.E)
        {
            fireSound.Play();
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
