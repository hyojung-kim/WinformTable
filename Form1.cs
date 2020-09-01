using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinformTable
{
    public partial class Form1 : Form
    {
        DB dB = new DB();
        string szQuery= "SELECT * FROM Account";

        public Form1()
        {
            InitializeComponent();
        }

        public void SelectAccount(string szQuery)
        {
            

            // DataSet을 가져온다
            DataSet ds = dB.GetData(szQuery);

            // DataSource 속성을 설정
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = ds.Tables[0];
            GridviewHeader();
            
            for (int i = 0; i < 11; i++)
            {
                dataGridView1.Columns[i + 13].Visible = false;
                dataGridView2.Columns[i].Visible = false;
            }
            dataGridView2.Columns[11].Visible = false;
            dataGridView2.Columns[12].Visible = false;
   

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            SelectAccount(szQuery);
            dataGridView2.CurrentCell = dataGridView2.Rows[0].Cells[13];
        }

        private void SerachButton_Click(object sender, EventArgs e)
        {
            szQuery = "Select * from Account";
            if(serachBox.TextLength > 0)
            {
                szQuery += "WHERE Section =" + SectionBox.Text;
            }
            
            SelectAccount(szQuery);
        }



        public void GridviewHeader()
        {
            dataGridView1.Columns[0].HeaderText = "id";
            dataGridView1.Columns[1].HeaderText = "거래처코드";
            dataGridView1.Columns[2].HeaderText = "거래처명";
            dataGridView1.Columns[3].HeaderText = "거래처구분";
            dataGridView1.Columns[4].HeaderText = "거래처약칭";
            dataGridView1.Columns[5].HeaderText = "사업자번호";
            dataGridView1.Columns[6].HeaderText = "법인번호";
            dataGridView1.Columns[7].HeaderText = "대표자명";
            dataGridView1.Columns[8].HeaderText = "업태";
            dataGridView1.Columns[9].HeaderText = "종목";
            dataGridView1.Columns[10].HeaderText = "우편번호";
            dataGridView1.Columns[11].HeaderText = "주소";
            dataGridView1.Columns[12].HeaderText = "주소2";

            dataGridView2.Columns[13].HeaderText = "전화번호";
            dataGridView2.Columns[14].HeaderText = "팩스번호";
            dataGridView2.Columns[15].HeaderText = "담당자명";
            dataGridView2.Columns[16].HeaderText = "담당전화";
            dataGridView2.Columns[17].HeaderText = "계산서메일";
            dataGridView2.Columns[18].HeaderText = "은행코드";
            dataGridView2.Columns[19].HeaderText = "계좌번호";
            dataGridView2.Columns[20].HeaderText = "예금자명";
            dataGridView2.Columns[21].HeaderText = "사용여부";
            dataGridView2.Columns[22].HeaderText = "등급";
            dataGridView2.Columns[23].HeaderText = "지역";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int iRow = dataGridView1.CurrentRow.Index;
            int RowIndex = dataGridView1.CurrentCell.RowIndex + 1;
            if (iRow >= 0)
            {
                lineNum.Text = Convert.ToString(RowIndex);
                id_Label.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void newForm_Click(object sender, EventArgs e)
        {
            ArrayList codeArray = new ArrayList();
           
            AccoutForm accoutForm = new AccoutForm();
            AccoutForm.AccuntDB form1AccuntDB = new AccoutForm.AccuntDB
            {
                id = id_Label.Text,
                ACode = dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                Name = dataGridView1.CurrentRow.Cells[2].Value.ToString(),
                Section = dataGridView1.CurrentRow.Cells[3].Value.ToString(),
                Abb = dataGridView1.CurrentRow.Cells[4].Value.ToString(),
                Bnum = dataGridView1.CurrentRow.Cells[5].Value.ToString(),
                Cor = dataGridView1.CurrentRow.Cells[6].Value.ToString(),
                Rname = dataGridView1.CurrentRow.Cells[7].Value.ToString(),
                Condition = dataGridView1.CurrentRow.Cells[8].Value.ToString(),
                Kind = dataGridView1.CurrentRow.Cells[9].Value.ToString(),
                Zip = dataGridView1.CurrentRow.Cells[10].Value.ToString(),
                Address1 = dataGridView1.CurrentRow.Cells[11].Value.ToString(),
                Address2 = dataGridView1.CurrentRow.Cells[12].Value.ToString(),

                Number = dataGridView2.CurrentRow.Cells[13].Value.ToString(),
                Fax = dataGridView2.CurrentRow.Cells[14].Value.ToString(),
                Manager = dataGridView2.CurrentRow.Cells[15].Value.ToString(),
                Mnumber = dataGridView2.CurrentRow.Cells[16].Value.ToString(),
                Mail = dataGridView2.CurrentRow.Cells[17].Value.ToString(),
                Bcode = dataGridView2.CurrentRow.Cells[18].Value.ToString(),
                Anum = dataGridView2.CurrentRow.Cells[19].Value.ToString(),
                Dname = dataGridView2.CurrentRow.Cells[20].Value.ToString(),
                Usew = dataGridView2.CurrentRow.Cells[21].Value.ToString(),
                Grade = dataGridView2.CurrentRow.Cells[22].Value.ToString(),
                Area = dataGridView2.CurrentRow.Cells[23].Value.ToString()
            };
            for(int k = 0; k < dataGridView1.RowCount - 1; k++)
            {
                codeArray.Add(dataGridView1.Rows[k].Cells[1].Value.ToString());
            }

            accoutForm.codeArray = codeArray;
            accoutForm.accuntDB = form1AccuntDB;
            accoutForm.ShowDialog();
        }

   
    }
}
