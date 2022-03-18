using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanenteEffects : MonoBehaviour
{
    GameVariable gameVariable;

    void Start(){
        gameVariable = GetComponent<GameVariable>();
    }

    void Update(){

        foreach (Permanente permanente in gameVariable.PermanenteActive.DeckAccess)
        {
            if(permanente.activable){
                
                switch (permanente.tipo)
                {
                    case PermType.RAMPA:
                    Rampa();
                    permanente.activable = false;
                    break;
                }
            }
        }
    }

    private IEnumerator coroutineRampa;
    private void Rampa(){
        coroutineRampa = RampaFunc(5.0f);
        StartCoroutine(coroutineRampa);
    }
    private IEnumerator RampaFunc(float waitTime)
    {
        GameObject rampa = Resources.Load<GameObject>("Prefab/Rampa");
        
        while (true)
        {
            Vector3 rampaPos = gameVariable.player.position;
            rampaPos.z += 20;
            Quaternion rampaRotation = Quaternion.identity;
            rampaRotation.x += 20;
            Instantiate(rampa,rampaPos, rampaRotation);

            yield return new WaitForSeconds(waitTime);
        }
    }


}
