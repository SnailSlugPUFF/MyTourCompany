using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace kp
{
    /// <summary>
    /// Логика взаимодействия для TourList.xaml
    /// </summary>
    public partial class TourList : Window
    {
        private List<Tour> purchasedTours;

        public TourList()
        {
            InitializeComponent();
            var currentTours = TourCompanyEntities2.GetContext().Tours.ToList();
            LViewTours.ItemsSource = currentTours;
            purchasedTours = new List<Tour>();
        }
        private void UpdateTours()
        {
            var currentTours = TourCompanyEntities2.GetContext().Tours.ToList();

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

            if (!Regex.IsMatch(textBox.Text, @"^\d*$"))
            {
                MessageBox.Show("Пожалуйста, введите только целочисленное значение.");
                textBox.Text = string.Empty;
                return;
            }

            buyButton.Tag = textBox.Text;

            // Устанавливаем значение ticketsCount в buyButton.Tag при изменении текста
            if (int.TryParse(textBox.Text, out int ticketsCount))
            {
                buyButton.Tag = ticketsCount;
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedTour = (sender as Button).DataContext as Tour;
            // Получаем количество билетов, введенное пользователем
            Button buyButton = sender as Button;
            var ticketsCount = Convert.ToInt32(buyButton.Tag);


            // Выполняем покупку билетов
            var tourCompanyEntities = TourCompanyEntities2.GetContext();
            var tour = tourCompanyEntities.Tours.FirstOrDefault(t => t.TourID == selectedTour.TourID);
            if (tour != null)
            {
                if (ticketsCount > tour.TravelPackageQty)
                {
                    MessageBox.Show("Количество билетов превышает доступное количество.");
                }
                if (ticketsCount <= 0)
                {
                    MessageBox.Show("Количество билетов для покупки не может быть равно 0");
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите купить {ticketsCount} билетов на тур \"{tour.TourName}\"?", "Подтверждение покупки", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        tour.TravelPackageQty -= ticketsCount;
                        tourCompanyEntities.SaveChanges();
                        UpdateTours();
                        MessageBox.Show($"Вы успешно купили {ticketsCount} билетов на тур \"{tour.TourName}\".");

                        for (int i = 0; i < ticketsCount; i++)
                        {
                            purchasedTours.Add(tour);
                        }
                    }
                }
            }
        }

        private void ViewPurchasedTours_Click(object sender, RoutedEventArgs e)
        {
            PurchasedToursWindow purchasedToursWindow = new PurchasedToursWindow(purchasedTours);
            purchasedToursWindow.Show();
        }

        private void BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            var mainwin = new LoginWindow();
            Application.Current.MainWindow = mainwin;
            mainwin.Show();
            this.Close();
        }

        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            // Создание нового документа Word
            string fileName = "C:\\Otchet\\otchet.docx";
            using (WordprocessingDocument document = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
            {
                // Добавление основного содержимого документа
                MainDocumentPart mainPart = document.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Добавление заголовка
                Paragraph heading = new Paragraph();
                Run headingRun = new Run(new Text("Отчет о купленных турах"));
                heading.Append(headingRun);
                body.Append(heading);

                // Добавление информации о купленных турах
                foreach (Tour tour in purchasedTours)
                {
                    // Создание параграфа для каждого тура
                    Paragraph tourParagraph = new Paragraph();

                    // Добавление названия тура
                    Run tourNameRun = new Run(new Text($"Название тура: {tour.TourName}"));
                    tourParagraph.Append(tourNameRun);
                    tourParagraph.Append(new Break());

                    // Добавление цены тура
                    Run tourPriceRun = new Run(new Text($"Цена тура: {tour.TourPrice} $"));
                    tourParagraph.Append(tourPriceRun);
                    tourParagraph.Append(new Break());

                    // Добавление даты тура
                    Run tourDateRun = new Run(new Text($"Дата тура: {tour.TourDate.ToString("d")}"));
                    tourParagraph.Append(tourDateRun);
                    tourParagraph.Append(new Break());

                    Run dayQtyRun = new Run(new Text($"Количество дней: {tour.DayQty}"));
                    tourParagraph.Append(dayQtyRun);
                    tourParagraph.Append(new Break());

                    // Добавление параграфа с информацией о туре в документ
                    body.Append(tourParagraph);
                }

                // Сохранение документа
                mainPart.Document.Save();
            }

            MessageBox.Show("Отчет успешно создан.");
        }
    }
}