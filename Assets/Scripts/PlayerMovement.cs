using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    Vector2 movement;
    [SerializeField] float xClampRange = 10f;
    [SerializeField] float yClampRange = 10f;
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       

    }

     //Update is called once per frame
    void Update()
    {  ProcessTranslation();             
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();

    }
    private void ProcessTranslation()
    {

        
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXpos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawXpos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYpos = transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(rawYpos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
    
}
