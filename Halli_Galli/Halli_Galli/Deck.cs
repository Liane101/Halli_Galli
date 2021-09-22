using System;
using System.Collections.Generic;
using System.Text;

namespace Halli_Galli
{

    class Deck
    {
        public static Card[] deck = new Card[56];


        public static void FillDeck()
        {
            int index = 0;
            foreach (string fruit in Card.FruitsArray)
            {
                for (int value = 1; value <= 5; value++)
                {
                    int anzahl = 0;

                    if (value == 1)
                        anzahl = 5;

                    if (value == 2 || value == 3)
                        anzahl = 3;

                    if (value == 4)
                        anzahl = 2;

                    if (value == 5)
                        anzahl = 1;

                    for (int i = 0; i < anzahl; i++)
                    {
                        Card card = new Card(value, fruit);
                        deck[index] = card;
                        index++;
                    }
                }
            }
        }
        public static void ShuffleDeck()
        {
            var rng = new Random();
            rng.Shuffle(deck);
            rng.Shuffle(deck);
            rng.Shuffle(deck);
            rng.Shuffle(deck);
        }

        public static Card[] Deckzurückgeben()
        {
            Card[] deckcopy = deck;

            return deckcopy;
        }

        public static void PrintDeck()
        {
            for (int i = 0; i < 56; i++)
            {
                Console.WriteLine($"{deck[i].Value} {deck[i].Fruit}");
            }
        }

        public static bool Check(List<Card> Tisch, int Spieleranzahl)
        {
            int pflaumen = 0;
            int limetten = 0;
            int erdbeeren = 0;
            int bananen = 0;

            int bereich;

            if (Tisch.Count > Spieleranzahl)
                bereich = Spieleranzahl;
            else
                bereich = Tisch.Count;


            for (int i = 0; i < bereich; i++)
            {
                if (Tisch[i].Fruit == "Erdbeere")
                    erdbeeren += Tisch[i].Value;

                if (Tisch[i].Fruit == "Limette")
                    limetten += Tisch[i].Value;

                if (Tisch[i].Fruit == "Pflaume")
                    pflaumen += Tisch[i].Value;

                if (Tisch[i].Fruit == "Banane")
                    bananen += Tisch[i].Value;
            }

            if (erdbeeren == 5 || limetten == 5 || pflaumen == 5 || bananen == 5)
                return true;
            else
                return false;
        }
    }
    class Card
    {
        public int Value;
        public static string[] FruitsArray = new string[] { "Erdbeere", "Limette", "Pflaume", "Banane" };
        public string Fruit;

        public Card(int value, string fruit)
        {
            Value = value;
            Fruit = fruit;
        }
    }
    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
    public class Player
    {
        public List<Card> Karten = new List<Card>();
        public Player(List<Card> Kartenliste)
        {
            Karten = Kartenliste;
        }
    }
}
