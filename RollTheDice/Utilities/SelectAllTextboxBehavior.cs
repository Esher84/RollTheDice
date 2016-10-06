using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace RollTheDice.Utilities
{
    public class SelectAllTextBoxBehavior : Behavior<TextBox>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.GotFocus += AssociatedObject_GotFocus;
            this.AssociatedObject.PreviewMouseDown += AssociatedObject_PreviewMouseDown;
            this.AssociatedObject.Initialized += AssociatedObject_Initialized;
            this.AssociatedObject.KeyDown += AssociatedObject_KeyDown;
        }

        private void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Keyboard.ClearFocus();
            }
        }

        private void AssociatedObject_Initialized(object sender, System.EventArgs e)
        {
            Keyboard.Focus((this.AssociatedObject));
            this.AssociatedObject.SelectAll();
        }

        private void AssociatedObject_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.AssociatedObject.IsKeyboardFocusWithin)
            {
                e.Handled = true;
                this.AssociatedObject.Focus();
            }
        }

        private void AssociatedObject_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.SelectAll();
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            // Recommended best practice: 
            // Detach the registered event handler to avoid memory leaks.
            base.OnDetaching();
            this.AssociatedObject.GotFocus -= AssociatedObject_GotFocus;
            this.AssociatedObject.PreviewMouseDown -= AssociatedObject_PreviewMouseDown;
            this.AssociatedObject.Initialized -= AssociatedObject_Initialized;
            this.AssociatedObject.KeyDown -= AssociatedObject_KeyDown;
        }
    }
}