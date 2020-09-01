using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformTable
{
    public partial class AccoutForm : Form
    {
        DB dB = new DB();
        int iRow;
        string defaultCode;
        public void SelectAccount()
        {
            string szQuery = "SELECT Manager as 담당자명,id as 부서명, Mnumber as 전화번호, Fax as 팩스번호, Mail as 'E-MAIL', id AS 비고 FROM Account where id = " + accuntDB.id;

            // DataSet을 가져온다k
            DataSet ds = dB.GetData(szQuery);

            // DataSource 속성을 설정
            dataGridView1.DataSource = ds.Tables[0];
        }
        public struct AccuntDB
        {
            public string id, ACode, Name, Section, Abb, Bnum, Cor, Rname, Condition, Kind, Zip, Address1, Address2, Number, Fax, Manager, Mnumber, Mail, Bcode, Anum, Dname, Usew, Grade, Area;
        }
        public ArrayList codeArray;

        public AccuntDB accuntDB = new AccuntDB();


        public AccoutForm()
        {
            InitializeComponent();
        }


        private void AccoutForm_Load(object sender, EventArgs e)
        {
            SelectAccount();
            textBox1.Text = accuntDB.ACode;
            textBox2.Text = accuntDB.Rname;
            textBox3.Text = accuntDB.Condition;
            textBox4.Text = accuntDB.Fax;
            textBox5.Text = accuntDB.Address1;
            textBox6.Text = accuntDB.Name;
            textBox7.Text = accuntDB.Section;
            textBox8.Text = accuntDB.Kind;
            //textBox9.Text = accuntDB.;
            textBox10.Text = accuntDB.Abb;
            textBox11.Text = accuntDB.Area;
            textBox12.Text = accuntDB.Number;
            //textBox13.Text = accuntDB.;
            textBox14.Text = accuntDB.Address2;
            textBox15.Text = accuntDB.Manager;
            textBox16.Text = accuntDB.Bcode;
            textBox17.Text = accuntDB.Mnumber;
            textBox18.Text = accuntDB.Anum;
            textBox19.Text = accuntDB.Mail;
            textBox20.Text = accuntDB.Dname;
            iRow = Convert.ToInt32(accuntDB.id);

            defaultCode = accuntDB.ACode;

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            iRow = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            //textBox9.Text "";= accuntDB.;
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            //textBox13.Text = accuntDB.;
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
        }

        private void UpIn_Click(object sender, EventArgs e)
        {
            Boolean overlapCheck = false;
            
            if (iRow == 0)
            {
                if (textBox1.TextLength > 0 && textBox6.TextLength > 0 && textBox7.TextLength > 0)
                {
                    for (int j = 0; j < codeArray.Count; j++)
                    {
                        if ((string)codeArray[j] == textBox1.Text)
                        {
                            MessageBox.Show("중복된 코드입니다.");
                            overlapCheck = true;
                            break;
                        }
                    }
                    if (overlapCheck == false)
                    {
                        string szQuery;
                        szQuery = string.Format("exec Account_Insert {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22};",
                             "'" + textBox1.Text + "'", "'" + textBox6.Text + "'", "'" + textBox7.Text + "'", "'" + textBox10.Text + "'", "A", "A", "'" + textBox2.Text + "'", "'" + textBox3.Text + "'", "'" + textBox8.Text + "'", "A", "'" + textBox5.Text + "'", "'" + textBox14.Text + "'", "'" + textBox17.Text + "'", "'" + textBox4.Text + "'", "'" + textBox15.Text + "'", "'" + textBox17.Text + "'", "'" + textBox19.Text + "'", "'" + textBox16.Text + "'", "'" + textBox18.Text + "'", "'" + textBox20.Text + "'", "A", "A", "'" + textBox11.Text + "'");
                        DataSet ds = dB.GetData(szQuery);
                        MessageBox.Show("Insert");
                    }
                }
                else
                {
                    if (textBox1.TextLength == 0)
                    {
                        label24.Visible = true;
                    }


                    if (textBox6.TextLength == 0)
                    {
                        label25.Visible = true;
                    }


                    if (textBox7.TextLength == 0)
                    {
                        label26.Visible = true;
                    }
                }
            }

            else
            {
                overlapCheck = false;
                if (textBox1.TextLength > 0 && textBox6.TextLength > 0 && textBox7.TextLength > 0)
                {
                    for (int j = 0; j < codeArray.Count; j++)
                    {
                        if (defaultCode == textBox1.Text)
                            break;
                        else if((string)codeArray[j] == textBox1.Text)
                        {
                            MessageBox.Show("중복된 코드입니다.");
                            overlapCheck = true;
                            break;
                        }
                    }
                    if (overlapCheck == false)
                    {
                        string szQuery;
                        szQuery = string.Format("exec Account_Update {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23};",
                         "'" + accuntDB.id + "'", "'" + textBox1.Text + "'", "'" + textBox6.Text + "'", "'" + textBox7.Text + "'", "'" + textBox10.Text + "'", "A", "A", "'" + textBox2.Text + "'", "'" + textBox3.Text + "'", "'" + textBox8.Text + "'", "A", "'" + textBox5.Text + "'", "'" + textBox14.Text + "'", "'" + textBox17.Text + "'", "'" + textBox4.Text + "'", "'" + textBox15.Text + "'", "'" + textBox17.Text + "'", "'" + textBox19.Text + "'", "'" + textBox16.Text + "'", "'" + textBox18.Text + "'", "'" + textBox20.Text + "'", "A", "A", "'" + textBox11.Text + "'");

                        DataSet ds = dB.GetData(szQuery);
                        MessageBox.Show("Update");
                    }
                }
                else
                {
                    if (textBox1.TextLength == 0)
                    {
                        label24.Visible = true;
                    }


                    if (textBox6.TextLength == 0)
                    {
                        label25.Visible = true;
                    }


                    if (textBox7.TextLength == 0)
                    {
                        label26.Visible = true;
                    }
                }
            }
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            string szQuery;
            szQuery = string.Format("exec Account_Delete {0}",
                "'" + accuntDB.id + "'");
            if (MessageBox.Show("삭제하시겠습니까?", "확인창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = dB.GetData(szQuery);
                SelectAccount();
                iRow = 0;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                //textBox9.Text "";= accuntDB.;
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                //textBox13.Text = accuntDB.;
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
            }
        }






        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                label24.Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
                label25.Visible = false;   
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
                label26.Visible = false;
        }



    }
}
