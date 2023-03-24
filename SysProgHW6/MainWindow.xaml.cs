using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SysProgHW6;

public partial class MainWindow : Window
{
    public ObservableCollection<string> guessWords { get; set; }
    Stopwatch stopwatch = new Stopwatch();
    StringBuilder text = new StringBuilder(), guessWord = new StringBuilder();
    bool flag2 = true, flag3 = true, flag4 = true, flag5 = true,
        flag6 = true, flag7 = true, flag8 = true, flag9 = true, checker = false;
    byte num2 = 0, num3 = 0, num4 = 0, num5 = 0, num6 = 0,
        num7 = 0, num8 = 0, num9 = 0;
    char letter = default;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        guessWords = new()
        {
            "salam",
            "necesen",
            "c#",
            "royal",
            "family",
            "rasim"
        };
        tb.IsReadOnly = true;
        tb.IsReadOnlyCaretVisible = true;
    }
    private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListBox? listBox = sender as ListBox;

        if (listBox != null)
        {
            var words = tb.Text.Split(' ');
            byte index = 0;

            foreach (char letter in words[words.Length - 1])
                if (letter == guessWord[index++])
                    continue;

            if (listBox.SelectedItem is not null)
            {
                string word = listBox.SelectedItem.ToString()!;
                tb.Text += word.Substring(index);
            }
            checker = true;
            listBox.Items.Clear();

            tb.Focus();
            tb.CaretIndex = tb.Text.Length;
        }
    }
    private async void tb_TextChanged(object sender, TextChangedEventArgs e)
    {
        lb.SelectionChanged -= lb_SelectionChanged;
        await Task.Run(() =>
        {
            Dispatcher.Invoke(() =>
            {
                if (tb.Text == string.Empty && lb.Items.Count > 0)
                    lb.Items.Clear();
            });
            if (!checker)
            {
                foreach (string word in guessWords)
                {
                    for (int i = 0; i < guessWord.Length; i++)
                    {
                        if (word.Length == i)
                            break;

                        if (guessWord[i] == word[i])
                        {
                            Dispatcher.Invoke(() =>
                            {
                                if (!lb.Items.Contains(word))
                                    lb.Items.Add(word);
                            });
                        }
                        else
                        {
                            Dispatcher.Invoke(() =>
                            {
                                lb.Items.Remove(word);
                            });
                            break;
                        }
                    }
                }
            }
        });
        lb.SelectionChanged += lb_SelectionChanged;
    }
    private void Button_Click_Clr(object sender, RoutedEventArgs e)
    {
        if (tb.Text.Length > 0)
            tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
        if (guessWord.Length > 0)
            guessWord.Remove(guessWord.Length - 1, 1);
        
        checker = false;
        //MessageBox.Show(guessWord.ToString());
        tb.Focus();
        tb.CaretIndex = tb.Text.Length;

        flag2 = true;
        flag3 = true;
        flag4 = true;
        flag5 = true;
        flag6 = true;
        flag7 = true;
        flag8 = true;
        flag9 = true;
    }
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        text.Append(tb.Text);

        if (num2 == 4 || flag2)
            num2 = 0;

        switch (num2)
        {
            case 0:
                letter = 'a';
                break;
            case 1:
                letter = 'b';
                break;
            case 2:
                letter = 'c';
                break;
            case 3:
                letter = '2';
                break;
        }

        if (stopwatch.IsRunning)
            stopwatch.Stop();
        else
            stopwatch.Start();

        TimeSpan elapsedTime = stopwatch.Elapsed;
        if (elapsedTime.TotalSeconds > 1)
            flag2 = true;

        if (flag2)
        {
            text.Append(letter);
            tb.Text = text.ToString();
            flag2 = false;
            flag3 = true;
            flag4 = true;
            flag5 = true;
            flag6 = true;
            flag7 = true;
            flag8 = true;
            flag9 = true;

            guessWord.Append(letter);
        }
        else
        {
            text[text.Length - 1] = letter;
            tb.Text = text.ToString();

            if (guessWord.Length > 0)
            {
                guessWord.Remove(guessWord.Length - 1, 1);
                guessWord.Append(letter);
            }
            else
                guessWord.Append(letter);
        }
        num2++;

        tb.Focus();
        tb.CaretIndex = tb.Text.Length;
        stopwatch.Reset();
        text.Clear();
        stopwatch.Start();
    }
    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        text.Append(tb.Text);

        if (num3 == 4 || flag3)
            num3 = 0;

        switch (num3)
        {
            case 0:
                letter = 'd';
                break;
            case 1:
                letter = 'e';
                break;
            case 2:
                letter = 'f';
                break;
            case 3:
                letter = '3';
                break;
        }

        if (stopwatch.IsRunning)
            stopwatch.Stop();
        else
            stopwatch.Start();

        TimeSpan elapsedTime = stopwatch.Elapsed;
        if (elapsedTime.TotalSeconds > 1)
            flag3 = true;

        if (flag3)
        {
            text.Append(letter);
            tb.Text = text.ToString();
            flag3 = false;
            flag2 = true;
            flag4 = true;
            flag5 = true;
            flag6 = true;
            flag7 = true;
            flag8 = true;
            flag9 = true;

            guessWord.Append(letter);
        }
        else
        {
            text[text.Length - 1] = letter;
            tb.Text = text.ToString();

            if (guessWord.Length > 0)
            {
                guessWord.Remove(guessWord.Length - 1, 1);
                guessWord.Append(letter);
            }
            else
                guessWord.Append(letter);
        }
        num3++;

        tb.Focus();
        tb.CaretIndex = tb.Text.Length;

        stopwatch.Reset();
        text.Clear();
        stopwatch.Start();
    }
    private void Button_Click_4(object sender, RoutedEventArgs e)
    {
        text.Append(tb.Text);

        if (num4 == 4 || flag4)
            num4 = 0;

        switch (num4)
        {
            case 0:
                letter = 'g';
                break;
            case 1:
                letter = 'h';
                break;
            case 2:
                letter = 'i';
                break;
            case 3:
                letter = '4';
                break;
        }

        if (stopwatch.IsRunning)
            stopwatch.Stop();
        else
            stopwatch.Start();

        TimeSpan elapsedTime = stopwatch.Elapsed;
        if (elapsedTime.TotalSeconds > 1)
            flag4 = true;

        if (flag4)
        {
            text.Append(letter);
            tb.Text = text.ToString();
            flag4 = false;
            flag2 = true;
            flag3 = true;
            flag5 = true;
            flag6 = true;
            flag7 = true;
            flag8 = true;
            flag9 = true;

            guessWord.Append(letter);
        }
        else
        {
            text[text.Length - 1] = letter;
            tb.Text = text.ToString();

            if (guessWord.Length > 0)
            {
                guessWord.Remove(guessWord.Length - 1, 1);
                guessWord.Append(letter);
            }
            else
                guessWord.Append(letter);
        }
        num4++;

        tb.Focus();
        tb.CaretIndex = tb.Text.Length;
        stopwatch.Reset();
        text.Clear();
        stopwatch.Start();
    }
    private void Button_Click_5(object sender, RoutedEventArgs e)
    {
        text.Append(tb.Text);

        if (num5 == 4 || flag5)
            num5 = 0;

        switch (num5)
        {
            case 0:
                letter = 'j';
                break;
            case 1:
                letter = 'k';
                break;
            case 2:
                letter = 'l';
                break;
            case 3:
                letter = '5';
                break;
        }

        if (stopwatch.IsRunning)
            stopwatch.Stop();
        else
            stopwatch.Start();

        TimeSpan elapsedTime = stopwatch.Elapsed;
        if (elapsedTime.TotalSeconds > 1)
            flag5 = true;

        if (flag5)
        {
            text.Append(letter);
            tb.Text = text.ToString();
            flag5 = false;
            flag2 = true;
            flag3 = true;
            flag4 = true;
            flag6 = true;
            flag7 = true;
            flag8 = true;
            flag9 = true;

            guessWord.Append(letter);
        }
        else
        {
            text[text.Length - 1] = letter;
            tb.Text = text.ToString();

            if (guessWord.Length > 0)
            {
                guessWord.Remove(guessWord.Length - 1, 1);
                guessWord.Append(letter);
            }
            else
                guessWord.Append(letter);
        }
        num5++;

        tb.Focus();
        tb.CaretIndex = tb.Text.Length;
        stopwatch.Reset();
        text.Clear();
        stopwatch.Start();
    }
    private void Button_Click_6(object sender, RoutedEventArgs e)
    {
        text.Append(tb.Text);

        if (num6 == 4 || flag6)
            num6 = 0;

        switch (num6)
        {
            case 0:
                letter = 'm';
                break;
            case 1:
                letter = 'n';
                break;
            case 2:
                letter = 'o';
                break;
            case 3:
                letter = '6';
                break;
        }

        if (stopwatch.IsRunning)
            stopwatch.Stop();
        else
            stopwatch.Start();

        TimeSpan elapsedTime = stopwatch.Elapsed;
        if (elapsedTime.TotalSeconds > 1)
            flag6 = true;

        if (flag6)
        {
            text.Append(letter);
            tb.Text = text.ToString();
            flag6 = false;
            flag2 = true;
            flag3 = true;
            flag4 = true;
            flag5 = true;
            flag7 = true;
            flag8 = true;
            flag9 = true;

            guessWord.Append(letter);
        }
        else
        {
            text[text.Length - 1] = letter;
            tb.Text = text.ToString();

            if (guessWord.Length > 0)
            {
                guessWord.Remove(guessWord.Length - 1, 1);
                guessWord.Append(letter);
            }
            else
                guessWord.Append(letter);
        }
        num6++;

        tb.Focus();
        tb.CaretIndex = tb.Text.Length;
        stopwatch.Reset();
        text.Clear();
        stopwatch.Start();
    }
    private void Button_Click_7(object sender, RoutedEventArgs e)
    {
        text.Append(tb.Text);

        if (num7 == 5 || flag7)
            num7 = 0;

        switch (num7)
        {
            case 0:
                letter = 'p';
                break;
            case 1:
                letter = 'q';
                break;
            case 2:
                letter = 'r';
                break;
            case 3:
                letter = 's';
                break;
            case 4:
                letter = '5';
                break;
        }

        if (stopwatch.IsRunning)
            stopwatch.Stop();
        else
            stopwatch.Start();

        TimeSpan elapsedTime = stopwatch.Elapsed;
        if (elapsedTime.TotalSeconds > 1)
            flag7 = true;

        if (flag7)
        {
            text.Append(letter);
            tb.Text = text.ToString();
            flag7 = false;
            flag2 = true;
            flag3 = true;
            flag4 = true;
            flag5 = true;
            flag6 = true;
            flag8 = true;
            flag9 = true;

            guessWord.Append(letter);
        }
        else
        {
            text[text.Length - 1] = letter;
            tb.Text = text.ToString();

            if (guessWord.Length > 0)
            {
                guessWord.Remove(guessWord.Length - 1, 1);
                guessWord.Append(letter);
            }
            else
                guessWord.Append(letter);
        }
        num7++;

        tb.Focus();
        tb.CaretIndex = tb.Text.Length;
        stopwatch.Reset();
        text.Clear();
        stopwatch.Start();
    }
    private void Button_Click_8(object sender, RoutedEventArgs e)
    {
        text.Append(tb.Text);

        if (num8 == 4 || flag8)
            num8 = 0;

        switch (num8)
        {
            case 0:
                letter = 't';
                break;
            case 1:
                letter = 'u';
                break;
            case 2:
                letter = 'v';
                break;
            case 3:
                letter = '8';
                break;
        }

        if (stopwatch.IsRunning)
            stopwatch.Stop();
        else
            stopwatch.Start();

        TimeSpan elapsedTime = stopwatch.Elapsed;
        if (elapsedTime.TotalSeconds > 1)
            flag8 = true;

        if (flag8)
        {
            text.Append(letter);
            tb.Text = text.ToString();
            flag8 = false;
            flag2 = true;
            flag3 = true;
            flag4 = true;
            flag5 = true;
            flag6 = true;
            flag7 = true;
            flag9 = true;

            guessWord.Append(letter);
        }
        else
        {
            text[text.Length - 1] = letter;
            tb.Text = text.ToString();

            if (guessWord.Length > 0)
            {
                guessWord.Remove(guessWord.Length - 1, 1);
                guessWord.Append(letter);
            }
            else
                guessWord.Append(letter);
        }
        num8++;

        tb.Focus();
        tb.CaretIndex = tb.Text.Length;
        stopwatch.Reset();
        text.Clear();
        stopwatch.Start();
    }
    private void Button_Click_9(object sender, RoutedEventArgs e)
    {
        text.Append(tb.Text);

        if (num9 == 5 || flag9)
            num9 = 0;

        switch (num9)
        {
            case 0:
                letter = 'w';
                break;
            case 1:
                letter = 'y';
                break;
            case 2:
                letter = 'z';
                break;
            case 3:
                letter = 'x';
                break;
            case 4:
                letter = '9';
                break;
        }

        if (stopwatch.IsRunning)
            stopwatch.Stop();
        else
            stopwatch.Start();

        TimeSpan elapsedTime = stopwatch.Elapsed;
        if (elapsedTime.TotalSeconds > 1)
            flag9 = true;

        if (flag9)
        {
            text.Append(letter);
            tb.Text = text.ToString();
            flag9 = false;
            flag2 = true;
            flag3 = true;
            flag4 = true;
            flag5 = true;
            flag6 = true;
            flag7 = true;
            flag8 = true;

            guessWord.Append(letter);
        }
        else
        {
            text[text.Length - 1] = letter;
            tb.Text = text.ToString();

            if (guessWord.Length > 0)
            {
                guessWord.Remove(guessWord.Length - 1, 1);
                guessWord.Append(letter);
            }
            else
                guessWord.Append(letter);
        }
        num9++;

        tb.Focus();
        tb.CaretIndex = tb.Text.Length;
        stopwatch.Reset();
        text.Clear();
        stopwatch.Start();
    }
    private void btnStar_Click(object sender, RoutedEventArgs e)
    {
        text.Append(tb.Text);
        text.Append('*');

        flag2 = true;
        flag3 = true;
        flag4 = true;
        flag5 = true;
        flag6 = true;
        flag7 = true;
        flag8 = true;
        flag9 = true;

        guessWord.Append('*');
        tb.Text = text.ToString();
        text.Clear();
        tb.Focus();
        tb.CaretIndex = tb.Text.Length;
    }
    private void btnSharp_Click(object sender, RoutedEventArgs e)
    {
        text.Append(tb.Text);
        text.Append('#');

        flag2 = true;
        flag3 = true;
        flag4 = true;
        flag5 = true;
        flag6 = true;
        flag7 = true;
        flag8 = true;
        flag9 = true;

        guessWord.Append('#');
        tb.Text = text.ToString();
        text.Clear();
        tb.Focus();
        tb.CaretIndex = tb.Text.Length;
    }
    private async void btn1_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            text.Append(tb.Text);
            text.Append('1');
            guessWord.Append('1');
            tb.Text = text.ToString();
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                stopwatch.Reset();
                flag2 = true;
                flag3 = true;
                flag4 = true;
                flag5 = true;
                flag6 = true;
                flag7 = true;
                flag8 = true;
                flag9 = true;
            }
            await Task.Run(() =>
            {
                stopwatch.Start();
                while (true)
                {
                    if (stopwatch.Elapsed.TotalSeconds > 1.5)
                    {
                        text[text.Length - 1] = '.';
                        Dispatcher.Invoke(() =>
                        {
                            tb.Text = text.ToString();
                        });
                        if (guessWord.Length > 0)
                        {
                            guessWord.Remove(guessWord.Length - 1, 1);
                            guessWord.Append('.');
                        }
                        break;
                    }

                    if (e.ButtonState == MouseButtonState.Pressed)
                        continue;
                    else if (e.ButtonState == MouseButtonState.Released)
                        break;
                }
            });

            stopwatch.Stop();
            stopwatch.Reset();
            text.Clear();
        }
    }
    private async void btn0_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            text.Append(tb.Text);
            text.Append('0');
            guessWord.Append('0');
            tb.Text = text.ToString();
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                stopwatch.Reset();
                flag2 = true;
                flag3 = true;
                flag4 = true;
                flag5 = true;
                flag6 = true;
                flag7 = true;
                flag8 = true;
                flag9 = true;
            }
            await Task.Run(() =>
            {
                stopwatch.Start();
                while (true)
                {
                    if (stopwatch.Elapsed.TotalSeconds > 1.5)
                    {
                        text[text.Length - 1] = ' ';
                        Dispatcher.Invoke(() =>
                        {
                            tb.Text = text.ToString();
                        });
                        guessWord.Clear();
                        checker = false;
                        break;
                    }

                    if (e.ButtonState == MouseButtonState.Pressed)
                        continue;
                    else if (e.ButtonState == MouseButtonState.Released)
                        break;
                }
            });

            stopwatch.Stop();
            stopwatch.Reset();
            text.Clear();
            tb.Focus();
            tb.CaretIndex = tb.Text.Length;
        }
    }
}
