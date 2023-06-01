using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        private List<Tour> _tours;

        public ToursPage()
        {
            InitializeComponent();
            _tours = TourCompanyEntities2.GetContext().Tours.ToList();
            DGridTours.ItemsSource = _tours;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Tour, TourCompanyEntities2.GetContext().Tours.ToList()));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null, TourCompanyEntities2.GetContext().Tours.ToList()));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                var allEntities = TourCompanyEntities2.GetContext().ChangeTracker.Entries().ToList();

                var addedEntities = allEntities.Where(p => p.State == EntityState.Added).ToList();

                allEntities.RemoveAll(p => p.State == EntityState.Added);

                allEntities.ForEach(p => p.Reload());

                DGridTours.ItemsSource = TourCompanyEntities2.GetContext().Tours.ToList();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var toursForRemoving = DGridTours.SelectedItems.Cast<Tour>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {toursForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TourCompanyEntities2.GetContext().Tours.RemoveRange(toursForRemoving);
                    TourCompanyEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    _tours = TourCompanyEntities2.GetContext().Tours.ToList();
                    DGridTours.ItemsSource = _tours;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}