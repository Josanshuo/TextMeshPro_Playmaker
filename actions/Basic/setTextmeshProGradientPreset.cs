// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com


using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro Basic")]
    [Tooltip("Set Text Mesh Pro Gradient Preset.")]
    public class setTextmeshProGradientPreset : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TextMeshPro))]
        [Tooltip("Textmesh Pro component is required.")]
        public FsmOwnerDefault gameObject;

        [TitleAttribute("Gradient Preset")]
        [ObjectType(typeof(TMP_ColorGradient))]
        [Tooltip("Choose a gradient preset.")]
        public FsmObject gradientPreset;

        [Tooltip("Check this box to preform this action every frame.")]
        public FsmBool everyFrame;

        private GameObject go;
        private TextMeshPro meshproScript;

        public override void Reset()
        {
            gameObject = null;
            gradientPreset = null;
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

            meshproScript.colorGradientPreset = (TMP_ColorGradient) gradientPreset.Value;
        }
    }
}