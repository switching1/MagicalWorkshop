using UnityEngine;

public class Levitate : MonoBehaviour
{
    public GameObject WandTip;
    public GameObject LevitateParticleSystem;
    public AudioSource levitateSound; 
    public float levitateCooldown = 0.3f;
    private float levitateTime = 0.0f;
    private bool leviateParticlePossible = true;
    private Vector3 LevitateForce;
    private Vector3 hitObjectPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levitateTime += Time.deltaTime;
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
                Vector3 WandXY = new Vector3(hit.point.x, hit.point.y + 0.5f, hitObjectPosition.z);
                cf.TriggerAttraction(WandXY);
                levitateSound.Play();
                // if(levitateTime > levitateCooldown)
                // {
                
                // GameObject LevitateParticleSystemInstance = Instantiate(LevitateParticleSystem, WandTip.transform.position, Quaternion.identity);
                // Vector3 randomOffset = new Vector3(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1));
                // LevitateParticleSystemInstance.GetComponent<LevitateParticleSystem>().EndPosition = hit.point + randomOffset * 0.5F;
                // levitateTime = 0.0f;
                // }
            }
        }
    }
}