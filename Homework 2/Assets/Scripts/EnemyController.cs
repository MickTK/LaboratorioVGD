using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    private int life = 3;
    private bool followPlayer = true;
    private NavMeshAgent agent;
    public TextMeshProUGUI lifeText;
    private Transform player;
    

    private Animator animator;
    private float velocity;
    // Start is called before the first frame update
    void Start()
    {
        lifeText.SetText(life.ToString());
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Se la variabile followPlayer è true, il nemico seguirà il giocatore (Hint: FindWithTag può tornare utile). 
        player = GameObject.Find("Player").transform;       
        if (followPlayer)
        {
            agent.SetDestination(player.position);
        }
        
        animator.SetFloat("velocity", agent.velocity.magnitude);

    }

     void FixedUpdate() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1.5f)){

            //TODO: Se il raggio colpisce un oggetto con tag "Player" è necessario attivare il parametro "punch" dell'animator. Una volta impostato il parametro bisogna controllare se la distanza tra il player e il nemico
            //è minore di 1.5f. Se è minore si deve chiamare il metodo TakeDamage(1) dello script PlayerController.
            float distance = Vector3.Distance(GameObject.Find("Player").transform.position, this.transform.position);
            if (distance <= 1.5f)
            {
                animator.SetBool("punch", true);
                GameObject.Find("Player").GetComponent<PlayerController>().TakeDamage(1);

            }
            
        }
        
    }

    public void ToggleFollowPlayer(){
        followPlayer = !followPlayer;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        lifeText.SetText(life.ToString());
        if (life <= 0)
        {
            //TODO: Distruggere il nemico e chiamare il metodo Activate() dello script Goal che è un componento dell' oggetto Goal (Hint: il metodo Find di GAmeObject può tornare utile).

            Destroy(GameObject.Find("Enemy"));
            GameObject.Find("Goal").GetComponent<Goal>().Activate();

        }
    }
}
