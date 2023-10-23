using Leopotam.EcsLite;
using Unigine;
using UnigineApp.data.General.Scripts.Gameplay.Info.Scenes.MainMenu;

namespace UnigineApp.data.General.Scripts.Gameplay.Systems.MainMenu.UI;

public class MainMenuPreInitSystem : IEcsPreInitSystem
{
    private readonly MainMenuInfoUI _mainMenuInfoUi;

    public MainMenuPreInitSystem(MainMenuInfoUI mainMenuInfoUi)
    {
        _mainMenuInfoUi = mainMenuInfoUi;
    }
    
    public void PreInit(IEcsSystems systems)
    {
        _mainMenuInfoUi.GUI = Gui.GetCurrent();
        _mainMenuInfoUi.Canvas = new();
        
        _mainMenuInfoUi.PlayButton = new();
        _mainMenuInfoUi.PlayButton.Text = "Play";
        _mainMenuInfoUi.PlayButton.FontSize = 75;
        _mainMenuInfoUi.PlayButton.ButtonColor = vec4.BLACK;
        _mainMenuInfoUi.PlayButton.SetPosition(200, 100);
        _mainMenuInfoUi.PlayButton.AddCallback(Gui.CALLBACK_INDEX.CLICKED, OnPlayButtoClick);
        
        _mainMenuInfoUi.QuitButton = new();
        _mainMenuInfoUi.QuitButton.Text = "Quit";
        _mainMenuInfoUi.QuitButton.FontSize = 75;
        _mainMenuInfoUi.QuitButton.ButtonColor = vec4.BLACK;
        _mainMenuInfoUi.QuitButton.SetPosition(200, 300);
        _mainMenuInfoUi.QuitButton.AddCallback(Gui.CALLBACK_INDEX.CLICKED, OnQuitButtonCLick);
        
        _mainMenuInfoUi.GUI.AddChild(_mainMenuInfoUi.PlayButton);
        _mainMenuInfoUi.GUI.AddChild(_mainMenuInfoUi.QuitButton);
    }

    private void OnPlayButtoClick()
    {
        
    }

    private void OnQuitButtonCLick() => Engine.Quit();
}