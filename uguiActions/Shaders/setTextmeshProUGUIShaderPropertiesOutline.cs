// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro UGUI Shader")]
    [Tooltip("Set Text Mesh Pro UGUI face shaders.")]
    public class setTextmeshProUGUIShaderPropertiesOutline : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TextMeshProUGUI))]
        [Tooltip("Textmesh Pro component is required.")]
        public FsmOwnerDefault gameObject;

        [TitleAttribute("Enable Outline Shader")]
        public FsmBool enable;

        [ActionSection("Color")]
        public FsmColor outlineColor;

        [ActionSection("Texture")]
        public FsmTexture texture;

        [ActionSection("Settings")]
        public FsmVector2 textureTiling;

        public FsmVector2 textureOffset;

        [ActionSection("Speed")]
        [HasFloatSlider(-5, 5)]
        public FsmFloat speedX;

        [HasFloatSlider(-5, 5)]
        public FsmFloat speedY;

        [ActionSection("Extra Settings")]
        [HasFloatSlider(0, 1)]
        public FsmFloat thickness;

        [Tooltip("Check this box to preform this action every frame.")]
        public FsmBool everyFrame;

        private GameObject go;
        private TextMeshProUGUI meshproScript;

        public override void Reset()
        {
            gameObject = null;
            outlineColor = null;
            thickness = null;
            everyFrame = false;
            texture = null;
            speedX = null;
            speedY = null;
            enable = false;
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

            if (enable.Value == true)
            {
                meshproScript.fontSharedMaterial.EnableKeyword("OUTLINE_ON");
            }

            meshproScript.fontSharedMaterial.SetColor("_OutlineColor", outlineColor.Value);
            meshproScript.fontSharedMaterial.SetFloat("_OutlineWidth", thickness.Value);
            meshproScript.fontSharedMaterial.SetTexture("_OutlineTex", texture.Value);
            meshproScript.fontSharedMaterial.SetFloat("_OutlineUVSpeedX", speedX.Value);
            meshproScript.fontSharedMaterial.SetFloat("_OutlineUVSpeedY", speedY.Value);
            meshproScript.fontSharedMaterial.SetTextureOffset("_OutlineTex", textureOffset.Value);
            meshproScript.fontSharedMaterial.SetTextureScale("_OutlineTex", textureTiling.Value);
        }
    }
}