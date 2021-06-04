using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessTheNumberScript : MonoBehaviour
{
    public int smallestNumber = 0;
    public int largestNumber = 99;
    public TextMeshProUGUI hintsText;
    public TextMeshProUGUI guessText;

    private int currentNumber;

    private int numberOfGuesses;
    private int score;

    void Start()
    {
        currentNumber = GenerateRandomNumber();
        GenerateHints(currentNumber);
        numberOfGuesses = 0;
        score = 0;
    }

    public void ShowGameEnd()
    {
        guessText.text = "Game Over";
        hintsText.text = "";
        hintsText.text += "\n" + "Total Guesses: " + numberOfGuesses.ToString() + "\n";
        hintsText.text += "\n" + "Number of Correct Guesses: " + score.ToString() + "\n";
    }

    public int GenerateRandomNumber()
    {
        return Random.Range(smallestNumber, largestNumber+1);
    }

    public void CheckGuess(string guess)
    {
        numberOfGuesses++;
        guessText.text = "You guessed " + guess + "\n";
        // WRITE CODE BELOW
        int intGuess = int.Parse(guess);
        if(intGuess == currentNumber)
        {
            score++;
            guessText.text += "You are correct!";
            currentNumber = GenerateRandomNumber();
            GenerateHints(currentNumber);
        }
        else
        {
            if(intGuess < currentNumber)
            {
                guessText.text += "Your guess is too small!";
            }
            else
            {
                guessText.text += "Your guess is too big!";
            }
        }
        // END OF CODE

    }

    public void GenerateHints(int chosenNumber)
    {
        string hints = "";

        // WRITE CODE BELOW
        if(chosenNumber % 2 == 0)
        {
            hints += "The number is even \n";
        }
        else
        {
            hints += "The number is odd \n";
        }
        if(chosenNumber < 10)
        {
            hints += "The number is single digit \n";
        }
        else if(chosenNumber > 50)
        {
            hints += "The number is larger than 50 \n";
        }
        if(chosenNumber % 60 == 0)
        {
            hints += "The number is a multiple of 60 \n";
        }
        if(Mathf.Sqrt(chosenNumber) % 1 == 0)
        {
            hints += "The number is a perfect square \n";
        }
        // END OF CODE

        hintsText.text = hints;
    }
}
