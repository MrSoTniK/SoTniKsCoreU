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

        var width = _mainMenuInfoUi.GUI.Width;
        var height = _mainMenuInfoUi.GUI.Height;

        _mainMenuInfoUi.PlayButton = new();
        _mainMenuInfoUi.PlayButton.Text = "Play";
        _mainMenuInfoUi.PlayButton.FontSize = 75;
        _mainMenuInfoUi.PlayButton.ButtonColor = vec4.WHITE;
        _mainMenuInfoUi.PlayButton.SetPosition(0, 0);
        _mainMenuInfoUi.PlayButton.AddCallback(Gui.CALLBACK_INDEX.CLICKED, OnPlayButtoClick);
        
        _mainMenuInfoUi.QuitButton = new();
        _mainMenuInfoUi.QuitButton.Text = "Quit";
        _mainMenuInfoUi.QuitButton.FontSize = 75;
        _mainMenuInfoUi.QuitButton.ButtonColor = vec4.WHITE;
        _mainMenuInfoUi.QuitButton.SetPosition(10, 10);
        _mainMenuInfoUi.QuitButton.AddCallback(Gui.CALLBACK_INDEX.CLICKED, OnQuitButtonCLick);
        
        _mainMenuInfoUi.GUI.AddChild(_mainMenuInfoUi.PlayButton,Gui.ALIGN_CENTER);
        _mainMenuInfoUi.GUI.AddChild(_mainMenuInfoUi.QuitButton,Gui.ALIGN_CENTER);
        _mainMenuInfoUi.QuitButton.SetPosition(900, 900);
    }

    private void OnPlayButtoClick()
    {
        
    }

    private void OnQuitButtonCLick() => Engine.Quit();
}