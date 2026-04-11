using UnityEngine;

public class CanFly : MonoBehaviour
{
    private Rigidbody rb ;
    private float TimerGravity = 2.0f;
    private float currentTimerGravity = 0.0f;
    private float TimerAttraction = 1.0f;
    private float currentTimerAttraction = 0.0f;
    private bool GravityDisabled = false;
    private bool AttractionTriggered = false;
    private float AttractionSpeed = 1.0f;

    private Vector3 TargetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GravityDisabled == true)
        {
            currentTimerGravity += Time.deltaTime;
            if(currentTimerGravity >= TimerGravity)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                rb.useGravity = true;
                GravityDisabled = false;
            }
        }
        if(AttractionTriggered == true)
        {
            currentTimerAttraction += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, TargetPosition, AttractionSpeed * Time.deltaTime);
            if(currentTimerAttraction >= TimerAttraction)
            {
                AttractionTriggered = false;
            }
        }
    }

    public void DisableGravity()
    {
        GravityDisabled = true;
        rb.useGravity = false;
        currentTimerGravity = 0.0f;
    }

    public void TriggerAttraction(Vector3 TargetPos)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        AttractionTriggered = true;
        currentTimerAttraction = 0.0f;
        TargetPosition = TargetPos;
    }
}