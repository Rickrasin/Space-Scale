using System;
using System.Collections.Generic;

namespace Space.Managers
{
    public static class EventManager
    {
        // Para eventos com payload
        private static Dictionary<string, Action<object>> eventDictionaryWithArgs = new Dictionary<string, Action<object>>();

        // Para eventos sem payload
        private static Dictionary<string, Action> eventDictionaryWithoutArgs = new Dictionary<string, Action>();

        // Método para registrar eventos com payload
        public static void RegisterEvent<TEventArgs>(string eventType, Action<TEventArgs> eventHandler)
        {
            if (!eventDictionaryWithArgs.ContainsKey(eventType))
            {
                eventDictionaryWithArgs[eventType] = e => eventHandler((TEventArgs)e);
            }
            else
            {
                eventDictionaryWithArgs[eventType] += e => eventHandler((TEventArgs)e);
            }
        }

        // Método para desregistrar eventos com payload
        public static void UnregisterEvent<TEventArgs>(string eventType, Action<TEventArgs> eventHandler)
        {
            if (eventDictionaryWithArgs.ContainsKey(eventType))
            {
                eventDictionaryWithArgs[eventType] -= e => eventHandler((TEventArgs)e);
            }
        }

        // Método para disparar eventos com payload
        public static void TriggerEvent<TEventArgs>(string eventType, TEventArgs eventArgs)
        {
            if (eventDictionaryWithArgs.ContainsKey(eventType))
            {
                eventDictionaryWithArgs[eventType]?.Invoke(eventArgs);
            }
        }

        // Método para registrar eventos sem payload
        public static void RegisterEvent(string eventType, Action eventHandler)
        {
            if (!eventDictionaryWithoutArgs.ContainsKey(eventType))
            {
                eventDictionaryWithoutArgs[eventType] = eventHandler;
            }
            else
            {
                eventDictionaryWithoutArgs[eventType] += eventHandler;
            }
        }

        // Método para desregistrar eventos sem payload
        public static void UnregisterEvent(string eventType, Action eventHandler)
        {
            if (eventDictionaryWithoutArgs.ContainsKey(eventType))
            {
                eventDictionaryWithoutArgs[eventType] -= eventHandler;
            }
        }

        // Método para disparar eventos sem payload
        public static void TriggerEvent(string eventType)
        {
            if (eventDictionaryWithoutArgs.ContainsKey(eventType))
            {
                eventDictionaryWithoutArgs[eventType]?.Invoke();
            }
        }
    }
}

public static class EventKey
{
    public static string ChangeGameEvent = "ChangeGameEvent";
    public static string PauseGame = "PauseGame";
    public static string ContinueGame = "ContinueGame";
    public static string OpenRecipeSelector = "OpenRecipeSelector";
    public static string SelectRecipe = "SelectRecipe";
    public static string GameStart = "GameStart"; // Exemplo de evento sem payload
}
