#Enemy control- This code specifies the action of the enemy when the enemy approaches the player.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class enemycontrol : MonoBehaviour
{
    public float lookradius = 10f;
    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = playermanager.instance.player.transform;
        agent =GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position,transform.position);
        if(distance<=lookradius)
        {
            agent.SetDestination(target.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="player")
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("menu");
            SceneManager.UnloadScene("Main Scene");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color =Color.red;
        Gizmos.DrawWireSphere(transform.position,lookradius);
    }


}
