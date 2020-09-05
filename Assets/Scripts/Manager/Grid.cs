using UnityEngine;

namespace Assets.Scripts.Manager
{
    static class Grid
    {
        public static GameManager GameManager;
        public static GameEvents GameEvents;
        public static InputManager InputManager;

        static Grid()
        {
            GameObject g = safeFind("__app");

            GameManager = (GameManager) SafeComponent(g, "GameManager");
            GameManager = GameManager.Instance;

            GameEvents = (GameEvents) SafeComponent(g, "GameEvents");
            GameEvents = GameEvents.Instance;

            InputManager = (InputManager) SafeComponent(g, "InputManager");
            InputManager = InputManager.Instance;
        }

        // when Grid wakes up, it checks everything is in place
        // it uses these trivial routines to do so
        private static GameObject safeFind(string s)
        {
            GameObject g = GameObject.Find(s);
            if (g == null) Woe("GameObject " + s + "  not on __preload.");
            return g;
        }

        private static Component SafeComponent(GameObject g, string s)
        {
            Component c = g.GetComponent(s);
            if (c == null) Woe("Component " + s + " not on __preload.");
            return c;
        }

        private static void Woe(string error)
        {
            Debug.Log(">>> Cannot proceed... " + error);
            Debug.Log(">>> It is very likely you just forgot to launch");
            Debug.Log(">>> from scene zero, the _preload scene.");
        }
    }
}
