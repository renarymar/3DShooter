using Assets.Scripts.Helpers;

namespace Assets.Scripts.Menu
{
    public class Main : Singleton<Main>
    {
        protected Main() { }

        [System.Serializable]
        public struct SceneDate
        {
            public SceneField MainMenu;
            public SceneField Game;
        }

        public SceneDate Scene;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void InitGame()
        {
            //Add controllers
        }
    }
}