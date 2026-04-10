using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PlanATest.utils
{
    public class SimpleImageTouch : MonoBehaviour
    { 
        public Action<SimpleImageTouch> OnDown;
        public Action<SimpleImageTouch> OnUp;
        public Action<SimpleImageTouch> OnClick;

        protected bool started;
        protected Image image;

        public Image Image => image;

        protected virtual void Awake()
        {
             image = GetComponent<Image>();
        }

        protected virtual void Start()
        {
            var trigger = gameObject.AddComponent<EventTrigger>();
            //add event down
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
            trigger.triggers.Add(entry);
            //add event up
            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerUp;
            entry.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
            trigger.triggers.Add(entry);
            //add event exit
            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerExit;
            entry.callback.AddListener((data) => { OnPointerExit((PointerEventData)data); });
            trigger.triggers.Add(entry);

        }
        protected virtual void OnPointerDown(PointerEventData e)
        {
            started = true;
            OnDown?.Invoke(this);
        }
        protected virtual void OnPointerUp(PointerEventData e)
        {
            OnUp?.Invoke(this);
            if (!started)
                return;
            started = false;
            OnClick?.Invoke(this);
        }
        protected virtual void OnPointerExit(PointerEventData e)
        {
            started = false;
        }

    }
}