using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grubbs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool flag1;
        bool flag2;
        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxinput.Focus();
        }
        private double[] collectdata()
        {
            flag1 = false;
            string[] measureresults1 = textBoxinput.Text.Trim().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            double[] measureresults2 = new double[measureresults1.Length];
            if (measureresults1.Length < 3)
            {
                MessageBox.Show("数据不能少于3个！");
                throw new ProgramStoppedException();
            }
            for (int i = 0; i < measureresults1.Length; i++)
            {
                measureresults2[i] = double.Parse(measureresults1[i]);
            }
            return measureresults2;
        }
        private void sort(double[] array)
        {
            double temp;
            for (int j = 0; j < array.Length - 1; j++)
            {
                for (int i = 0; i < array.Length - j - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }

                }
            }
            //return array;
        }
        public class ProgramStoppedException : Exception
        {
            public ProgramStoppedException() : base("程序已停止")
            {
            }

            public ProgramStoppedException(string message) : base(message)
            {
            }

            public ProgramStoppedException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
        private double average(double[] array)
        {
            double sum = 0;
            double average;
            foreach (double arr in array)
                sum += arr;
            average = sum / array.Length;
            return average;
        }
        private double SD(double[] array)
        {
            double temp = 0;
            double ave = average(array);
            double SD;
            foreach (double arr in array)
            {
                temp += Math.Pow((arr - ave), 2);
            }
            SD = Math.Sqrt(temp / array.Length);
            return SD;
        }
        private (double, double, double) compare(double[] array)
        {
            double bigger = 0;
            double markeddata1 = 0;
            double markeddata2 = 0;
            double max;
            double min;
            double ave = average(array);
            sort(array);
            max = Math.Abs(array[array.Length - 1] - ave);
            min = Math.Abs(array[0] - ave);
            if (max > min)
            {
                bigger = max;
                markeddata2 = array[array.Length - 1];
            }
            if (max == min)
            {
                bigger = max;
                markeddata1 = array[0];
                markeddata2 = array[array.Length - 1];
            }
            if (max < min)
            {
                bigger = min;
                markeddata1 = array[0];
            }
            return (bigger, markeddata1, markeddata2);
        }
        private string[] removeandshow(double markeddata1, double markeddata2, double[] array)
        {
            flag1 = false;
            if (markeddata1 != 0 && markeddata2 != 0)
                MessageBox.Show(markeddata1 + "是离群值" + "\n" + markeddata2 + "是离群值");
            if (markeddata1 != 0 && markeddata2 == 0)
                MessageBox.Show(markeddata1 + "是离群值");
            if (markeddata1 == 0 && markeddata2 != 0)
                MessageBox.Show(markeddata2 + "是离群值");
            double[] newarray = new double[array.Length];
            string[] printarray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if ((array[i] == markeddata1) || (array[i] == markeddata2))
                    newarray[i] = 0;
                else
                    newarray[i] = array[i];
            }
            for (int i = 0; i < array.Length; i++)
                if (newarray[i] == 0)
                    printarray[i] = null;
                else
                    printarray[i] = newarray[i].ToString();
            textBoxoutput.Text = string.Join("\r\n", printarray);
            return printarray;
        }
        private void show(double[] array)
        {
            flag1 = true;
            MessageBox.Show("没有离群值");
            sort(array);
            textBoxoutput.Text = string.Join("\r\n", array);
        }
        private void Grubbs(double[] array)
        {
            double bigger = compare(array).Item1;
            double markeddata1 = compare(array).Item2;
            double markeddata2 = compare(array).Item3;
            double finresult;
            finresult = compare(array).Item1 / SD(array);
            switch (array.Length)
            {
                case 3: if (finresult > 1.153 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 4: if (finresult > 1.463 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 5: if (finresult > 1.672 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 6: if (finresult > 1.822 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 7: if (finresult > 1.938 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 8: if (finresult > 2.032 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 9: if (finresult > 2.110 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 10: if (finresult > 2.176 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 11: if (finresult > 2.234 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 12: if (finresult > 2.285 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 13: if (finresult > 2.331 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 14: if (finresult > 2.371 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 15: if (finresult > 2.409 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 16: if (finresult > 2.443 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 17: if (finresult > 2.475 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 18: if (finresult > 2.504 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 19: if (finresult > 2.532 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 20: if (finresult > 2.557 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 21: if (finresult > 2.580 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 22: if (finresult > 2.603 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 23: if (finresult > 2.624 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 24: if (finresult > 2.644 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 25: if (finresult > 2.663 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 26: if (finresult > 2.681 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 27: if (finresult > 2.698 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 28: if (finresult > 2.714 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 29: if (finresult > 2.730 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 30: if (finresult > 2.745 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 31: if (finresult > 2.759 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 32: if (finresult > 2.773 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 33: if (finresult > 2.786 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 34: if (finresult > 2.799 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 35: if (finresult > 2.811 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 36: if (finresult > 2.823 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 37: if (finresult > 2.835 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 38: if (finresult > 2.846 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 39: if (finresult > 2.857 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 40: if (finresult > 2.866 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 41: if (finresult > 2.877 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 42: if (finresult > 2.887 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 43: if (finresult > 2.896 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 44: if (finresult > 2.905 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 45: if (finresult > 2.914 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 46: if (finresult > 2.923 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 47: if (finresult > 2.931 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 48: if (finresult > 2.940 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 49: if (finresult > 2.948 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
                case 50: if (finresult > 2.956 && flag2) { removeandshow(markeddata1, markeddata2, array); } else show(array); break;
            }
        }
        private void doublejudge(double[] array)
        {
            double markeddata1 = compare(array).Item2;
            double markeddata2 = compare(array).Item3;
            double ave = average(array);
            if (markeddata1 == 0 && markeddata2 != 0)
            {
                if ((Math.Abs(markeddata2 - ave) / ave) <= 0.05)
                    flag2 = false;
                else
                    flag2 = true;
            }
            if (markeddata1 != 0 && markeddata2 == 0)
            {
                if ((Math.Abs(markeddata1 - ave) / ave) <= 0.05)
                    flag2 = false;
                else
                    flag2 = true;
            }
            if (markeddata1 != 0 && markeddata2 != 0)
            {
                if (((Math.Abs(markeddata1 - ave) / ave) <= 0.05) || ((Math.Abs(markeddata2 - ave) / ave) <= 0.05))
                    flag2 = false;
                else
                    flag2 = true;
            }
        }
        private void calculate()
        {
            double[] data = collectdata();
            sort(data);
            doublejudge(data);
            Grubbs(data);
            textBoxinput.Text = textBoxoutput.Text;
        }
        private void buttoncalculate_Click(object sender, EventArgs e)
        {
            do calculate();
            while (!flag1);
        }
    }
}
