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
            
            (AssociatedObject as FrameworkElement).DataContextChanged += UIElementBehaviors_DataContextChanged;
        }
        
        private void UIElementBehaviors_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var oldDataContext = e.OldValue as INotifyPropertyChanged;
            var newDataContext = e.NewValue as INotifyPropertyChanged;

            if (oldDataContext != null)
            {
                oldDataContext.PropertyChanged -= DataContext_PropertyChanged;
            }

            if (newDataContext != null)
            {
                newDataContext.PropertyChanged += DataContext_PropertyChanged;
            }
        }
        
        private void DataContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var expression = BindingOperations.GetBindingExpression(this, ExampleBehaviorPropertyProperty);

            if (sender != null && (e.PropertyName == null || e.PropertyName == expression.ResolvedSourcePropertyName))
            {
                var currentSourceValue = sender.GetType().GetProperty(e.PropertyName).GetValue(sender);

                var dependencyPropertyValue = GetValue(ExampleBehaviorPropertyProperty);

                if (dependencyPropertyValue != currentSourceValue)
                {
                    typeof(BindingExpressionBase).GetProperty("Value", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(expression, dependencyPropertyValue);
                }
            }
        }
    }
}
