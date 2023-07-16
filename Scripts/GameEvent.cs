using System;

namespace Sources.Scripts
{
    public class GameEvent
    {
        public static GameState CurrentState;

        public static event Action Started;
        public static event Action Paused;
        public static event Action Resumed;
        public static event Action Over;

        public static void StartGame()
        {
            CurrentState = GameState.Started;
            Started?.Invoke();
        }

        public static void PauseGame()
        {
            CurrentState = GameState.Paused;
            Paused?.Invoke();
        }

        public static void ResumeGame()
        {
            CurrentState = GameState.Resumed;
            Resumed?.Invoke();
        }

        public static void GameOver()
        {
            CurrentState = GameState.Over;
            Over?.Invoke();
        }
    }
}
