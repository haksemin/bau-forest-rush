using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterControler : MonoBehaviour
{

    #region Character Components
    [SerializeField]
    private const string object_name_character = "Character";
    [Header("Değişkenler")]
    public float kosmaHizi;
    public float forceSpeed;
    public float ziplamaAktifSure;
    public bool isRun = false;
    Animator characterAnimator;
    Rigidbody characterRigidbody;
    CapsuleCollider characterCapsuleCollider;
    #endregion

    #region Character AnimatorParameters
    #endregion

    #region Character Controlers
    private const string button_name_characterJump = "JumpButton";
    [SerializeField]
    private bool character_isGrounded = false;
    #endregion
    void Start()
    {
        characterAnimator = GameObject.Find(object_name_character).GetComponent<Animator>();
        characterRigidbody = GameObject.Find(object_name_character).GetComponent<Rigidbody>();
        characterCapsuleCollider = GameObject.Find(object_name_character).GetComponent<CapsuleCollider>();
        Debug.Log(object_name_character);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Jump!
        {
            jump();
        }
    }

    private void FixedUpdate()
    {
        if (isRun)
        {
            characterRigidbody.velocity = new Vector3(0, 0, 100f*Time.fixedDeltaTime* kosmaHizi);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Yere indin");
            characterAnimator.SetBool("isGrounded", true);
            characterAnimator.SetBool("Jumping", false);
            StartCoroutine(isGroundedBekle(ziplamaAktifSure));
        }
    }

    IEnumerator isGroundedBekle(float time)
    {
        yield return new WaitForSeconds(time);
        character_isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("yerden kesildin");
            character_isGrounded = false;
            characterAnimator.SetBool("isGrounded", false);
            characterAnimator.SetBool("Jumping", true);
        }
    }

    public void jump()
    {
        // 1.166923 1.446154
        if (character_isGrounded) // isGrounded
        {
            character_isGrounded = false;
            characterCapsuleCollider.center.Set(0, 1.052837f, 0);
            characterCapsuleCollider.height = 1.225306f;
            forceAdd();
            StartCoroutine(capsuleColliderBekle(.5f));
        }
    }

    IEnumerator capsuleColliderBekle(float time)
    {
        yield return new WaitForSeconds(time);
        characterCapsuleCollider.center.Set(0, 0.942413f, 0);
        characterCapsuleCollider.height = 1.895174f;
    }

    public void forceAdd()
    {
        characterRigidbody.AddForce(new Vector3(0, forceSpeed, 0), ForceMode.Force);
    }

    public void run()
    {
        characterAnimator.SetBool("Running", true);
        isRun = true;
    }

    public void de_run()
    {
        characterAnimator.SetBool("Running", false);
        characterRigidbody.velocity = new Vector3(0, 0, 0);
        isRun = false;
    }

}
