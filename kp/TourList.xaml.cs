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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kp
{
    /// <summary>
    /// Логика взаимодействия для TourList.xaml
    /// </summary>
    public partial class TourList : Page
    {
        public TourList()
        {
            InitializeComponent();
            var currentTours = TourCompanyEntities1.GetContext().Tours.ToList();
            LViewTours.ItemsSource = currentTours;
        }
        private void UpdateTours()
        {
            var currentTours = TourCompanyEntities1.GetContext().Tours.ToList();

            currentTours = currentTours.Where(p => p.TourName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            LViewTours.ItemsSource = currentTours.OrderBy(p => p.TravelPackageQty).ToList();
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void TBoxTicketsCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            var parentPanel = VisualTreeHelper.GetParent(textBox) as StackPanel;
            var buyButton = parentPanel.Children.OfType<Button>().FirstOrDefault();
            buyButton.Tag = textBox.Text;
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedTour = (sender as Button).DataContext as Tour;

            // Получаем количество билетов, введенное пользователем
            var buyButton = sender as Button;
            var ticketsCount = Convert.ToInt32(buyButton.Tag);

            // Выполняем покупку билетов
            var tourCompanyEntities = TourCompanyEntities1.GetContext();
            var tour = tourCompanyEntities.Tours.FirstOrDefault(t => t.TourID == selectedTour.TourID);
            if (tour != null)
            {
                if (ticketsCount > tour.TravelPackageQty)
                {
                    MessageBox.Show("Количество билетов превышает доступное количество.");
                }
                else
                {
                    tour.TravelPackageQty -= ticketsCount;
                    tourCompanyEntities.SaveChanges();
                    UpdateTours();
                    MessageBox.Show($"Вы купили {ticketsCount} билетов на тур \"{tour.TourName}\".");
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedTour = (sender as Button).DataContext as Tour;
            var buyButton = sender as Button;
            var ticketsCount = Convert.ToInt32(buyButton.Tag);

            // Отменяем покупку
            selectedTour.TravelPackageQty += ticketsCount;
            TourCompanyEntities1.GetContext().SaveChanges();

            // Обновляем список туров
            UpdateTours();
        }
    }
}