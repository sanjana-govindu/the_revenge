#Gun control- This code makes the gun animate, sound and shoot the enemies. And it also increases the score on shooting an enemy by 5.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class guncontrol : MonoBehaviour
{
    public int score;
    public Animator gunAnimator;
    public AudioSource gunaudio;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(score==120)
        {
            Time.timeScale = 0;
        }
        RaycastHit raycastHit;
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Fire");
            if (!gunAnimator.isActiveAndEnabled)
            {
                gunAnimator.enabled = true;
            }
            if (!gunaudio.isPlaying)
            {
                gunaudio.Play();
            }
            particle.SetActive(true);
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 200))
            {
                if (raycastHit.collider.gameObject.tag == "enemy")
                {
                    Debug.Log("Hit Enemy");
                    score = score + 5;

                    Destroy((GameObject)raycastHit.collider.gameObject);
                }
                else
                {
                    Debug.Log("Not enemy");
                }
            }
        }
        else
        {
            if (gunAnimator.isActiveAndEnabled)
            {
                gunAnimator.enabled = false;
            }
            if (gunaudio.isPlaying)
            {
                gunaudio.Stop();
            }
            particle.SetActive(false);
        }
    }
}
