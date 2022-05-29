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
    public Text textViteOro;
    public GameObject itemPrefab;
    public GridLayoutGroup slotTratti;
    public GridLayoutGroup slotShop;

    void Start()
    {
        InvokeRepeating("UpdateUI", 0, 1.0f);
    }

    // Update is called once per frame
    void UpdateUI()
    {
        textVite.text = gameVariable.vite.ToString();
        textMonete.text = gameVariable.monete.ToString();
        textDoni.text = gameVariable.doni.ToString();
        textViteOro.text = gameVariable.viteOro.ToString();

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
