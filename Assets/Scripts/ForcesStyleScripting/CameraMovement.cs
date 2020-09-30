using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private IEnumerator coroutine; 
    public Transform Snitch;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = CameraFollow(0.0001f);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 Snitchpos = Snitch.position;
        //Vector3 fixedPos = new Vector3(Snitchpos.x, -Snitchpos.y, Snitchpos.z);
        //LeanTween.rotate(this.gameObject, Quaternion.LookRotation(fixedPos).eulerAngles, .01f);
        
      


    }
    private IEnumerator CameraFollow(float updateTime)
    {
        while (true) {
            // taken from https://forum.unity.com/threads/smooth-look-at.26141/
            var targetRotation = Quaternion.LookRotation(Snitch.transform.position - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            yield return new WaitForSeconds(updateTime);
        }
        
    }
}
