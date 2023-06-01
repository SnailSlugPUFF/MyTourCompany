using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kp
{
    public partial class PurchasedToursWindow : Window
    {

        private List<Tour> purchasedTours;

        public PurchasedToursWindow(List<Tour> purchasedTours)
        {
            InitializeComponent();

            this.purchasedTours = purchasedTours;
            ShowPurchasedTours();
        }

        private void ShowPurchasedTours()
        {
            foreach (Tour tour in purchasedTours)
            {
                // Создайте элемент управления, например, TextBlock, для отображения информации о каждом купленном туре
                TextBlock textBlock = new TextBlock();
                textBlock.Text = $"Название тура: {tour.TourName}, Цена билета: {tour.TourPrice}, Дата тура: {tour.TourDate.ToString("d")}, Количество дней: {tour.DayQty}"; // Пример отображения имени тура

                // Добавьте элемент управления в StackPanel или другой контейнер вашего окна
                // Например:
                StackPanelTours.Children.Add(textBlock);
            }
        }
    }
}
