### Attributi
````
public Renderer rend;              // Mesh personaggio
private Material originalMaterial; // Materiale della mesh
public Material replaceMaterial;   // Materiale di rimpiazzo
private IEnumerator coroutine;     // Coroutine per il blink
````
### Inizializzazione
````
void Start()
{
    originalMaterial = rend.material;
}
````
### Trigger
````
coroutine = Blink(3, 0.2f);
StartCoroutine(coroutine);
````
### Metodo
````
private IEnumerator Blink(int blinks, float time)
{
    for (int i = 0; i < blinks; i++)
    {
        rend.material = replaceMaterial;
        yield return new WaitForSeconds(time);
        rend.material = originalMaterial;
        yield return new WaitForSeconds(time);
    }
    StopCoroutine(coroutine);
}
````
 