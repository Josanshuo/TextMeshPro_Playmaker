// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro Advanced")]
    [Tooltip("Enable Text Mesh Pro Kerning.")]
    public class enableTextmeshProKerning : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TextMeshPro))]
        [Tooltip("Textmesh Pro component is required.")]
        public FsmOwnerDefault gameObject;

        [Tooltip("Check this to enable kerning.")]
        public FsmBool enableKerning;

        [Tooltip("Check this box to preform this action every frame.")]
        public FsmBool everyFrame;

        private GameObject go;
        private TextMeshPro meshproScript;

        public override void Reset()
        {
            gameObject = null;
            enableKerning = false;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            DoMeshChange();

            if (!everyFrame.Value)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            DoMeshChange();
        }

        void DoMeshChange()
        {
            go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                return;
            }

            meshproScript = go.GetComponent<TextMeshPro>();
            if (meshproScript == null)
            {
                Debug.LogError("No textmesh pro component was found on " + go);
                return;
            }

            meshproScript.enableKerning = enableKerning.Value;
        }
    }
}