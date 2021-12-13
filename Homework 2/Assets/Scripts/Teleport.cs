using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{
    public Transform teleportEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Vector3 endPos = new Vector3(teleportEnd.position.x, 1.5f, teleportEnd.position.z);
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = endPos;
            other.gameObject.GetComponent<CharacterController>().enabled = true;
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            if(enemy != null) {
                enemy.GetComponent<NavMeshAgent>().SetDestination(transform.position);
                enemy.GetComponent<EnemyController>().ToggleFollowPlayer();
            }
            

        }
        else if(other.gameObject.tag == "Enemy") {
            //TODO: Teletrasportare il nemico nella posizione "endPos" utilizzando il metodo appropriato dell NavMeshAgent. Infine chiamare il metodo ToggleFollowPlayer() dell' EnemyController.
            NavMeshAgent agent = /*Recuperare il NavMeshAgent*/;
                        
        }
    }
}
