using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Крестики_нолики
{
    public partial class Крестики_Нолики : Form
    {
        public Крестики_Нолики()
        {
            InitializeComponent();
        }
        string[,] pole = new string[3, 3]; //массив игрового поля
        int colhodov = 0;//кол-во ходов
        string znakuser = "0";
        string znakpc= "x";
        bool krestiki = true;//тип игры(за крестики или за нолики)
        bool nazjatie = true;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pole[e.RowIndex,e.ColumnIndex] == null)
            {
                if (krestiki)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Properties.Resources._0;
                    pole[e.RowIndex, e.ColumnIndex] = "0";
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Properties.Resources._1;
                    pole[e.RowIndex, e.ColumnIndex] = "x";
                }
                colhodov++;
                switch (hodpc(colhodov, krestiki))
                {
                    case 1: Message form1 = new Message("Победа компьютера!");
                            form1.Show();
                            dataGridView1.CellClick -= dataGridView1_CellClick;
                            nazjatie = false;
                            break;
                    case 2: Message form2 = new Message("Ничья!");
                            form2.Show();
                            hodpc(2, krestiki);
                            dataGridView1.CellClick -= dataGridView1_CellClick;
                            nazjatie = false;
                            break;
                }
            }
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(pole[i,j]!=null)
                    {
                        if(pole[i,j]=="x")
                            dataGridView1.Rows[i].Cells[j].Value = Properties.Resources._1;
                        else
                            dataGridView1.Rows[i].Cells[j].Value = Properties.Resources._0;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = 3;
            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Rows[i].Height = 100;
                dataGridView1.Columns[i].Width = 100;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = Properties.Resources._2;
                }
            }
            dataGridView1.Rows[1].Cells[1].Value = Properties.Resources._1;
            pole[1, 1] = "x";
        }

        public int hodpc(int colhodov,bool krestiki)
        {
            if (colhodov == 1 && !krestiki)//первый ход при игре компьютера за нолики
            {
                if (pole[1, 1] == znakuser)
                {
                    if (pole[0, 0] == null)
                        pole[0, 0] = znakpc;
                }
                else
                {
                    if (pole[1, 1] == null)
                        pole[1, 1] = znakpc;
                }
            }
            
            if (colhodov == 1 && krestiki) //первый ход и нахождение противоположного угла при игре компьютера за крестики
            {
                if (pole[0, 0] == znakuser)
                {
                    if (pole[2, 2] == null)
                        pole[2, 2] = znakpc;
                }
                if (pole[0, 1] == znakuser)
                {
                    if (pole[2, 0] == null)
                        pole[2, 0] = znakpc;
                    else if (pole[2, 2] == null)
                        pole[2, 2] = znakpc;
                }
                if (pole[0, 2] == znakuser)
                {
                    pole[2, 0] = znakpc;
                }
                if (pole[1, 0] == znakuser)
                {
                    if (pole[0, 2] == null)
                        pole[0, 2] = znakpc;
                    else if (pole[2, 2] == null)
                        pole[2, 2] = znakpc;
                }
                if (pole[1, 2] == znakuser)
                {
                    if (pole[0, 0] == null)
                        pole[0, 0] = znakpc;
                    else if (pole[2, 0] == null)
                        pole[2, 0] = znakpc;
                }
                if (pole[2, 0] == znakuser)
                {
                    pole[0, 2] = znakpc;
                }
                if (pole[2, 1] == znakuser)
                {
                    if (pole[0, 0] == null)
                        pole[0, 0] = znakpc;
                    else if (pole[0, 2] == null)
                        pole[0, 2] = znakpc;
                }
                if (pole[2, 2] == znakuser)
                {
                    pole[0, 0] = znakpc;
                }
            }
            if (colhodov == 2) //второй ход, проверка необходимости оборонятся
            {
                bool zashita = false;
                if ((pole[0, 0] + pole[0, 1] + pole[0, 2]) == znakuser+znakuser  && pole[0, 0] != znakpc && pole[0, 1] != znakpc && pole[0, 2] != znakpc)   
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (pole[0, j] == null)
                        {
                            pole[0, j] = znakpc;
                            zashita = true;
                        }
                    }
                }
                if ((pole[1, 0] + pole[1, 1] + pole[1, 2]) == znakuser + znakuser && pole[1, 0] != znakpc && pole[1, 1] != znakpc && pole[1, 2] != znakpc)   
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (pole[1, j] == null)
                        {
                            pole[1, j] = znakpc;
                            zashita = true;
                        }
                    }
                }
                if ((pole[2, 0] + pole[2, 1] + pole[2, 2]) == znakuser + znakuser && pole[2, 0] != znakpc && pole[2, 1] != znakpc && pole[2, 2] != znakpc)   
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (pole[2, j] == null)
                        {
                            pole[2, j] = znakpc;
                        }
                    }
                }
                if ((pole[2, 0] + pole[2, 1] + pole[2, 2]) == znakuser + znakuser && pole[2, 0] != znakpc && pole[2, 1] != znakpc && pole[2, 2] != znakpc)   
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (pole[2, j] == null)
                        {
                            pole[2, j] = znakpc;
                            zashita = true;
                        }
                    }
                }
                if ((pole[0, 0] + pole[1, 0] + pole[2, 0]) == znakuser + znakuser && pole[0, 0] != znakpc && pole[1, 0] != znakpc && pole[2, 0] != znakpc)   
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pole[i, 0] == null)
                        {
                            pole[i, 0] = znakpc;
                            zashita = true;
                        }
                    }
                }
                if ((pole[0, 1] + pole[1, 1] + pole[2, 1]) == znakuser + znakuser && pole[0, 1] != znakpc && pole[1, 1] != znakpc && pole[2, 1] != znakpc)   
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pole[i, 1] == null)
                        {
                            pole[i, 1] = znakpc;
                            zashita = true;
                        }
                    }
                }
                if ((pole[0, 2] + pole[1, 2] + pole[2, 2]) == znakuser + znakuser && pole[0, 2] != znakpc && pole[1, 2] != znakpc && pole[2, 2] != znakpc)   
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pole[i, 2] == null)
                        {
                            pole[i, 2] = znakpc;
                            zashita = true;
                        }
                    }
                }
                if ((pole[0, 0] + pole[1, 1] + pole[2, 2]) == znakuser + znakuser && pole[0, 0] != znakpc && pole[1, 1] != znakpc && pole[2, 2] != znakpc)  
                {
                    if (pole[0, 0] == null)
                    {
                        zashita = true;
                        pole[0, 0] = znakpc;
                    }
                    if (pole[1, 1] == null)
                    {
                        zashita = true;
                        pole[1, 1] = znakpc;
                    }  
                    if (pole[2, 2] == null)
                    {
                        zashita = true;
                        pole[2, 2] = znakpc;
                    }
                }
                if ((pole[2, 0] + pole[1, 1] + pole[0, 2]) == znakuser + znakuser && pole[2, 0] != znakpc && pole[1, 1] != znakpc && pole[0, 2] != znakpc)  
                {
                    if (pole[2, 0] == null)
                    {
                        zashita = true;
                        pole[2, 0] = znakpc;
                    }
                    if (pole[1, 1] == null)
                    {
                        zashita = true;
                        pole[1, 1] = znakpc;
                    } 
                    if (pole[0, 2] == null)
                    {
                        zashita = true;
                        pole[0, 2] = znakpc;
                    }

                }
                if (zashita == false)//если оборонятся не нужно
                {
                    switch (hodpc(3,krestiki))
                    {
                        case 2: if (krestiki)
                                hodpc(1, krestiki);
                                else
                                proverkasosednix();
                                break;
                        case 1: return 1;//победа ПК
                    }
                }  
            }
            if (colhodov == 3)//третий ход и проверка победы
            {
                if ((pole[0, 0] + pole[0, 1] + pole[0, 2]) == znakpc + znakpc)   
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (pole[0, j] == null)
                        {
                            pole[0, j] = znakpc;
                            return 1;
                        }
                    }
                }
                if ((pole[1, 0] + pole[1, 1] + pole[1, 2]) == znakpc + znakpc)   
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (pole[1, j] == null)
                        {
                            pole[1, j] = znakpc;
                            return 1;
                        }
                    }
                }
                if ((pole[2, 0] + pole[2, 1] + pole[2, 2]) == znakpc + znakpc)  
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (pole[2, j] == null)
                        {
                            pole[2, j] = znakpc;
                            return 1;
                        }
                    }
                }
                if ((pole[2, 0] + pole[2, 1] + pole[2, 2]) == znakpc + znakpc)   
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (pole[2, j] == null)
                        {
                            pole[2, j] = znakpc;
                            return 1;
                        }
                    }
                }
                if ((pole[0, 0] + pole[1, 0] + pole[2, 0]) == znakpc + znakpc)   
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pole[i, 0] == null)
                        {
                            pole[i, 0] = znakpc;
                            return 1;
                        }
                    }
                }
                if ((pole[0, 1] + pole[1, 1] + pole[2, 1]) == znakpc + znakpc)   
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pole[i, 1] == null)
                        {
                            pole[i, 1] = znakpc;
                            return 1;
                        }
                    }
                }
                if ((pole[0, 2] + pole[1, 2] + pole[2, 2]) == znakpc + znakpc)   
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pole[i, 2] == null)
                        {
                            pole[i, 2] = znakpc;
                            return 1;
                        }
                    }
                }
                if ((pole[0, 0] + pole[1, 1] + pole[2, 2]) == znakpc + znakpc)   
                {
                    if (pole[0, 0] == null)
                        pole[0, 0] = znakpc;
                    if (pole[1, 1] == null)
                        pole[1, 1] = znakpc;
                    if (pole[2, 2] == null)
                        pole[2, 2] = znakpc;
                    return 1;
                }
                if ((pole[2, 0] + pole[1, 1] + pole[0, 2]) == znakpc + znakpc)   
                {
                    if (pole[2, 0] == null)
                        pole[2, 0] = znakpc;
                    if (pole[1, 1] == null)
                        pole[1, 1] = znakpc;
                    if (pole[0, 2] == null)
                        pole[0, 2] = znakpc;
                    return 1; 
                }
                return 2;
            }
            return 0; //1-победа; 2-ничья; 0-неопределенность
        }
        public void proverkasosednix()//проверка различных позиций при игре компьютера за нолики
        {
            if (pole[1, 0] == znakuser && pole[0, 1] == znakuser)
            {
                pole[0, 0] = znakpc;
            }
            else
            {
                if (pole[0, 1] == znakuser && pole[1, 2] == znakuser)
                {
                    pole[0, 2] = znakpc;
                }
                else
                {
                    if (pole[1, 2] == znakuser && pole[2, 1] == znakuser)
                    {
                        pole[2, 2] = znakpc;
                    }
                    else
                    {
                        if (pole[2, 1] == znakuser && pole[1, 0] == znakuser)
                        {
                            pole[2, 0] = znakpc;
                        }
                    }
                }
            }
            if (pole[0, 2] == znakuser && pole[2, 1] == znakuser)
            {
                pole[2, 2] = znakpc;
            }
            else
            {
                if (pole[1, 2] == znakuser && pole[2, 0] == znakuser)
                {
                    pole[2, 2] = znakpc;
                }
                else
                {
                    if (pole[0, 0] == znakuser && pole[2, 1] == znakuser)
                    {
                        pole[2, 0] = znakpc;
                    }
                    else
                    {
                        if (pole[0, 2] == znakuser && pole[1, 0] == znakuser)
                        {
                            pole[0, 0] = znakpc;
                        }
                        else
                        {
                            if (pole[0, 0] == znakuser && pole[1, 2] == znakuser)
                            {
                                pole[0, 2] = znakpc;
                            }
                            else
                            {
                                if (pole[1, 0] == znakuser && pole[2, 2] == znakuser)
                                {
                                    pole[2, 0] = znakpc;
                                }
                            }
                        }
                    }
                }
            }
            if (pole[0, 0] == znakuser && pole[2, 2] == znakuser)
            {
                pole[0, 1] = znakpc;
            }
            else
            {
                if (pole[2, 0] == znakuser && pole[0, 2] == znakuser)
                {
                    pole[0, 1] = znakpc;
                }
            }
            if (pole[1, 1] == znakuser && pole[2, 2] == znakuser)
            {
                pole[0, 2] = znakpc;
            }
        }

        private void button1_Click(object sender, EventArgs e)//новая игра
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = Properties.Resources._2;
                    pole[i, j] = null;
                }
            }
            if (krestiki)
            {
                dataGridView1.Rows[1].Cells[1].Value = Properties.Resources._1;
                pole[1, 1] = "x";
            }
            if (!nazjatie)
            {
                dataGridView1.CellClick += dataGridView1_CellClick;
                nazjatie = true;
            }
            colhodov = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)//игра за крестики
        {
            krestiki = false;
            znakuser = "x";
            znakpc = "0";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = Properties.Resources._2;
                    pole[i, j] = null;
                }
            }
            colhodov = 0;
            if (!nazjatie)
            {
                dataGridView1.CellClick += dataGridView1_CellClick;
                nazjatie = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)//игра за нолики
        {
            krestiki = true;
            znakuser = "0";
            znakpc = "x";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = Properties.Resources._2;
                    pole[i, j] = null;
                }
            }
            dataGridView1.Rows[1].Cells[1].Value = Properties.Resources._1;
            pole[1, 1] = "x";
            colhodov = 0;
            if (!nazjatie)
            {
                dataGridView1.CellClick += dataGridView1_CellClick;
                nazjatie = true;
            }
        }
    }
}
