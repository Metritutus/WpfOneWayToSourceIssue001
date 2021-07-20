using System.Windows;

namespace WpfOneWayToSourceIssue001.AttachedProperties
{
    public static class UIElementAttachedProperties
    {
        public static DependencyProperty ExampleAttachedPropertyProperty { get; } = DependencyProperty.RegisterAttached("ExampleAttachedProperty", typeof(string), typeof(UIElementAttachedProperties), new FrameworkPropertyMetadata("DEFAULT", null, CoerceExampleAttachedPropertyProperty));

        public static string GetExampleAttachedProperty(DependencyObject dependencyObject) => (string)dependencyObject.GetValue(ExampleAttachedPropertyProperty);
        public static void SetExampleAttachedProperty(DependencyObject dependencyObject, string value) => dependencyObject.SetValue(ExampleAttachedPropertyProperty, value);

        private static object CoerceExampleAttachedPropertyProperty(DependencyObject d, object baseValue)
        {
            string value = "Example Attached Dependency Property";
            System.Diagnostics.Debug.WriteLine($"Returning value: {(value != null ? $"\"{value}\"" : "null")}");
            return value;
        }
    }
}
