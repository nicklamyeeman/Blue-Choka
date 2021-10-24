using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeRecipeText : MonoBehaviour
{
    private int index = 0;
    public Text recipeText;
    public List<string> recipeListTitle = new List<string>();
    public List<string> recipeListDescp = new List<string>();

    void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        recipeText.text = "-- " + recipeListTitle[index] + " --\n" + recipeListDescp[index];
    }

    public void NextRecipe()
    {
        if (index == recipeListTitle.Count - 1)
            return;
        index += 1;
        UpdateText();
    }

    public void PreviousRecipe()
    {
        if (index == 0)
            return;
        index -= 1;
        UpdateText();
    }
}
