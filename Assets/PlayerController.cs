using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float deceleration = 2f;
    public Animator animator;

    private Vector3 movement;
    private Vector3 currentVelocity;
    private bool isRange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");


        movement = new Vector3(horizontalInput, 0f, verticalInput);

        if (movement != Vector3.zero)
        {
            currentVelocity = Vector3.Lerp(currentVelocity, movement * speed, deceleration * Time.deltaTime);
            animator.SetBool("isRun", true);
        }

        else
        {
            currentVelocity = Vector3.Lerp(currentVelocity, Vector3.zero, deceleration * Time.deltaTime);
            animator.SetBool("isRun", false);

        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("hit");
            Debug.Log("hit");
        }
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("melee1") && stateInfo.normalizedTime >= 1f)
        {
            animator.ResetTrigger("hit");
        }

        if (Input.GetMouseButtonDown(1)) // ตรวจสอบว่าคลิกขวาหรือไม่
        {
            isRange = !isRange; // สลับค่า isRange
            animator.SetBool("isRange", isRange); //  ตั้งค่า isRange ใน Animator
        }
        transform.Translate(currentVelocity * Time.deltaTime);
    }
}
