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
        //TODO: Se la fariabile followPlayer è true, il nemico seguirà il giocatore (Hint: FindWithTag può tornare utile). 
    
        animator.SetFloat("velocity", agent.velocity.magnitude);

    }

     void FixedUpdate() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1.5f)){

            //TODO: Se il raggio colpisce un oggetto con tag "Player" è necessario attivare il parametro "punch" dell'animator. Una volta impostato il parametro bisogna controllare se la distanza tra il player e il nemico
            //è minore di 1.5f. Se è minore si deve chiamare il metodo TakeDamage(1) dello script PlayerController.

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
        }
    }
}
