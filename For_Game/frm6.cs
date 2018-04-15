using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace For_Game
{
    public partial class frm6 : Form
    {
        string[] lb_name =
            {"Z", "E","Q","T","T","J","X","K","K","V","V", "B","B","B","P","P","P","P",
            "Y","Y","Y","Y","G","G","E",  "S","R","H", "A", "O","E","T","I","N","E","E","G","G",
            "F","W","M","E","E", "A", "O","F","W","M", "F","W","M", "F","W","M",
            "U","A", "O","C", "E","E","U","C","U","T","T","C","U","C","U","C",
            "D","L","D","E","E","L","T","T","D","L","D","L","O", "A","D","L","D","L",
            "S","R","H","S","R","H","O", "A","S","R","H","S","R","H","S","R","H","S","R","H",
            "N","I","N","I","N","I","E","N","I","N","I","N","I","N","I",
            "A", "O","T", "E","T","A","O","A","O","A","O"," "};
        string s = " ";
        string st_dic = "";
        int index_dictionary = 1;
        List<Label> labelList = new List<Label>();
        public frm6()
        {
            InitializeComponent();
        }
        public bool myGo(int a)
        {
            if (a == 4)
            {
                End_Win.Flag = true;
                this.Close();
            }
            if (a < 7) return false;
            else


                return true;


        }
        private void frm6_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Составь английские слова  в верхнем левом углу путем обмена букв с помощью мыши. Новые слова в этом приключении:\n МЕТКА =  LABEL, ЯБЛОКО  =  APPLE, " +
                "ТРАВА  =  GRASS , СОН  =  SLEEP,  ВПЕРЕД  =  FORTH");
            lb_name = lb_name.OrderBy(q => Guid.NewGuid()).ToArray();
            Label lb = new Label();
            Point poz = new Point();
            int index = 0;
            poz.X = 0;
            poz.Y = 0;
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 15; i++)
                {
                    lb = CreateLabel(poz, lb_name[index], index);
                    if (i < 5 && j == 0)
                        lb.BackColor = Color.Aqua;
                    else lb.BackColor = Color.Gold;
                    if (lb.Text == " ") lb.BackColor = Color.Coral;
                    labelList.Add(lb);
                    panel1.Controls.Add(lb);

                    poz.X += lb.Width + 2;
                    index++;
                }
                poz.X = 0;
                poz.Y = poz.Y + (lb.Height + 2);
            }
            st_dic = DictionaryLabel(index_dictionary);
        }
        public bool proverca(string s, List<Label> l)
        {
            string st = "";
            bool stop = true;
            int ii = 0;
            while (stop)
            {
                st += l[ii].Text;
                ii++;
                if (ii == 5) stop = false;
            }
            if (st == s) return true;
            else
                return false;
        }

        private void MyLabel_Up(object sender, EventArgs e)
        {
            if (proverca(st_dic, labelList))
            {
                MessageBox.Show("Ok!");
                ++index_dictionary;
                st_dic = DictionaryLabel(index_dictionary);
            }
            myGo(index_dictionary);
           // if (index_dictionary == 6)
              //  Application.Exit();


        }

        private void MyLabel_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.Text != " " && s == " ")
            {
                s = lbl.Text;
                lbl.Text = " ";
            }
            else
        if (lbl.Text == " " && s != " ")
            {

                lbl.Text = s;
                s = " ";
            }
            if (Convert.ToInt32(lbl.Tag) < 5 && lbl.Text != " ")
                lbl.BackColor = Color.Aqua;
            else if (Convert.ToInt32(lbl.Tag) >= 5 && lbl.Text != " ")
                lbl.BackColor = Color.Gold;
            else lbl.BackColor = Color.Coral;
        }

        private Label CreateLabel(Point poz, string s, int ind)
        {
            Label lb = new Label();
            lb.BorderStyle = BorderStyle.Fixed3D;
            lb.FlatStyle = FlatStyle.Flat;
            lb.Font = new Font(lb.Font.Name, 12, lb.Font.Style);
            lb.ForeColor = Color.Black;
            lb.Width = 45;
            lb.Height = 45;
            lb.Text = s;
            lb.Tag = ind;
            lb.Location = poz;
            lb.Click += MyLabel_Click;
            lb.MouseUp += MyLabel_Up;
            return lb;
        }

        public string DictionaryLabel(int a)
        {
            Dictionary<string, string> d_lab = new Dictionary<string, string>
            {
                ["МЕТКА"] = "LABEL",
                ["ЯБЛОКО"] = "APPLE",
                ["ТРАВА"] = "GRASS",
                ["СОН"] = "SLEEP",
                ["ВПЕРЕД"] = "FORTH"
            };
            string s_nam = null;
            if (a == 5)
            {
                s_nam = d_lab["МЕТКА"].ToString();
                label1.Text = d_lab.First(t => t.Value == "LABEL").Key;

            }
            if (a == 1)
            {
                s_nam = d_lab["ЯБЛОКО"].ToString();
                label1.Text = d_lab.First(t => t.Value == "APPLE").Key;

            }
            if (a == 2)
            {
                s_nam = d_lab["ТРАВА"].ToString();
                label1.Text = d_lab.First(t => t.Value == "GRASS").Key;

            }
            if (a == 3)
            {
                s_nam = d_lab["СОН"].ToString();
                label1.Text = d_lab.First(t => t.Value == "SLEEP").Key;

            }
            if (a == 4)
            {
                s_nam = d_lab["ВПЕРЕД"].ToString();
                label1.Text = d_lab.First(t => t.Value == "FORTH").Key;

            }
            return s_nam;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //lb_name = lb_name.OrderBy(q => Guid.NewGuid()).ToArray();
            //Label lb = new Label();
            //Point poz = new Point();
            //int index = 0;
            //poz.X = 0;
            //poz.Y = 0;
            //for (int j = 0; j < 9; j++)
            //{
            //    for (int i = 0; i < 15; i++)
            //    {
            //        lb = CreateLabel(poz, lb_name[index], index);
            //        if (i < 5 && j == 0)
            //            lb.BackColor = Color.Aqua;
            //        else lb.BackColor = Color.Gold;
            //        if (lb.Text == " ") lb.BackColor = Color.Coral;
            //        labelList.Add(lb);
            //        panel1.Controls.Add(lb);

            //        poz.X += lb.Width + 2;
            //        index++;
            //    }
            //    poz.X = 0;
            //    poz.Y = poz.Y + (lb.Height + 2);
            //}
            //st_dic = DictionaryLabel(index_dictionary);
        }

        private void frm6_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (index_dictionary==6){ 
            //End_Win.Flag = true;
            //MessageBox.Show("Отлично");}
        }
    }
}

