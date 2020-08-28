using System;
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
    public partial class Form1 : Form
    {
        DB dB = new DB();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void SerachButton_Click(object sender, EventArgs e)
        {
            string szQuery = "SELECT * FROM Account";
 
            // DataSet을 가져온다
            DataSet ds = dB.GetData(szQuery);

            // DataSource 속성을 설정
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = ds.Tables[0];
            GridviewHeader();
            for (int i = 0; i < 11; i++)
            {
                dataGridView1.Columns[i + 12].Visible = false;
                dataGridView2.Columns[i].Visible = false;
            }
            dataGridView2.Columns[11].Visible = false;
        }
        public void GridviewHeader()
        {
            dataGridView1.Columns[0].HeaderText = "거래처코드";
            dataGridView1.Columns[1].HeaderText = "거래처명";
            dataGridView1.Columns[2].HeaderText = "거래처구분";
            dataGridView1.Columns[3].HeaderText = "거래처약칭";
            dataGridView1.Columns[4].HeaderText = "사업자번호";
            dataGridView1.Columns[5].HeaderText = "법인번호";
            dataGridView1.Columns[6].HeaderText = "대표자명";
            dataGridView1.Columns[7].HeaderText = "업태";
            dataGridView1.Columns[8].HeaderText = "종목";
            dataGridView1.Columns[9].HeaderText = "우편번호";
            dataGridView1.Columns[10].HeaderText = "주소";
            dataGridView1.Columns[11].HeaderText = "주소2";
            dataGridView2.Columns[12].HeaderText = "전화번호";
            dataGridView2.Columns[13].HeaderText = "팩스번호";
            dataGridView2.Columns[14].HeaderText = "담당자명";
            dataGridView2.Columns[15].HeaderText = "담당전화";
            dataGridView2.Columns[16].HeaderText = "계산서메일";
            dataGridView2.Columns[17].HeaderText = "은행코드";
            dataGridView2.Columns[18].HeaderText = "계좌번호";
            dataGridView2.Columns[19].HeaderText = "예금자명";
            dataGridView2.Columns[20].HeaderText = "사용여부";
            dataGridView2.Columns[21].HeaderText = "등급";
            dataGridView2.Columns[22].HeaderText = "지역";
        }
    }
}
