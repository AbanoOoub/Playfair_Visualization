using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualization
{
    public partial class Form1 : Form
    {
        public static string[,] matrix;
        public static string[] dividedTextArr;
        public static Button[,] btns;
        public string cipherText = "";
        public string plainText = "";

        public Form1()
        {
            InitializeComponent();
            btns = new Button[5,5];
            matrix = new string[5, 5];

        }
        private void initializeVisualization()
        {
            int row = 0, col = 0;
            foreach (Button btn in groupBox1.Controls.OfType<Button>().OrderBy(c => c.Name))
            {
                btns[row, col] = btn;
                btns[row, col].Text = matrix[row, col];
                col++;

                if (col == 5)
                {
                    row++;
                    col = 0;
                }
                else if (row == 5)
                {
                    break;
                }

            }
        }
        private async void Decrypt(string cipherText)
        {
            plainText = "";
            cipherText = cipherText.ToLower();
           
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            bool l1 = false, l2 = false;

            for (int i = 0; i < dividedTextArr.Length; i++)
            {
                string s1 = dividedTextArr[i][0].ToString();
                string s2 = dividedTextArr[i][1].ToString();

                for (int row = 0; row < 5; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        if (l1 == false || l2 == false)
                        {
                            if (s1 == matrix[row, col])
                            {
                                x1 = row;
                                y1 = col;
                                l1 = true;
                                btns[x1, y1].BackColor = Color.Red;
                                await Task.Delay(TimeSpan.FromSeconds(2));
                            }
                            else if (s2 == matrix[row, col])
                            {
                                x2 = row;
                                y2 = col;
                                l2 = true;
                                btns[x2, y2].BackColor = Color.Red;
                                await Task.Delay(TimeSpan.FromSeconds(2));
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (l1 && l2)
                    {
                        l1 = false;
                        l2 = false;

                        break;
                    }
                }
                string c1, c2;
                //same row
                if (x1 == x2)
                {
                    if (y1 == 0)
                    {
                        c1 = matrix[x1, 4];
                        c2 = matrix[x2, y2 - 1];
                        btns[x1, 4].BackColor = Color.Green;
                        btns[x2, y2 - 1].BackColor = Color.Green;
                        await Task.Delay(TimeSpan.FromSeconds(2));
                    }
                    else if (y2 == 0)
                    {
                        c1 = matrix[x1, y1 - 1];
                        c2 = matrix[x2, 4];
                        btns[x1, y1 - 1].BackColor = Color.Green;
                        btns[x2, 4].BackColor = Color.Green;
                        await Task.Delay(TimeSpan.FromSeconds(2));
                    }
                    else
                    {
                        c1 = matrix[x1, y1 - 1];
                        c2 = matrix[x2, y2 - 1];
                        btns[x1, y1 - 1].BackColor = Color.Green;
                        btns[x2, y2 - 1].BackColor = Color.Green;
                        await Task.Delay(TimeSpan.FromSeconds(2));
                    }
                }
                //same col
                else if (y1 == y2)
                {
                    if (x1 == 0)
                    {
                        c1 = matrix[4, y1];
                        c2 = matrix[x2 - 1, y2];
                        btns[4, y1].BackColor = Color.Green;
                        btns[x2 - 1, y2].BackColor = Color.Green;
                        await Task.Delay(TimeSpan.FromSeconds(2));
                    }
                    else if (x2 == 0)
                    {
                        c1 = matrix[x1 - 1, y1];
                        c2 = matrix[4, y2];
                        btns[x1 - 1, y1].BackColor = Color.Green;
                        btns[4, y2].BackColor = Color.Green;
                        await Task.Delay(TimeSpan.FromSeconds(2));
                    }
                    else
                    {
                        c1 = matrix[x1 - 1, y1];
                        c2 = matrix[x2 - 1, y2];
                        btns[x1 - 1, y1].BackColor = Color.Green;
                        btns[x2 - 1, y2].BackColor = Color.Green;
                        await Task.Delay(TimeSpan.FromSeconds(2));
                    }
                }
                else
                {
                    c1 = matrix[x1, y2];
                    c2 = matrix[x2, y1];
                    btns[x1, y2].BackColor = Color.Green;
                    btns[x2, y1].BackColor = Color.Green;
                    await Task.Delay(TimeSpan.FromSeconds(2));
                }

                plainText += (c1 + c2).ToString();
                Clear();
                x1 = 0;
                x2 = 0;
                y1 = 0;
                y2 = 0;
            }

            if (plainText[plainText.Length - 1] == 'x')
            {

                plainText = plainText.Remove(plainText.Length - 1, 1);
            }

            for (int i = 0; i < plainText.Length - 2; i++)
            {

                if (plainText[i] == plainText[i + 2] && plainText[i + 1] == 'x')
                {

                    plainText = plainText.Remove(i + 1, 1);

                }
                else i++;
            }

            Realplain_txtbx.Text = plainText;
        }

        private async void Encrypt(string plainText)
        {
            cipherText = "";
            
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            bool l1 = false, l2 = false;

            for (int i = 0; dividedTextArr[i] != null; i++)
            {
                string s1 = dividedTextArr[i][0].ToString();
                string s2 = dividedTextArr[i][1].ToString();
                int row;
                int col;
                for (row = 0; row < 5; row++)
                {
                    for (col = 0; col < 5; col++)
                    {
                        if (l1 == false || l2 == false)
                        {
                            if (s1 == matrix[row, col])
                            {
                                x1 = row;
                                y1 = col;
                                l1 = true;
                                btns[x1, y1].BackColor = Color.Red;
                                await Task.Delay(TimeSpan.FromSeconds(2));

                            }
                            else if (s2 == matrix[row, col])
                            {
                                x2 = row;
                                y2 = col;
                                l2 = true;
                                btns[x2, y2].BackColor = Color.Red;
                                await Task.Delay(TimeSpan.FromSeconds(2));

                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (l1 && l2)
                    {
                        l1 = false;
                        l2 = false;

                        break;
                    }
                }
                string c1, c2;
                //same row
                if (x1 == x2)
                {
                    if (y1 == 4)
                    {
                        c1 = matrix[x1, 0];
                        c2 = matrix[x2, y2 + 1];
                        btns[x1, 0].BackColor = Color.Green;
                        btns[x2, y2+1].BackColor = Color.Green;
                        await Task.Delay(TimeSpan.FromSeconds(2));

                    }
                    else if (y2 == 4)
                    {
                        c1 = matrix[x1, y1 + 1];
                        c2 = matrix[x2, 0];
                        btns[x1, y1 + 1].BackColor = Color.Green;
                        btns[x2, 0].BackColor = Color.Green;
                        await Task.Delay(TimeSpan.FromSeconds(2));

                    }
                    else
                    {
                        c1 = matrix[x1, y1 + 1];
                        c2 = matrix[x2, y2 + 1];
                        btns[x1, y1 + 1].BackColor = Color.Green;
                        btns[x2, y2 + 1].BackColor = Color.Green;
                        await Task.Delay(TimeSpan.FromSeconds(2));

                    }
                }
                //same col
                else if (y1 == y2)
                {
                    if (x1 == 4)
                    {
                        c1 = matrix[0, y1];
                        c2 = matrix[x2 + 1, y2];
                        btns[0, y1].BackColor = Color.Green;
                        btns[x2 + 1, y2].BackColor = Color.Green;
                        await Task.Delay(TimeSpan.FromSeconds(2));

                    }
                    else if (x2 == 4)
                    {
                        c1 = matrix[x1 + 1, y1];
                        c2 = matrix[0, y2];
                        btns[x1 + 1, y1].BackColor = Color.Green;
                        btns[0, y2].BackColor = Color.Green;
                        await Task.Delay(TimeSpan.FromSeconds(2));

                    }
                    else
                    {
                        c1 = matrix[x1 + 1, y1];
                        c2 = matrix[x2 + 1, y2];
                        btns[x1 + 1, y1].BackColor = Color.Green;
                        btns[x2 + 1, y2].BackColor = Color.Green;
                        await Task.Delay(TimeSpan.FromSeconds(2));

                    }
                }
                else
                {
                    c1 = matrix[x1, y2];
                    c2 = matrix[x2, y1];
                    btns[x1, y2].BackColor = Color.Green;
                    btns[x2, y1].BackColor = Color.Green;
                    await Task.Delay(TimeSpan.FromSeconds(2));

                }
                string v = (c1 + c2).ToString();
                dectepted_txtbx.Text += v;
                
                Clear();
                x1 = 0;
                x2 = 0;
                y1 = 0;
                y2 = 0;
            }
        }

        private void Clear()
        {
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    btns[i, j].BackColor = Control.DefaultBackColor;
                }
            }

        }

        private void generateMatrix(string key)
        {
            string alphabets = "abcdefghiklmnopqrstuvwxyz";
            string inMatrix = "";
            int cntrKey = 0;
            int cntrAlpha = 0;

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (cntrKey != key.Length)         //key not finished
                    {
                        if (!(inMatrix.Contains(key[cntrKey])))
                        {
                            if (key[cntrKey] == 'j')
                            {
                                matrix[row, col] = "i";
                                inMatrix += "j";
                                inMatrix += "i";
                                cntrKey++;
                            }
                            else
                            {
                                matrix[row, col] = key[cntrKey].ToString();
                                inMatrix += key[cntrKey].ToString();
                                cntrKey++;
                            }
                        }
                        else
                        {
                            cntrKey++;
                            col--;
                        }
                    }
                    else  // key is finished
                    {
                        if (!(inMatrix.Contains(alphabets[cntrAlpha])))
                        {
                            matrix[row, col] = alphabets[cntrAlpha].ToString();
                            cntrAlpha++;
                        }
                        else
                        {
                            cntrAlpha++;
                            col--;
                        }
                    }

                }
            }

        }
        private void dividePlainText(string plainText)
        {
            plainText = plainText.Replace('j', 'i');
            int cntr1Plain = 0;
            int cntr2Plain = 1;
            int cntr = 0;
            int plainSize = plainText.Length;

            dividedTextArr = new string[plainSize];
            while (true)
            {
                if (cntr2Plain >= plainSize)
                {
                    if (cntr1Plain == (plainSize - 1))
                    {
                        dividedTextArr[cntr] = (plainText[cntr1Plain].ToString() + "x").ToString();
                        break;
                    }
                    else
                        break;
                }
                else if (plainText[cntr1Plain] != plainText[cntr2Plain])
                {
                    dividedTextArr[cntr] = (plainText[cntr1Plain].ToString() + plainText[cntr2Plain].ToString()).ToString();
                    cntr++;

                    cntr1Plain = cntr2Plain + 1;
                    cntr2Plain = cntr1Plain + 1;
                }
                else if (plainText[cntr1Plain] == plainText[cntr2Plain])
                {
                    dividedTextArr[cntr] = (plainText[cntr1Plain].ToString() + "x").ToString();
                    cntr++;

                    cntr1Plain = cntr2Plain;
                    cntr2Plain = cntr1Plain + 1;
                }
            }
        }
        private void divideCipherText(string cipherText)
        {
            cipherText = cipherText.Replace('j', 'i');
            int cntr = 0;

            dividedTextArr = new string[(cipherText.Length / 2)];

            for (int i = 0; i < cipherText.Length; i += 2)
            {
                dividedTextArr[cntr] = (cipherText[i].ToString() + cipherText[i + 1].ToString()).ToString();
                cntr++;

            }
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == Encrept)
            {
                string key = Enckey_txtbx.Text.ToLower();
                string plain = Encplain_txtbx.Text.ToLower();
                if(!(key.Equals("") && plain.Equals("")))
                {
                    dectepted_txtbx.Text = "";
                    generateMatrix(key);
                    initializeVisualization();
                    dividePlainText(plain);
                    Encrypt(plain);
                }
                else
                {
                    MessageBox.Show("please, fill key and plain");
                }
            }
            else if(tabControl1.SelectedTab == Decrept)
            {
                string key = Deckey_textbx.Text.ToLower();
                string cipher = cipher_txtbx.Text.ToLower();
                if (!(key.Equals("") && cipher.Equals("")))
                {
                    Realplain_txtbx.Text = "";
                    generateMatrix(key);
                    initializeVisualization();
                    divideCipherText(cipher);
                    Decrypt(cipher);
                    
                }
                else
                {
                    MessageBox.Show("please, fill key and cipher");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
