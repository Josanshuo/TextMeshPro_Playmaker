﻿// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro UGUI Basic")]
    [Tooltip("Set Text Mesh Pro input field component.")]
    public class setTextmeshProInputText : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TMP_InputField))]
        [Tooltip("Textmesh Pro Input component is required.")]
        public FsmOwnerDefault gameObject;

        [TitleAttribute("Textmesh Pro Text")]
        [Tooltip("The text for Textmesh Pro.")]
        public FsmString textString;

        [Tooltip("Check this box to preform this action every frame.")]
        public FsmBool everyFrame;

        private GameObject go;
        private TMP_InputField _inputField;

        public override void Reset()
        {
            gameObject = null;
            textString = null;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            SetMeshPro();

            if (!everyFrame.Value)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            SetMeshPro();
        }

        private void SetMeshPro()
        {
            go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                return;
            }

            _inputField = go.GetComponent<TMP_InputField>();
            if (_inputField == null)
            {
                Debug.LogError("No input field component was found on " + go);
                return;
            }

            _inputField.text = textString.Value;
        }
    }
}