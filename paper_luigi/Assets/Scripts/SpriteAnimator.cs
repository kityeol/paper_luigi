using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour
{
    public List<Sprite> runningSprites;
    public Sprite swimSprite;
    public Sprite jumpSprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private int index = 0;
    private PlayerMovement playerMov;
    public float maxTimer;
    private float timer;

    void Start()
    {
        playerMov = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = maxTimer;
    }

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (playerMov != null)
        {
            CharacterController controller = GetComponent<CharacterController>();
            if (Mathf.Abs(controller.velocity.x) < 0.3f && Mathf.Abs(controller.velocity.y) <= 0.3f)
            {
                spriteRenderer.sprite = runningSprites[0];
            }

            if (controller.isGrounded && (controller.velocity.x > 0 || controller.velocity.z > 0))
            {
                spriteRenderer.flipX = false;
                spriteRenderer.sprite = runningSprites[index];
                if (timer < 0)
                {
                    index++;
                    timer = maxTimer;
                }
                if (index == runningSprites.Count)
                {
                    index = 0;
                }
            }

            if (controller.isGrounded && (controller.velocity.x < 0 || controller.velocity.z < 0))
            {
                spriteRenderer.flipX = true;
                spriteRenderer.sprite = runningSprites[index];
                if (timer < 0)
                {
                    index++;
                    timer = maxTimer;
                }
                if (index == runningSprites.Count)
                {
                    index = 0;
                }
            }

            if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                spriteRenderer.sprite = jumpSprite;
            }
        }

    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Water")
        {
            spriteRenderer.sprite = swimSprite;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.tag == "Water")
    //    {
    //        spriteRenderer.sprite = swimSprite;
    //    }
    //}
}