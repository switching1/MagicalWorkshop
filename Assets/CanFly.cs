using UnityEngine;

public class CanFly : MonoBehaviour
{
    private Rigidbody rb ;
    private float TimerGravity = 5.0f;
    private float currentTimerGravity = 0.0f;
    private bool GravityDisabled = false;
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
                rb.useGravity = true;
                GravityDisabled = false;
            }
        }
    }

    public void DisableGravity()
    {
        GravityDisabled = true;
        rb.useGravity = false;
        currentTimerGravity = 0.0f;
    }
}
