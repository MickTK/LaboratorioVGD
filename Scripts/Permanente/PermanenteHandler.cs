using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PermanenteHandler : MonoBehaviour
{

    public GameObject permanentiUI;
    public PermanenteDisplayer permanente1;
    public PermanenteDisplayer permanente2;
    public PermanenteDisplayer permanente3;
    GameVariable gameVariable;
    Deck<Permanente> deckPermanente = new Deck<Permanente>("Permanente/Object");

    void ClickOne(){
        permanentiUI.SetActive(false);
        gameVariable.PermanenteActive.DeckAccess.Add(permanente1.Permanente);
	}

    void ClickTwo(){
        permanentiUI.SetActive(false);
        gameVariable.PermanenteActive.DeckAccess.Add(permanente2.Permanente);
	}

    void ClickThree(){
        permanentiUI.SetActive(false);
        gameVariable.PermanenteActive.DeckAccess.Add(permanente3.Permanente);
	}

    void Start(){

        gameVariable = GetComponent<GameVariable>();

        Button btn1 = permanente1.GetComponent<Button>();
        btn1.onClick.AddListener(ClickOne);

        Button btn2 = permanente2.GetComponent<Button>();
        btn2.onClick.AddListener(ClickTwo);
                
        Button btn3 = permanente3.GetComponent<Button>();
        btn3.onClick.AddListener(ClickThree);

        permanentiUI.SetActive(false);
    }

    void Update(){

        if (Input.GetKeyDown("x"))
        {
            permanentiUI.SetActive(true);
            permanente1.Permanente = deckPermanente.Draw();
            permanente2.Permanente = deckPermanente.Draw();
            permanente3.Permanente = deckPermanente.Draw();
        }
    }
}
