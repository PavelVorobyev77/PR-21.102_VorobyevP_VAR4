using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PR_21._102_VorobyevP_VAR4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            string sentence = sentenceTextBox.Text.Trim();

            // Проверка на пустую строку или пробелы
            if (string.IsNullOrWhiteSpace(sentence))
            {
                resultTextBlock.Text = "Введите предложение";
                return;
            }

            try
            {
                StringBuilder convertedSentence = new StringBuilder();
                bool isSpace = true;

                for (int i = 0; i < sentence.Length; i++)
                {
                    char c = sentence[i];

                    if (char.IsWhiteSpace(c))
                    {
                        if (!isSpace)
                        {
                            convertedSentence.Append(" это_пробел ");
                            isSpace = true;
                        }
                    }
                    else if (char.IsLetter(c))
                    {
                        if (isSpace || i == 0)
                        {
                            convertedSentence.Append(char.ToUpper(c));
                        }
                        else
                        {
                            convertedSentence.Append(char.ToLower(c));
                        }

                        isSpace = false;

                        // Проверяем следующий символ
                        if (i < sentence.Length - 1)
                        {
                            char nextChar = sentence[i + 1];
                            if (char.IsLetter(nextChar))
                            {
                                // Пропускаем промежуточные символы внутри слова
                                continue;
                            }
                        }

                        // Проверяем текущую букву и последнюю в слове
                        if (i > 0 && i < sentence.Length - 1)
                        {
                            char lastChar = convertedSentence[convertedSentence.Length - 1];
                            if (char.IsLower(lastChar))
                            {
                                convertedSentence.Remove(convertedSentence.Length - 1, 1);
                                convertedSentence.Append(char.ToUpper(lastChar));
                            }
                        }
                    }
                }

                resultTextBlock.Text = convertedSentence.ToString();
            }
            catch (Exception ex)
            {
                resultTextBlock.Text = "Ошибка: " + ex.Message;
            }
        }
    }
}


