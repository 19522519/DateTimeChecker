using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimeChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDay.Text = "";
            txtMonth.Text = "";
            txtYear.Text = "";
        }

        public Boolean isLeapYear(int year)
        {
            if (year % 4 == 0 && year % 100 != 0)
                return true;

            else if(year % 400 == 0)
                return true;

            return false;
        }

        public int checkDayInMonth(int month, int year)
        {
            switch(month)
            {
                case 1:
                    return 31;

                case 3:
                    return 31;

                case 5:
                    return 31;

                case 7:
                    return 31;

                case 8:
                    return 31;

                case 10:
                    return 31;

                case 12:
                    return 31;

                case 4:
                    return 30;

                case 6:
                    return 30;

                case 9:
                    return 30;

                case 11:
                    return 30;

                default:
                    if (isLeapYear(year))
                        return 29;
                    return 28;

            }
        }

        public bool isNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public Boolean isNumbers(String day, String month, String year)
        {
            if (!isNumber(day) || !isNumber(month) || !isNumber(year))
                return false;
            return true;
        }

        public Boolean isNull(String day, String month, String year)
        {
            if (String.IsNullOrEmpty(day) || String.IsNullOrEmpty(month) || String.IsNullOrEmpty(year))
                return true; //Null -> true
            return false;
        }

        public Boolean isOutOfRange(int day, int month, int year)
        {
            if (day < 1 || day > 31)
                return false;
            else if (month < 1 || month > 12)
                return false;
            else if (year < 1000 || year > 3000)
                return false;
            return true;
        }

        public Boolean isCorrectDateTime(int day, int month, int year)
        {
            if (day <= checkDayInMonth(month, year))
                return true;
            return false;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!isNumber(txtDay.Text.ToString()))
                MessageBox.Show("Input data for Day is incorrect format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (!isNumber(txtMonth.Text.ToString()))
                MessageBox.Show("Input data for Month is incorrect format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (!isNumber(txtYear.Text.ToString()))
                MessageBox.Show("Input data for Year is incorrect format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            int day, month, year;

            try
            {
                day = int.Parse(txtDay.Text.ToString());
                month = int.Parse(txtMonth.Text.ToString());
                year = int.Parse(txtYear.Text);

                if (day < 1 || day > 31)
                    MessageBox.Show("Input data for Day is out of range!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else if (month < 1 || month > 12)
                    MessageBox.Show("Input data for Month is out of range!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else if (year < 1000 || year > 3000)
                    MessageBox.Show("Input data for Year is out of range!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (day <= checkDayInMonth(month, year))
                        MessageBox.Show("dd/mm/yyyy is correct date time!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("dd/mm/yyyy is NOT correct date time!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                if (String.IsNullOrEmpty(txtDay.Text.ToString()))
                    MessageBox.Show("Input data for Day is incorrect format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (String.IsNullOrEmpty(txtMonth.Text.ToString()))
                    MessageBox.Show("Input data for Month is incorrect format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (String.IsNullOrEmpty(txtYear.Text.ToString()))
                    MessageBox.Show("Input data for Year is incorrect format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you sure to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
            base.OnClosing(e);
        }
    }
}
