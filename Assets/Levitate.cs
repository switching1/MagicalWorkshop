using UnityEngine;

public class Levitate : MonoBehaviour
{
    public GameObject WandTip;
    public float LevitateMultiplier = 1.0f;
    private Vector3 LevitateForce;
    private Vector3 hitObjectPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if((gameObject.GetComponent(“YourDesiredScript”) as YourDesiredScript) != null)
        RaycastHit hit;
        Vector3 Direction = WandTip.transform.position - Camera.main.transform.position;
        if(Physics.Raycast(WandTip.transform.position, Direction, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(WandTip.transform.position, Direction * hit.distance, Color.yellow);
            CanFly cf = hit.collider.gameObject.GetComponent<CanFly>();
            if(cf != null)
            {
                Debug.Log("canfly");
                cf.DisableGravity();
                hitObjectPosition = hit.collider.gameObject.transform.position;
                Vector3 WandXY = new Vector3(WandTip.transform.position.x, WandTip.transform.position.y, hitObjectPosition.z);
                hit.collider.gameObject.transform.position = Vector3.Lerp(hitObjectPosition, WandXY, LevitateMultiplier * Time.deltaTime);
            }
        }
    }
}