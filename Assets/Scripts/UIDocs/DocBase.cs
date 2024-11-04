using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace SmallBiz.UIDoc
{
    public class DocBase : MonoBehaviour
    {
        protected VisualElement _rootElement;

        protected virtual void Start()
        {
            var uiDocument = GetComponent<UIDocument>();
            if (uiDocument != null)
            {
                _rootElement = uiDocument.rootVisualElement;
            }
            else
            {
                throw new MissingComponentException("UIDocument component not found on " + gameObject.name);
            }
        }

        public VisualElement GetElement<T>(string elementName) where T : VisualElement
        {
            return _rootElement?.Q<T>(elementName) ?? throw new KeyNotFoundException($"Element '{elementName}' not found in the UI document.");
        }

        public void Open()
        {
            if (_rootElement != null)
            {
                _rootElement.style.display = DisplayStyle.Flex;
            }
            else
            {
                throw new InvalidOperationException("Root element is not initialized.");
            }
        }

        public void Close()
        {
            if (_rootElement != null)
            {
                _rootElement.style.display = DisplayStyle.None;
            }
            else
            {
                throw new InvalidOperationException("Root element is not initialized.");
            }
        }
        public void FieldError(VisualElement uiElement)
        {
            uiElement.AddToClassList("UIError");
            throw new InvalidOperationException($"Element {uiElement.name} is required.");
        }
        public void RemoveError(VisualElement uiElement)
        {
            uiElement.RemoveFromClassList("UIError");
        }
        public bool VerifyEmptyField(string field)
        {
            return string.IsNullOrEmpty(field);
        }
        public void ValidateField(VisualElement uiElement)
        {
            if (uiElement is TextField text)
            {
                if (VerifyEmptyField(text.value))
                    FieldError(uiElement);
                else
                    RemoveError(uiElement);
            }
        }
    }
}