using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class InputManager
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static InputManager pInstance = null;
        private static InputManager pActiveManager = null;

        private InputSubject pSubjectArrowRight;
        private InputSubject pSubjectArrowLeft;
        private InputSubject pSubjectSpace;
        private InputSubject pSubjectBkey;
        private InputSubject pSubjectCkey;


        private bool privSpaceKeyPrev;
        private bool priv_B_KeyPrev;
        private bool priv_C_KeyPrev;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public InputManager(bool b = false)
        {
            this.pSubjectArrowLeft = new InputSubject();
            this.pSubjectArrowRight = new InputSubject();

            this.pSubjectSpace = new InputSubject();
            this.privSpaceKeyPrev = b;

            this.pSubjectBkey = new InputSubject();
            this.priv_B_KeyPrev = b;

            this.priv_C_KeyPrev = false;
            this.pSubjectCkey = new InputSubject();

        }

        private InputManager()
        {
            this.pSubjectArrowLeft = new InputSubject();
            this.pSubjectArrowRight = new InputSubject();

            this.privSpaceKeyPrev = false;
            this.pSubjectSpace = new InputSubject();
            
            this.priv_B_KeyPrev = false;
            this.pSubjectBkey = new InputSubject();

            this.priv_C_KeyPrev = false;
            this.pSubjectCkey = new InputSubject();
        }
        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public static void Create()
        {
            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new InputManager();
            }
        }

        public static void SetActive(InputManager pInputMan)
        {
            InputManager pMan = InputManager.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pInputMan != null);
            InputManager.pActiveManager = pInputMan;
        }

        //----------------------------------------------------------------------------------
        // Get Key Methods
        //----------------------------------------------------------------------------------
        public static InputSubject GetArrowRightSubject()
        {
            InputManager pMan = InputManager.pActiveManager;
            Debug.Assert(pMan != null);

            return pMan.pSubjectArrowRight;
        }

        public static InputSubject GetArrowLeftSubject()
        {
            InputManager pMan = InputManager.pActiveManager;
            Debug.Assert(pMan != null);

            return pMan.pSubjectArrowLeft;
        }

        public static InputSubject GetSpaceSubject()
        {
            InputManager pMan = InputManager.pActiveManager;
            Debug.Assert(pMan != null);

            return pMan.pSubjectSpace;
        }

        public static InputSubject GetBkeySubject()
        {
            InputManager pMan = InputManager.pActiveManager;
            Debug.Assert(pMan != null);

            return pMan.pSubjectBkey;
        }

        public static InputSubject GetCkeySubject()
        {
            InputManager pMan = InputManager.pActiveManager;
            Debug.Assert(pMan != null);

            return pMan.pSubjectCkey;
        }

        //----------------------------------------------------------------------------------
        // Update
        //----------------------------------------------------------------------------------

        public static void Update()
        {
            InputManager pMan = InputManager.pActiveManager;
            Debug.Assert(pMan != null);

            // B-Key: (with history) -----------------------------------------------------------
            bool B_KeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_B);

            if (B_KeyCurr == true && pMan.priv_B_KeyPrev == false)
            {
                pMan.pSubjectBkey.Notify();
            }

            pMan.priv_B_KeyPrev = B_KeyCurr;


            // C-Key: (with history) -----------------------------------------------------------
            bool C_KeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_C);

            if (C_KeyCurr == true && pMan.priv_C_KeyPrev == false)
            {
                Lives.AddCredit();
            }

            pMan.priv_C_KeyPrev = C_KeyCurr;


            // LeftKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                pMan.pSubjectArrowLeft.Notify();
            }


            // RightKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                pMan.pSubjectArrowRight.Notify();
            }

            // SpaceKey: (with key history) -----------------------------------------------------------
            bool spaceKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);

            if (spaceKeyCurr == true && pMan.privSpaceKeyPrev == false)
            {
                pMan.pSubjectSpace.Notify();
            }

            pMan.privSpaceKeyPrev = spaceKeyCurr;

        }

        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
        private static InputManager privGetInstance()
        {
            if (pInstance == null)
            {
                pInstance = new InputManager();
            }
            Debug.Assert(pInstance != null);

            return pInstance;
        }

    }
}
