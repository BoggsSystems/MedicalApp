using Prism.Events;

namespace NoahMedical.Core.Events
{
    /// <summary>
    /// An event used to trigger navigation throughout the application.
    /// The payload is the name of the target view.
    /// </summary>
    public class NavigationEvent : PubSubEvent<string>
    {
        // This event class intentionally left blank. It simply inherits from PubSubEvent<string>,
        // where the string payload will typically be the key or name of the view to navigate to.
    }
}
