using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace WpfOneWayToSourceIssue001.Behaviors
{
    public class UIElementBehaviors : Behavior<UIElement>
    {
        public static DependencyProperty ExampleBehaviorPropertyProperty { get; } = DependencyProperty.Register("ExampleBehaviorProperty", typeof(string), typeof(UIElementBehaviors), new FrameworkPropertyMetadata("DEFAULT"));

        public static string GetExampleBehaviorProperty(DependencyObject dependencyObject) => (string)dependencyObject.GetValue(ExampleBehaviorPropertyProperty);
        public static void SetExampleBehaviorProperty(DependencyObject dependencyObject, string value) => dependencyObject.SetValue(ExampleBehaviorPropertyProperty, value);

        protected override void OnAttached()
        {
            base.OnAttached();
            //SetValue(ExampleBehaviorPropertyProperty, "Example Behavior Dependency Property");
            SetCurrentValue(ExampleBehaviorPropertyProperty, "Example Behavior Dependency Property");
            var value = GetValue(ExampleBehaviorPropertyProperty);
            System.Diagnostics.Debug.WriteLine($"Set value: {(value != null ? $"\"{value}\"" : "null")}");
        }
    }
}
