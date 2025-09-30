using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Loam
{
    namespace Convo
    {
        public class ConversationManager : MonoBehaviour
        {
            [Header("Debug References")]
            [SerializeField] private TextAsset _debugConvo;
            [SerializeField] private Button _debugButton;

            [Header("Dialog")]
            [SerializeField] private ConversationDialog _dialog;
            [SerializeField] private Transform _dialogParent;

            [Header("Data")]
            [SerializeField] private List<TextAsset> _conversations;


            private void ProcessMessage(string input)
            {
                // TODO: Hook up to a real messaging system instead of a generic logging thing
                Debug.Log(input);
            }

            public void Start()
            {
                _dialog.Hide();
                _dialog.ConversationSystem.OnEnd += EndConversation;
                _dialog.ConversationSystem.OnMessage += ProcessMessage;

                EndConversation();

                // DEBUG - Lambdas in this style are discouraged.
                _dialog.ConversationSystem.OnEnd += () =>
                {
                    if (_debugButton != null)
                    {
                        _debugButton.gameObject.SetActive(true);
                    }
                };

                if (_debugButton != null)
                {
                    _debugButton.onClick.AddListener(() =>
                    {
                        _debugButton.gameObject.SetActive(false);
                        StartConversation(_debugConvo.text);
                    });
                }

            }

            public void StartByName(string convoName)
            {
                for (int i = 0; i < _conversations.Count; ++i)
                {
                    string name = _conversations[i].name;
                    if (convoName.Equals(name))
                    {
                        StartConversation(_conversations[i].text);
                        return;
                    }
                }
            }

            public void StartConversation(string conversationJSON)
            {
                _dialog.Show(conversationJSON);
            }

            private void EndConversation()
            {
                _dialog.Hide();
            }
        }
    }
}