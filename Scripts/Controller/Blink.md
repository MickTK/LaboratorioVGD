### Attributi
````
private IEnumerator coroutine;
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
    Vector3 v = gameObject.transform.localScale;
    for (int i = 0; i < blinks; i++)
    {
        gameObject.transform.localScale = new Vector3(0,0,0);
        yield return new WaitForSeconds(time);
        gameObject.transform.localScale = v;
        yield return new WaitForSeconds(time);
    }
    gameObject.transform.localScale = v;
    StopCoroutine(coroutine);
}
````
 