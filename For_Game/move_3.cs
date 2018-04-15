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
    
    public partial class move_3 : Form
    {

        private static int WM_KEYUP = 0x0101;
        bool start, fire, goup, godown, snow, e_fire, manFl = false;
        int glob_sp = 15;
        int speed = 7;
        int sn_sp = 11;
        int e_sp = 11;
        int enemy_sp = 9;
        int f_o_score = 1;
        int f_countdown = 0;
        System.Windows.Forms.PictureBox MAN = new System.Windows.Forms.PictureBox();
        System.Windows.Forms.PictureBox HERO = new System.Windows.Forms.PictureBox();
        Label snow_h = new Label();
        Label e_snow = new Label();

        public move_3()
        {
            MessageBox.Show("А если в forest прийдет winter мы можем сыграть в snowballs \n W-up  S-down Space-fire ");
            InitializeComponent();
            this.KeyPreview = true;

            HERO.Location = new System.Drawing.Point(30, 30); // устанавливаем необходимые свойства
            HERO.Name = "HERO";
            HERO.Size = new System.Drawing.Size(43, 43);
            HERO.TabIndex = 0;
            HERO.Tag = "hero";
            HERO.Image = ((System.Drawing.Image)(For_Game.Properties.Resources.kolobok));
            System.Drawing.Drawing2D.GraphicsPath hero_Path = new System.Drawing.Drawing2D.GraphicsPath();
            hero_Path.AddEllipse(0, 0, HERO.Width, HERO.Height);
            Region Button_Region = new Region(hero_Path);
            HERO.Region = Button_Region;
            HERO.Visible = false;
            Controls.Add(HERO); // добавляем на форму        
 
        }


        private void Start_Click(object sender, EventArgs e)
        {
            timer1.Interval = glob_sp;
            timer1.Start();
            Start.Visible = false;
            start = true;
            HERO.Visible = true;
            enemy.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (goup)
            {
                //
                HERO.Top -= speed;
                foreach (Control II in this.Controls)
                {
                    if (II is PictureBox && II.Tag == "wall")
                    { if (II.Bounds.IntersectsWith(HERO.Bounds)) HERO.Top += speed; }
                                  
                }
            }
            if (godown)
            {
                //
                HERO.Top += speed;
                foreach (Control II in this.Controls)
                {
                    if (II is PictureBox && II.Tag == "wall")
                    { if (II.Bounds.IntersectsWith(HERO.Bounds)) HERO.Top -= speed; }

                }
            }


            if (fire)
            {
                if (!snow)
                {
                    enemy_sp = 9;
                    enemy.Visible = true;
                    if (manFl)
                    {
                        Controls.Remove(MAN);
                        MAN.Dispose();
                        enemy.Visible = true;
                    }
                    snow_h = new Label();
                    snow_h = label_fire(HERO.Left + 43, HERO.Top);
                    snow_h.Name = "snow_h";
                    Controls.Add(snow_h);
                    snow = true;

                }
            }
            
            enemy.Top += enemy_sp;
           
            foreach (Control II in this.Controls)
            {
                if (II is PictureBox && II.Tag == "wall")
                { if (II.Bounds.IntersectsWith(enemy.Bounds)) enemy_sp = -enemy_sp; }
            }

            if (e_fire)
            {
                e_snow.Left -= e_sp;
                foreach (Control II in this.Controls)
                {
                    if (II is PictureBox && II.Tag == "wall")
                    {
                        if (II.Bounds.IntersectsWith(e_snow.Bounds))
                        {
                            Controls.Remove(e_snow);
                            e_snow.Dispose();
                            e_snow = new Label();
                            e_fire = false;
                        }
                    }
                    if (II is PictureBox && II.Tag == "hero")
                    {
                        if (II.Bounds.IntersectsWith(e_snow.Bounds))
                        {
                            timer1.Stop();
                            HERO.Visible = false;
                            MAN = new PictureBox();
                            MAN.Location = new System.Drawing.Point(HERO.Left, HERO.Top); // устанавливаем необходимые свойства
                            MAN.Name = "MAN";
                            MAN.Size = new System.Drawing.Size(130, 130);
                            MAN.TabIndex = 0;
                            MAN.Tag = "MAN";
                            MAN.Image = ((System.Drawing.Image)(For_Game.Properties.Resources.snow2));
                            Controls.Add(MAN);
                            manFl = true;
                            MessageBox.Show("You loose!");
                            this.Close();
                        }
                    }
                }
            }


            if (snow)
            {
                snow_h.Left += sn_sp;
                foreach (Control II in this.Controls)
                   {
                       if (II is PictureBox && II.Tag == "wall")
                       { if (II.Bounds.IntersectsWith(snow_h.Bounds))
                           {
                              Controls.Remove(snow_h);
                              snow_h.Dispose();
                              snow_h = new System.Windows.Forms.Label();
                              snow = false;
                           } }
                       if (II is PictureBox && II.Tag == "enemy")
                       {
                        if (II.Bounds.IntersectsWith(snow_h.Bounds))
                        {
                            Controls.Remove(snow_h);
                            snow_h.Dispose();
                            snow_h = new System.Windows.Forms.Label();
                            snow = false;
                            if (f_o_score < 4)
                            {
                                e_sp += 1; f_o_score++;
                                enemy_sp = 0;
                                enemy.Visible = false;
                                MAN = new PictureBox();
                                MAN.Location = new System.Drawing.Point(enemy.Left, enemy.Top); // устанавливаем необходимые свойства
                                MAN.Name = "MAN";
                                MAN.Size = new System.Drawing.Size(130, 130);
                                MAN.TabIndex = 0;
                                MAN.Tag = "MAN";
                                MAN.Image = ((System.Drawing.Image)(For_Game.Properties.Resources.snow_5));           
                                Controls.Add(MAN);
                                manFl = true;
                            }
                            else
                            {
                                timer1.Stop();
                                End_Win.Flag = true;
                                enemy.Visible = false;
                                MAN = new PictureBox();
                                MAN.Location = new System.Drawing.Point(enemy.Left, enemy.Top); // устанавливаем необходимые свойства
                                MAN.Name = "MAN";
                                MAN.Size = new System.Drawing.Size(130, 130);
                                MAN.TabIndex = 0;
                                MAN.Tag = "MAN";
                                MAN.Image = ((System.Drawing.Image)(For_Game.Properties.Resources.snow2));
                                Controls.Add(MAN);
                                manFl = true;
                                MessageBox.Show("You win!");
                                this.Close();
                            } 
                        }
                       }
                   }
               
               
            }
            if (!e_fire)
            {
                if (f_countdown < 100) f_countdown++;
                else
                {
                    f_countdown = 0;
                    e_snow = new Label();
                    e_snow = label_fire(enemy.Left - 30, enemy.Top);
                    Controls.Add(e_snow);
                    e_fire = true;
                    if (manFl)
                    {                       
                        Controls.Remove(MAN);
                        MAN.Dispose();
                        enemy.Visible = true;
                    }
                }
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (start)
            {
                switch (keyData)
                {
                    case Keys.W:
                        {
                            goup = true;
                            //
                            break;
                        }
                    case Keys.S:
                        {
                            godown = true;
                            //
                            break;
                        }

                    case Keys.Space:
                        {
                            fire = true;
                            //
                            break;
                        }
                    default: return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            return true;
        }

        protected override bool ProcessKeyEventArgs(ref Message m)
        {
            if (m.Msg == WM_KEYUP)
            {
                switch (m.WParam.ToInt32())
                {
                    case (int)Keys.W:
                        goup = false;
                        break;
                    case (int)Keys.Space:
                        fire = false;
                        break;
                    case (int)Keys.S:
                        godown = false;
                        break;
                }
            }

            return base.ProcessKeyEventArgs(ref m);
        }

        public Label label_fire(int X, int Y)
        {
            Label temp = new Label();
            temp.Location = new System.Drawing.Point(X, Y); // устанавливаем необходимые свойства
            temp.Name = "snow";
            temp.Size = new System.Drawing.Size(20, 20);
            temp.TabIndex = 0;
            temp.Tag = "snow";
            System.Drawing.Drawing2D.GraphicsPath snow_Path = new System.Drawing.Drawing2D.GraphicsPath();
            snow_Path.AddEllipse(0, 0, temp.Width, temp.Height);
            Region snow_Region = new Region(snow_Path);
            temp.Region = snow_Region;
            temp.BackColor = Color.Aquamarine;
            return temp;
               // Controls.Add(temp);          
              //  e_fire = true;
        }
    }
}
