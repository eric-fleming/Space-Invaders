using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneContext
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        SceneState pSceneState;

        SceneSelect poSceneSelect;
        SceneDemo poSceneDemo;
        ScenePlay poScenePlay;
        SceneGameOver poSceneGameOver;


        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Scene
        {
            Select,
            Demo,
            Play,
            GameOver,

            Default
        }


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public SceneContext()
        {
            // reserve the states
            this.poSceneSelect = new SceneSelect();
            this.poSceneDemo = new SceneDemo();
            this.poScenePlay = new ScenePlay();
            this.poSceneGameOver = new SceneGameOver();

            // initialize to the select state
            this.pSceneState = this.poSceneSelect;
            this.pSceneState.Entering();
        }


        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public SceneState GetState()
        {
            return this.pSceneState;
        }

        public void ResetState(Scene eScene)
        {
            switch (eScene)
            {
                case Scene.Play:
                    this.poScenePlay = new ScenePlay();
                    break;
            }
        }


        public void SetState(Scene eScene)
        {
            switch (eScene)
            {
                case Scene.Select:
                    this.pSceneState.Leaving();
                    this.pSceneState = this.poSceneSelect;
                    this.pSceneState.Entering();
                    break;


                case Scene.Demo:
                    this.pSceneState.Leaving();
                    this.pSceneState = this.poSceneDemo;
                    this.pSceneState.Entering();
                    break;


                case Scene.Play:
                    this.pSceneState.Leaving();
                    this.pSceneState = this.poScenePlay;
                    this.pSceneState.Entering();
                    break;


                case Scene.GameOver:
                    this.pSceneState.Leaving();
                    this.pSceneState = this.poSceneGameOver;
                    this.pSceneState.Entering();
                    break;

                case Scene.Default:
                    Debug.WriteLine("The state your are looking for is Not Defined...");
                    Debug.Assert(false);
                    break;

            }
        }
    }
}
