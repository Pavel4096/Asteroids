using System;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Dictionary2))]
public class DictionaryDrawer: PropertyDrawer
{
    const float space = 10.0f;
    const float cellSpace = 25.0f;
    const int noItemChosen = -1;
    const string addNewItemText = "Добавить";

    private bool foldOut = false;
    private string newKey = String.Empty;
    private string newValue = String.Empty;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty keys = property.FindPropertyRelative("keys");
        SerializedProperty values = property.FindPropertyRelative("values");
        SerializedProperty currentElement;
        int elementsCount = keys.arraySize;
        float lineHeight = GUI.skin.textField.lineHeight;
        Rect currentRect;
        float halfWidth;
        float fieldWidth;
        float buttonOffset;
        float buttonWidth;
        int chosenItemIndex = noItemChosen;
        bool addNewEntry = false;

        foldOut = EditorGUI.Foldout(new Rect(position.x, position.y, position.width, lineHeight), foldOut, label);

        if(foldOut)
        {
            halfWidth = position.width/2;
            fieldWidth = halfWidth - cellSpace;
            buttonOffset = fieldWidth + cellSpace/2;
            buttonWidth = cellSpace/2;
            currentRect = new Rect(position.x, position.y + lineHeight + space, fieldWidth, lineHeight);
            for(var i = 0; i < elementsCount; i++)
            {
                currentRect.x = position.x;
                currentElement = keys.GetArrayElementAtIndex(i);
                //currentElement.stringValue = GUI.TextField(currentRect, currentElement.stringValue);
                EditorGUI.PropertyField(currentRect, currentElement, GUIContent.none);
                currentRect.x += halfWidth;
                currentElement = values.GetArrayElementAtIndex(i);
                //currentElement.stringValue = GUI.TextField(currentRect, currentElement.stringValue);
                EditorGUI.PropertyField(currentRect, currentElement, GUIContent.none);
                currentRect.x += buttonOffset;
                currentRect.width = buttonWidth;
                if(GUI.Button(currentRect, GUIContent.none))
                    chosenItemIndex = i;
                currentRect.width = fieldWidth;
                currentRect.y += lineHeight + space;
            }
            if(chosenItemIndex != noItemChosen)
            {
                keys.DeleteArrayElementAtIndex(chosenItemIndex);
                values.DeleteArrayElementAtIndex(chosenItemIndex);
            }

            currentRect.x = position.x;
            addNewEntry = GUI.Button(currentRect, addNewItemText);
            currentRect.y += lineHeight + space;
            newKey = GUI.TextField(currentRect, newKey);
            currentRect.x += halfWidth;
            newValue = GUI.TextField(currentRect, newValue);

            if(addNewEntry)
            {
                int arrayIndex = keys.arraySize;
                bool keyExists = false;

                for(var i = 0; i < elementsCount; i++)
                    if(keys.GetArrayElementAtIndex(i).stringValue.Equals(newKey))
                        keyExists = true;

                if(!keyExists)
                {
                    keys.InsertArrayElementAtIndex(arrayIndex);
                    values.InsertArrayElementAtIndex(arrayIndex);
                    keys.GetArrayElementAtIndex(arrayIndex).stringValue = newKey;
                    values.GetArrayElementAtIndex(arrayIndex).stringValue = newValue;
                    newKey = String.Empty;
                    newValue = String.Empty;
                }
                else
                    Debug.LogError(String.Format("Ключ '{0}' уже есть в словаре", newKey));
            }
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var count = property.FindPropertyRelative("keys").arraySize;
        float height;

        if(foldOut)
            height = (count + 3)*(GUI.skin.textField.lineHeight + space);
        else
            height = GUI.skin.textField.lineHeight + space;

        return height;
    }
}
