using System.Collections;
using System.Collections.Generic;

// Type Safe eventing system based partially on http://www.willrmiller.com/?p=87
public class EventController {
    private static readonly EventController instance = new EventController();

    // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
    static EventController() {
    }

    public static EventController Instance {
        get { return instance; }
    }

    private EventController() {
    }

    public delegate void EventDelegate<T>(T e) where T : GameEvent;
    private delegate void EventDelegate(GameEvent e);

    private Dictionary<System.Type, EventDelegate> delegates = new Dictionary<System.Type, EventDelegate>();
    private Dictionary<System.Delegate, EventDelegate> delegateLookup = new Dictionary<System.Delegate, EventDelegate>();

    // Subscribe to type safe event inherited from GameEvent
    public void Subscribe<T>(EventDelegate<T> del) where T : GameEvent {
        if (delegateLookup.ContainsKey(del))
            return;

        // Create a new non-generic delegate which calls our generic one.
        EventDelegate internalDelegate = (e) => del((T)e);
        delegateLookup[del] = internalDelegate;

        EventDelegate tempDel;
        if (delegates.TryGetValue(typeof(T), out tempDel)) {
            delegates[typeof(T)] = tempDel += internalDelegate;
        } else {
            delegates[typeof(T)] = internalDelegate;
        }
    }

    // Unsubscribe from type safe event
    public void UnSubscribe<T>(EventDelegate<T> del) where T : GameEvent {
        EventDelegate internalDelegate;
        if (delegateLookup.TryGetValue(del, out internalDelegate)) {
            EventDelegate tempDel;
            if (delegates.TryGetValue(typeof(T), out tempDel)) {
                tempDel -= internalDelegate;
                if (tempDel == null) {
                    delegates.Remove(typeof(T));
                } else {
                    delegates[typeof(T)] = tempDel;
                }
            }

            delegateLookup.Remove(del);
        }
    }

    // Publish type safe event inherited from GameEvent
    public void Publish(GameEvent e) {
        EventDelegate del;
        if (delegates.TryGetValue(e.GetType(), out del)) {
            del.Invoke(e);
        }
    }
}