// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro UGUI Shader")]
    [Tooltip("Set Text Mesh Pro glow shaders UGUI.")]
    public class setTextmeshProUGUIShaderPropertiesGlow : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TextMeshProUGUI))]
        [Tooltip("Textmesh Pro component is required.")]
        public FsmOwnerDefault gameObject;

        public FsmBool enableGlow;

        public FsmColor glowColor;

        [HasFloatSlider(-1, 1f)]
        public FsmFloat offset;

        [HasFloatSlider(0, 1)]
        public FsmFloat inner;

        [HasFloatSlider(0, 1)]
        public FsmFloat outer;

        [HasFloatSlider(1, 0)]
        public FsmFloat power;

        [Tooltip("Check this box to preform this action every frame.")]
        public FsmBool everyFrame;

        private GameObject go;
        private TextMeshProUGUI meshproScript;

        public override void Reset()
        {
            enableGlow = null;
            offset = null;
            inner = null;
            outer = null;
            power = null;
            glowColor = null;
            gameObject = null;
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

            meshproScript = go.GetComponent<TextMeshProUGUI>();
            if (meshproScript == null)
            {
                Debug.LogError("No textmesh pro ugui component was found on " + go);
                return;
            }

            if (enableGlow.Value == true)
            {
                meshproScript.fontSharedMaterial.EnableKeyword("GLOW_ON");
            }

            meshproScript.fontSharedMaterial.SetColor("_GlowColor", glowColor.Value);
            meshproScript.fontSharedMaterial.SetFloat("_GlowOffset", offset.Value);
            meshproScript.fontSharedMaterial.SetFloat("_GlowInner", inner.Value);
            meshproScript.fontSharedMaterial.SetFloat("_GlowOuter", outer.Value);
            meshproScript.fontSharedMaterial.SetFloat("_GlowPower", power.Value);
        }
    }
}