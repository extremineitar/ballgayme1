using UnityEngine;

   static public class Manager
{
    public static bool Dead = false;

    public static bool Paused = false;

    public static void loseGame()
    {
        Dead = true;
    }
}
