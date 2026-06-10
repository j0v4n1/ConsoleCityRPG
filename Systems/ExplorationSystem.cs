using ConsoleCityRPG.Entities;
using ConsoleCityRPG.Ui;

namespace ConsoleCityRPG.Systems;

public class ExplorationSystem
{
    public void Update(Renderer renderer, MapManager mapManager, Player player, InputController inputController,
        MovementSystem movement)
    {
        renderer.Render(mapManager, player);
        var input = inputController.GetKey();
        movement.Update(player, mapManager.CurrentGameMap, input, mapManager);
    }
}