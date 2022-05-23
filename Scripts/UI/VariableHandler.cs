using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableHandler : MonoBehaviour
{
    [SerializeField]
    //todo COMPLETA STA ROBA, BISUALIZZA LE ROBE
    public GameVariable gameVariable;
    public Text textVite;
    public Text textMonete;
    public Text textDoni;
    public Text textViteGrigie;
    public Text textPunteggio;
    public GameObject itemPrefab;
    public GridLayoutGroup slotTratti;
    public GridLayoutGroup slotShop;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textVite.text = gameVariable.vite.ToString();
        textMonete.text = gameVariable.monete.ToString();
        textDoni.text = gameVariable.doni.ToString();
        textViteGrigie.text = gameVariable.viteOro.ToString();
        textPunteggio.text = gameVariable.punteggio.ToString(); 

        foreach (Transform child in slotTratti.transform) 
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (var listTratti in gameVariable.Tratti.Active)
        {
            GameObject itemTile = Instantiate(itemPrefab);
            itemTile.transform.SetParent(slotTratti.transform);
            itemTile.GetComponent<ListTileUI>().SetValues(listTratti);
        }

        foreach (Transform child in slotShop.transform) 
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (var listItem in gameVariable.Shop.Active)
        {
            GameObject itemTile = Instantiate(itemPrefab);
            itemTile.transform.SetParent(slotShop.transform);
            itemTile.GetComponent<ListTileUI>().SetValues(listItem);
        }
    }
}
