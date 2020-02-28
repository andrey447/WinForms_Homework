using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHomework
{
    public partial class Form1 : Form
    {

        int x1, x2, y1, y2;
        int n = 0;
        DialogResult result;
        public Form1()
        {
            InitializeComponent();
            Form Form1 = new Form();
            this.StartPosition = FormStartPosition.CenterScreen;
            label4.Text = null;
            label6.Text = null;
        }

        public DialogResult ResumeMessage(string str, int d)
        {
            return MessageBox.Show(str, $"Р Е З Ю М Е   Среднее значение символов: {d}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> resume = new List<string> { "Меня зовут Андрей.", 
                                                     "Я хочу стать хорошим программистом.",
                                                     "В этом мне помогает Егор." };
            int n = 0, i = 0, d = 0;

            foreach(string str in resume)
            {
                i++;
                n += str.Length;
                d = n / i;
                ResumeMessage(str, d);
            }


        }

        private void tabPage2_MouseClick(object sender, MouseEventArgs e)
        {
            int x = tabPage2.Right;
            int y = tabPage2.Bottom;

            var relativePoint = this.PointToClient(Cursor.Position);
            int cursor_x = relativePoint.X;
            int cursor_y = relativePoint.Y;

            if (Control.ModifierKeys == Keys.Control && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Application.Exit();
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.Text = "Ширина: " + tabPage2.Width.ToString() + ",  Высота: " + tabPage2.Height.ToString();
            }
            else
            {
                if (cursor_x > 10 && cursor_x < (x - 10) && cursor_y > 10 && cursor_y < (y - 10))
                {
                    MessageBox.Show("Вы кликнули внутри прямоугольника");
                }
                else if (cursor_x == 10 || cursor_x == (x - 10) || cursor_y == 10 || cursor_y == (y - 10))
                {
                    MessageBox.Show("Вы кликнули по границе прямоугольника");
                }
                else MessageBox.Show("Вы кликнули снаружи прямоугольника");
            }
            
        }

        private void tabPage2_MouseMove(object sender, MouseEventArgs e)
        {
            Text = e.X + ",  " + e.Y;
        }

        private void tabPage3_MouseDown(object sender, MouseEventArgs e)
        {
            Text = e.X + ",  " + e.Y;
            x1 = e.X;
            y1 = e.Y;
        }

        List<Button> buttons = new List<Button>();

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar1.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int date = trackBar1.Value;
            int month = 0;
            int year = 0;
            int vek = 0;
            string dayOfWeek;

            if (radioButton1.Checked) month = 1;
            if (radioButton2.Checked) month = 4;
            if (radioButton3.Checked) month = 4;
            if (radioButton4.Checked) month = 0;
            if (radioButton5.Checked) month = 2;
            if (radioButton6.Checked) month = 5;
            if (radioButton7.Checked) month = 0;
            if (radioButton8.Checked) month = 3;
            if (radioButton9.Checked) month = 6;
            if (radioButton10.Checked) month = 1;
            if (radioButton11.Checked) month = 4;
            if (radioButton12.Checked) month = 6;

            year = int.Parse(textBox1.Text);

            if (year >= 1900 && year < 2000) vek = 0;
            if (year >= 2000 && year < 2100) vek = 6;
            if (year >= 2100 && year < 2200) vek = 4;

            int lastTwoNumbers = year % 100;

            year = (vek + lastTwoNumbers + lastTwoNumbers / 4) % 7;

            int day = (date + month + year) % 7;

            if (day == 0) dayOfWeek = "Суббота";
            else if (day == 1) dayOfWeek = "Воскресенье";
            else if (day == 2) dayOfWeek = "Понедельник";
            else if (day == 3) dayOfWeek = "Вторник";
            else if (day == 4) dayOfWeek = "Среда";
            else if (day == 5) dayOfWeek = "Четверг";
            else if (day == 6) dayOfWeek = "Пятница";
            else dayOfWeek = "???";

            label6.Text = dayOfWeek;
        }

        private void tabPage3_MouseUp(object sender, MouseEventArgs e)
        {
            Text = e.X + ",  " + e.Y;
            x2 = e.X;
            y2 = e.Y;

            if(x1 > x2)
            {
                int temp = x1;
                x1 = x2;
                x2 = temp;

            }

            if (y1 > y2)
            {
                int temp = y1;
                y1 = y2;
                y2 = temp;

            }

            if (Math.Abs(x1 - x2) >= 10 && Math.Abs(y1 - y2) >= 10)
            {
                n++;
                buttons.Add(new Button()
                {
                    Left = x1,
                    Top = y1,
                    Width = x2 - x1,
                    Height = y2 - y1,
                    Text = n.ToString()
                });

                buttons[n - 1].DoubleClick += ButtonDoubleClick;
                buttons[n - 1].Click += ButtonOnClick;
                
                tabPage3.Controls.Add(buttons[n-1]);
            }
            else MessageBox.Show("Слишком маленький размер кнопки!", "Внимание!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            {
                Button btn = (Button)sender;
                int x1 = btn.Left;
                int x2 = x1 + btn.Width;
                int y1 = btn.Top;
                int y2 = y1 + btn.Height;
                Text = "Площадь: " + (btn.Width * btn.Height) + ",  Координаты: " + btn.Left + ", " + btn.Top + ";  " + x2 + ", " + y2;
            }
        }

        private void ButtonDoubleClick(object sender, EventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            {
                Button btn = (Button)sender;
                btn.Dispose();
            }
        }
    }
}
