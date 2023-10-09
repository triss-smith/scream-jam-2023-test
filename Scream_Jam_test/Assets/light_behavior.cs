using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class light_behavior : MonoBehaviour
{
    [SerializeField] float flashlightRange = 4.5f;
    [SerializeField] float flashlightBrightRange = 10f;
    [SerializeField] float flashlightInnerAngle = 40;
    [SerializeField] float flashlightOuterAngle = 70;

    [SerializeField] float raycastDistance = 20f;
    
    float FlashlightBattery = 100f;
    bool FlashLightBurning = false;
    
    //Animator myAnimator;

    Light2D flashlight;

    void Start()
    {
        flashlight = GetComponent<Light2D>();
        flashlight.pointLightInnerAngle = flashlightInnerAngle;
        flashlight.pointLightOuterAngle = flashlightOuterAngle;
        //myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // set the Radius of the flashlight
        FlashLightOn();
        
    }

    void FlashLightOn()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && FlashlightBattery > 0)
        {
            Debug.Log("fire");
            FlashLightBurning = true;
            flashlight.pointLightOuterRadius = flashlightBrightRange;
            //RayCast();
        } 

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("stop fire");
            FlashLightBurning = false;
        }

        if (FlashLightBurning) {
            StartCoroutine(DepleteFlashlight());

        } else {
            StopCoroutine(DepleteFlashlight());
            flashlight.pointLightOuterRadius = flashlightRange;
        }
    }

    IEnumerator DepleteFlashlight()
        {
            while (FlashLightBurning && FlashlightBattery > 0)
            {
                FlashlightBattery -= 0.5f;
                if (flashlightRange > 2.0) {
                    flashlightRange -= 0.01f;
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    
    /*void RayCast()
    {

        Vector2 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        Vector2 shot = screenPos - playerPos;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, shot, raycastDistance);
        if (hit.collider != null)
        {
            myAnimator.SetBool("isDamaged", true);
            Debug.Log(hit.collider.name);
        } else
        {
            myAnimator.SetBool("isDamaged", false);
        }

        Debug.DrawRay(transform.position, shot, Color.red);
    }*/
}
