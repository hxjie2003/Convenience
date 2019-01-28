using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;

namespace ETong.Controls.WPF
{
    /// <summary>
    /// 文本框的事件的一些共用方法
    /// </summary>
    public class TextBoxEventProcess
    {
        /// <summary>
        /// keydown事件，只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBoxKeyDownNumberEvent(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Decimal)
            {
                if (txt.Text.Contains(".") || e.Key == Key.Decimal)
                {
                    e.Handled = true;

                    return;
                }

                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                e.Key == Key.OemPeriod) &&
                e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            {
                if (txt.Text.Contains(".") || e.Key == Key.OemPeriod)
                {
                    e.Handled = true;

                    return;
                }
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 在文本框的keyup事件中，使手机号按344长度插入空格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBoxKeyUpPhoneEvent(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            int len = tb.SelectionStart;
            if (len >= tb.Text.Length)
                len++;
            string text = tb.Text.Replace(" ", "");
            if (text.Length > 3)
            {
                text = text.Insert(3, " ");
                if (len == 4)
                    len++;
            }
            if (text.Length > 8)
            {
                text = text.Insert(8, " ");
                if (len == 9)
                    len++;
            }

            tb.Text = text;
            tb.Select(len, 0);
        }

    }
}
