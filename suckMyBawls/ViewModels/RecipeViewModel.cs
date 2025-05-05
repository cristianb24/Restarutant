//using System.Collections.Generic;
//using CommunityToolkit.Mvvm.ComponentModel;
//using suckMyBawls.Models;


//public partial class RecipeViewModel : ObservableObject
//{
//    [ObservableProperty]
//    private int progress;

//    [ObservableProperty]
//    private string currentStep;

//    [ObservableProperty]
//    private bool isCompleted;

//    public Recipe Recipe { get; }

//    public string Name => Recipe.Name;

//    public string Difficulty => Recipe.Difficulty;

//    public IReadOnlyList<Step> Steps => Recipe.Steps;

//    private int currentStepIndex;

//    public RecipeViewModel(Recipe recipe)
//    {
//        Recipe = recipe;
//        currentStepIndex = 0;
//        Progress = 0;
//        IsCompleted = false;
//        CurrentStep = Steps.Count > 0 ? Steps[0].Description : string.Empty;
//    }

//    public void NextStep()
//    {
//        if (IsCompleted || Steps.Count == 0)
//            return;

//        currentStepIndex++;

//        if (currentStepIndex < Steps.Count)
//        {
//            CurrentStep = Steps[currentStepIndex].Description;
//            Progress = (int)((double)(currentStepIndex) / Steps.Count * 100);
//        }
//        else
//        {
//            // Last step reached
//            CurrentStep = "¡Receta completada!";
//            Progress = 100;
//            IsCompleted = true;
//        }
//    }
//    public void SetProgress(int value)
//    {
//        Progress = value;
//    }

//    public void MarkAsCompleted()
//    {
//        IsCompleted = true;
//    }

//}