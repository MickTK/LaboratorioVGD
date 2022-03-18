# Modelli
## Animazioni Fiery e Cyclopes
### Parametri
- "speed" (float)
    - (-∞, 0.01] -> Idle
    - (0.01, 6] -> Walk
    - (6, +∞) -> Run
- "jump" (trigger)
- "damage" (trigger) (solo in Idle)
- "die" (boolean)
    - true -> Die
    - false -> Idle
### Snippet
````
private Animator animator;
void Start()
{
    animator = GetComponent<Animator>();
}
void Update()
{
    animator.SetFloat("speed", 0.3f);

    animator.SetBool("die", false);

    animator.SetTrigger("jump");
    animator.ResetTrigger("jump");

    animator.SetTrigger("damage");
    animator.ResetTrigger("damage");
}
````