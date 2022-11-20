using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardController : MonoBehaviour
{
    [SerializeField] Sprite BGImage;
    [SerializeField] GameObject WinScreen;
    public Sprite[] cards;
    public List<Sprite> gameCards = new List<Sprite>();
    public List<Button> buttons = new List<Button>();
    bool firstGuess, secondGuess;
    int countGuesses;
    int countCorrectGuesses;
    int gameGuesses;
    int firstGuessIndex, secondGuessIndex;
    string firstGuessCard, secondGuessCard;
    // Start is called before the first frame update
    private void Awake()
    {
        cards = Resources.LoadAll<Sprite>("Sprites/kat");
    }
    void Start()
    {
        GetButtons();
        AddListeners();
        AddGameCards();
        Shuffle(gameCards);
        gameGuesses = gameCards.Count / 2;
    }

    // Update is called once per frame
    void GetButtons()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Card");
        for (int i = 0; i < gameObjects.Length; i++)
        {
            buttons.Add(gameObjects[i].GetComponent<Button>());
            buttons[i].image.sprite = BGImage;
        }
    }

    void AddGameCards() 
    {
        int index = 0;

        for (int i = 0; i < buttons.Count; i++)
        {
            if (index==buttons.Count/2)
            {
                index = 0;
            }
            gameCards.Add(cards[index]);
            index++;
        }
    }
    void AddListeners() 
    {
        foreach (var btn in buttons)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }
    public void PickAPuzzle() 
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessCard = gameCards[firstGuessIndex].name;
            buttons[firstGuessIndex].image.sprite = gameCards[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessCard = gameCards[secondGuessIndex].name;
            buttons[secondGuessIndex].image.sprite = gameCards[secondGuessIndex];
            countGuesses++;
            StartCoroutine(CheckIfTheCardsMatch());
        }
    }
    IEnumerator CheckIfTheCardsMatch() 
    {
        yield return new WaitForSeconds(1f);
        if (firstGuessCard==secondGuessCard)
        {
            yield return new WaitForSeconds(.5f);
            buttons[firstGuessIndex].interactable = false;
            buttons[secondGuessIndex].interactable = false;
            buttons[firstGuessIndex].image.color = new Color(0,0,0,0);
            buttons[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            IsGameFinished();
        }
        else
        {
            yield return new WaitForSeconds(.2f);
            buttons[firstGuessIndex].image.sprite = BGImage;
            buttons[secondGuessIndex].image.sprite = BGImage;
        }
        firstGuess = false;
        secondGuess = false;
    }
    void IsGameFinished() 
    {
        countCorrectGuesses++;
        if (countCorrectGuesses==gameGuesses)
        {
            Debug.Log("GG");
            Debug.Log(countGuesses);
            WinScreen.SetActive(true);
        }
    }
    void Shuffle(List<Sprite> sprites) 
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            Sprite temp = sprites[i];
            int randomIndex = Random.Range(i, sprites.Count);
            sprites[i] = sprites[randomIndex];
            sprites[randomIndex] = temp;
        }
    }
    public void ReturnToStart() 
    {
        SceneManager.LoadScene("TopDown");
    }
}
