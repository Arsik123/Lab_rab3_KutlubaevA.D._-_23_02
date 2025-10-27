using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Lab_rab3_KutlubaevA.D._БПИ_23_02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateControls();
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (R1Group == null && R2Group == null && R3Group == null && R4Group == null && R5Group == null)
                return;

            UpdateControls();
        }

        private void UpdateControls()
        {
            if (R1Group != null)
            {
                R1Group.IsEnabled = Radio1.IsChecked.GetValueOrDefault();
                if (!R1Group.IsEnabled) ResetR1();
            }

            if (R2Group != null)
            {
                R2Group.IsEnabled = Radio2.IsChecked.GetValueOrDefault();
                if (!R2Group.IsEnabled) ResetR2();
            }

            if (R3Group != null)
            {
                R3Group.IsEnabled = Radio3.IsChecked.GetValueOrDefault();
                if (!R3Group.IsEnabled) ResetR3();
            }

            if (R4Group != null)
            {
                R4Group.IsEnabled = Radio4.IsChecked.GetValueOrDefault();
                if (!R4Group.IsEnabled) ResetR4();
            }

            if (R5Group != null)
            {
                R5Group.IsEnabled = Radio5.IsChecked.GetValueOrDefault();
                if (!R5Group.IsEnabled) ResetR5();
            }
        }

        private void ResetR1()
        {
            if (R1TextA != null) R1TextA.Text = "0,00";
            if (R1ComboF != null) R1ComboF.SelectedIndex = 0;
        }
        private void ResetR2()
        {
            if (R2TextA != null) R2TextA.Text = "0,00";
            if (R2TextB != null) R2TextB.Text = "0,00";
            if (R2ComboF != null) R2ComboF.SelectedIndex = 0;
        }
        private void ResetR3()
        {
            if (R3TextA != null) R3TextA.Text = "0,00";
            if (R3TextB != null) R3TextB.Text = "0,00";
            if (R3ComboC != null) R3ComboC.SelectedIndex = 0;
            if (R3ComboD != null) R3ComboD.SelectedIndex = 0;
        }
        private void ResetR4()
        {
            if (R4TextA != null) R4TextA.Text = "0,00";
            if (R4TextD != null) R4TextD.Text = "0";
            if (R4ComboC != null) R4ComboC.SelectedIndex = 0;
        }
        private void ResetR5()
        {
            if (R5TextN != null) R5TextN.Text = "1";
            if (R5TextK != null) R5TextK.Text = "1";
            if (R5TextX != null) R5TextX.Text = "0,00";
            if (R5TextF != null) R5TextF.Text = "0,00";
            if (R5TextY != null) R5TextY.Text = "0,00";
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var culture = CultureInfo.CurrentCulture;
                if (Radio1.IsChecked.GetValueOrDefault())
                {
                    if (!double.TryParse(R1TextA?.Text ?? "", NumberStyles.Float, culture, out double a))
                    {
                        ShowInputError("a", "формула 1");
                        return;
                    }

                    if (!TryGetComboBoxDouble(R1ComboF, out double f))
                    {
                        MessageBox.Show("Ошибка! Выберите корректное значение f (формула 1).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Title = "Ответ: Ошибка!";
                        return;
                    }

                    double result = Math.Sin(f * a);
                    this.Title = "Ответ: " + result.ToString("F2", culture);
                }
                else if (Radio2.IsChecked.GetValueOrDefault())
                {
                    if (!double.TryParse(R2TextA?.Text ?? "", NumberStyles.Float, culture, out double a))
                    {
                        ShowInputError("a", "формула 2");
                        return;
                    }
                    if (!double.TryParse(R2TextB?.Text ?? "", NumberStyles.Float, culture, out double b))
                    {
                        ShowInputError("b", "формула 2");
                        return;
                    }
                    if (!TryGetComboBoxDouble(R2ComboF, out double f))
                    {
                        MessageBox.Show("Ошибка! Выберите корректное значение f (формула 2).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Title = "Ответ: Ошибка!";
                        return;
                    }

                    double result = Math.Cos(f * a) + Math.Sin(f * b);
                    this.Title = "Ответ: " + result.ToString("F2", culture);
                }
                else if (Radio3.IsChecked.GetValueOrDefault())
                {
                    if (!double.TryParse(R3TextA?.Text ?? "", NumberStyles.Float, culture, out double a))
                    {
                        ShowInputError("a", "формула 3");
                        return;
                    }
                    if (!double.TryParse(R3TextB?.Text ?? "", NumberStyles.Float, culture, out double b))
                    {
                        ShowInputError("b", "формула 3");
                        return;
                    }
                    if (!TryGetComboBoxDouble(R3ComboC, out double c))
                    {
                        MessageBox.Show("Ошибка! Выберите корректное значение c (формула 3).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Title = "Ответ: Ошибка!";
                        return;
                    }
                    if (!TryGetComboBoxDouble(R3ComboD, out double d))
                    {
                        MessageBox.Show("Ошибка! Выберите корректное значение d (формула 3).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Title = "Ответ: Ошибка!";
                        return;
                    }

                    double result = c * Math.Pow(a, 2) + d * Math.Pow(b, 2);
                    this.Title = "Ответ: " + result.ToString("F2", culture);
                }
                else if (Radio4.IsChecked.GetValueOrDefault())
                {
                    if (!double.TryParse(R4TextA?.Text ?? "", NumberStyles.Float, culture, out double a))
                    {
                        ShowInputError("a", "формула 4");
                        return;
                    }
                    if (!int.TryParse(R4TextD?.Text ?? "", NumberStyles.Integer, culture, out int d))
                    {
                        MessageBox.Show("Ошибка! Параметр d должен быть целым числом (формула 4).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Title = "Ответ: Ошибка!";
                        return;
                    }
                    if (d < 0)
                    {
                        MessageBox.Show("Ошибка! Параметр d должен быть неотрицательным (формула 4).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Title = "Ответ: Ошибка!";
                        return;
                    }
                    if (!TryGetComboBoxDouble(R4ComboC, out double c))
                    {
                        MessageBox.Show("Ошибка! Выберите корректное значение c (формула 4).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Title = "Ответ: Ошибка!";
                        return;
                    }

                    double sum = 0;
                    for (int i = 0; i <= d; i++)
                    {
                        sum += Math.Pow(c + a, i);
                    }
                    this.Title = "Ответ: " + sum.ToString("F2", culture);
                }
                else if (Radio5.IsChecked.GetValueOrDefault())
                {
                    if (!int.TryParse(R5TextN?.Text ?? "", NumberStyles.Integer, culture, out int N))
                    {
                        MessageBox.Show("Ошибка! Параметр N должен быть целым числом (формула 5).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Title = "Ответ: Ошибка!";
                        return;
                    }
                    if (!int.TryParse(R5TextK?.Text ?? "", NumberStyles.Integer, culture, out int K))
                    {
                        MessageBox.Show("Ошибка! Параметр K должен быть целым числом (формула 5).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Title = "Ответ: Ошибка!";
                        return;
                    }
                    if (N < 1 || K < 1)
                    {
                        MessageBox.Show("Ошибка! N и K должны быть >= 1 (в формуле индексы идут от 1 до N и от 1 до K).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Title = "Ответ: Ошибка!";
                        return;
                    }
                    if (!double.TryParse(R5TextX?.Text ?? "", NumberStyles.Float, culture, out double x))
                    {
                        ShowInputError("x", "формула 5");
                        return;
                    }
                    if (!double.TryParse(R5TextF?.Text ?? "", NumberStyles.Float, culture, out double f))
                    {
                        ShowInputError("f", "формула 5");
                        return;
                    }
                    if (!double.TryParse(R5TextY?.Text ?? "", NumberStyles.Float, culture, out double y))
                    {
                        ShowInputError("y", "формула 5");
                        return;
                    }

                    double Z = 0;

                    for (int i = 1; i <= N; i++)
                    {
                        for (int j = 1; j <= K; j++)
                        {
                            double numerator = Math.Sin(x) * Math.Pow(x, i) + Math.Pow(f, j) * Math.Pow(y, j);
                            double denominator = (double)(i * j);
                            Z += numerator / denominator;
                        }
                    }

                    this.Title = "Ответ: " + Z.ToString("F2", culture);
                }
                else
                {
                    MessageBox.Show("Не выбрана формула.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка! Проверьте правильность введённых данных. Используйте текущую локаль для дробных чисел.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Title = "Ответ: Ошибка!";
            }
            catch (OverflowException)
            {
                MessageBox.Show("Число слишком большое или слишком маленькое.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Title = "Ответ: Ошибка!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Title = "Ответ: Ошибка!";
            }
        }

        private bool TryGetComboBoxDouble(ComboBox combo, out double value)
        {
            value = 0;
            if (combo == null) return false;
            if (combo.SelectedItem == null) return false;

            if (combo.SelectedItem is ComboBoxItem cbi)
            {
                var txt = cbi.Content?.ToString() ?? "";
                return double.TryParse(txt, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
            }
            var asString = combo.SelectedItem.ToString();
            return double.TryParse(asString, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        private void ShowInputError(string paramName, string formula)
        {
            MessageBox.Show($"Ошибка! Неверный формат параметра {paramName} ({formula}). Проверьте ввод.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            this.Title = "Ответ: Ошибка!";
        }

        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).ToggleTheme();
        }
    }
}
