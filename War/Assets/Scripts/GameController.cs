using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public static GameController S;
	public AudioClip successSound;
	public AudioClip failureSound;
	public AudioClip flipSound;

	public GameObject[] cards;
	private List<GameObject> deck1;
	private List<GameObject> deck2;


	private static int NCOLUMNS = 6;
	private static int NROWS = 6;
	private AudioSource audioSource;

	void Awake() {
		S = this;
		audioSource = GetComponent<AudioSource>();
	}

	void Start() {
		// copy the cards to each deck
		deck1 = new List<GameObject>();
		deck2 = new List<GameObject>();

		for (int i = 0; i < cards.Length; i++) {
			deck1.Add(cards[i]);
			deck2.Add(cards[i]);
		}

		Shuffle (deck1);
		Shuffle (deck2);

		Vector2 pos = new Vector2 (-3, 0);
		Vector2 pos2 = new Vector2 (3, 0);

		for (int i = 0; i < deck1.Count; i++) {
			GameObject card1 = Instantiate(deck1[i]) as GameObject;
			GameObject card2 = Instantiate(deck2[i]) as GameObject;

			card1.transform.position = pos;
			card2.transform.position = pos2;
		}
	}

	void Shuffle(List<GameObject> cards)
	{
		for (int i = 0; i < cards.Count; ++i) {
			GameObject tmp = cards[i];
			int ri = UnityEngine.Random.Range(i, cards.Count);
			cards[i] = cards[ri];
			cards[ri] = tmp;
		}
	}

	private CardController cardA;
	private CardController cardB;


	public IEnumerator OnFlip(CardController card) {

		if (cardA == null) {
			cardA = card;
			cardA.transform.position = new Vector2(cardA.transform.position.x / 2, 0);
			yield return StartCoroutine (card.SetVisible (true));
			//audioSource.PlayOneShot (flipSound, 1.0f);
		} else if (cardB == null && card.GetComponent<Transform>().position.x != cardA.transform.position.x * 2) {
			cardB = card;
			cardB.transform.position = new Vector2(cardB.transform.position.x / 2, 0);
			yield return StartCoroutine (card.SetVisible (true));
			//audioSource.PlayOneShot (flipSound, 1.0f);
		

			if (cardA.GetWorth() > cardB.GetWorth()) {
				if (cardA.transform.position.x < 0) {
					// deck 1
					deck2.Remove(cardB.gameObject);
					deck1.Remove(cardA.gameObject);
					deck1.Add (cardB.gameObject);
					deck1.Add (cardA.gameObject);
				} else {
					// deck 2
					deck1.Remove(cardB.gameObject);
					deck2.Remove(cardA.gameObject);
					deck2.Add (cardB.gameObject);
					deck2.Add (cardA.gameObject);
				}
			} else if (cardA.GetWorth() < cardB.GetWorth()) {
				if (cardB.transform.position.x < 0) {
					// deck 1
					deck2.Remove(cardA.gameObject);
					deck1.Remove(cardB.gameObject);
					deck1.Add (cardB.gameObject);
					deck1.Add (cardA.gameObject);
				} else {
					// deck 2
					deck1.Remove(cardA.gameObject);
					deck2.Remove(cardB.gameObject);
					deck2.Add (cardB.gameObject);
					deck2.Add (cardA.gameObject);
				}
			} else {
			
			}


			Debug.Log (deck1.Count);
			Debug.Log (deck2.Count);

		    cardA = cardB = null;
		}
	}
}
