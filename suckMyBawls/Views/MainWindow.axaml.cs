using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace suckMyBawls.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnDishClick(object? sender, RoutedEventArgs e)
        {
            if (sender is not Button button || button.Tag is not string popupName)
                return;

            var popup = this.FindControl<Popup>(popupName);
            if (popup == null)
                return;

            popup.PlacementTarget = button;
            popup.PlacementMode = PlacementMode.Bottom;
            popup.IsOpen = !popup.IsOpen;

            if (popup.IsOpen)
            {
                // Buscar el Border con nombre dinámicamente (ej. PizzaPopupBorder, CurryPopupBorder, etc.)
                var borderName = popupName + "Border";
                var border = this.FindControl<Border>(borderName);
                if (border?.RenderTransform is TranslateTransform transform)
                {
                    double initialY = (popupName == "Plato4Popup" || popupName == "Plato8Popup") ? 100 : -100;
                    double targetY = 0;
                    int duration = 160;

                    var stopwatch = Stopwatch.StartNew();
                    while (stopwatch.ElapsedMilliseconds < duration)
                    {
                        double progress = stopwatch.ElapsedMilliseconds / (double)duration;
                        transform.Y = initialY + (targetY - initialY) * progress;
                        await Task.Delay(3);
                    }

                    transform.Y = targetY;
                }
            }
        }
    }
}
