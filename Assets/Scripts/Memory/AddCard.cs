using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCard : MonoBehaviour
{
    [SerializeField] Transform playField;
    [SerializeField] GameObject card;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject button = Instantiate(card);
            button.name = "" + i;
            button.transform.SetParent(playField,false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
