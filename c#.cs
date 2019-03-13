1-basics
File and directory

A Timer
//console application
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApplication1
{
       
  //the methode OnTimedEvent1 is appeled any 1000 mili second = 1 second
    class Program
    {
        private static void OnTimedEvent1(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello World!");
        }
        static void Main(string[] args)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent1);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
          
        }
    }
}


Directory
using System.IO;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        // Specify the directory you want to manipulate.
        string path = @"c:\MyDir";// ou string path = "c:\\MyDir";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

           
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                MessageBox.Show("The directory was created successfully");

                
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
     try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    MessageBox.Show("That path exists already.");
                    return;
                }
            }

     finally { }

        }

        private void button2_Click(object sender, EventArgs e)
        {
             try
            {
            // Delete the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            di.Delete();
            MessageBox.Show("The directory was deleted successfully.");
            }
            catch { MessageBox.Show("The directory was not deleted because it is not empty");

            }
        }
            
    }
}




Copy directory to directory
/***************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication6
{
    class CopyDir
    {
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        static class Program
        {

            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                string sourceDirectory = @"c:\sourceDirectory";
                string targetDirectory = @"c:\targetDirectory";

                Copy(sourceDirectory, targetDirectory);


               // Application.EnableVisualStyles();
             //   Application.SetCompatibleTextRenderingDefault(false);
               // Application.Run(new Form1());
            }
        }

    }
}

A-File            /***************************************************/
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
A-1- file in path   /************************************************/
public string path = @"c:\MyTest.txt";

                  /*********************************************************/
creat
FileStream fs = File.Create(path);

Delete
if (File.Exists(path))
                {
                    File.Delete(path);
                }
write
FileStream fs = File.Create(path);
            Byte[] info = new UTF8Encoding(true).GetBytes("text in the file.");
            // Add some information to the file.
           
            fs.Write(info, 0, info.Length);

                  /*********************************************************/

             A-2-File pathless

        private void button1_Click(object sender, EventArgs e)
        {
            string newContent = textBox1.Text;
            File.WriteAllText("test ", newContent);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("test "))
            {
                string content = File.ReadAllText("test.txt");
                textBox2.Text = content;

            }
           
        }
operators
++     increment by 1
--     Decrement by 1
1=4%3 ; Remainder or modulo
Conversion text en nombre (double)
Double.Parse(txtPay.Text)
Convert.ToDouble(txtPay.Text)

conversion nombre(double) en text  
 double nb = 123;
 textbox1.Text = nb.ToString();
Conversion float to int
float unite ;
int unitei = Convert.ToInt32(unite);
exception 
try
            {
               MessageBox.Show("if ok");
                
            }
            catch { MessageBox.Show( " it is not ok"); 
                  };



Teste qu’un textbox n’est pas vide
if ((textBox1.Text != "") & (textBox11.Text != ""))
2-data base

Connexion a une base de données SQL server
Using System.Data.SqlClient;

/*************************************************************/
Script sql server pour extraire la chaine de connexion
select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name()
    end
from sys.server_principals
where name = suser_name()
Exemple chaine de connexion a une base de donnée.

"Data Source=SRV-STAT\\SQLEXPR2005;Initial Catalog=contact;Integrated Security=True";

"Data Source=SRV-STAT;Initial Catalog=PERMIS DE CONDUIRE; User ID=sa " ;


/*************************************************************/


private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString =
 "Data Source=SRV-STAT\\SQLEXPR2005;Initial Catalog=contact;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }


connexion
SqlConnection con = new
SqlConnection("
Data Source=SRV-STAT\\SQLEXPRESS;
Initial Catalog=contact;
Integrated Security=True");

search
            try
            { 
                con.Open();
                SqlDataAdapter oda = new SqlDataAdapter("Select * from loginTable where login like '%"+textBox1.Text +"%'", con);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch
            {   
                this.Close();
            }
        }

addition
SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO contact (mob,nprenom,adress) 
values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "');", con);
con.Open();
SDA.SelectCommand.ExecuteNonQuery();
con.Close();
MessageBox.Show("succes effected");

delete
SqlDataAdapter SDA = new SqlDataAdapter("DELETE FROM contact where mob='5';", con);
con.Open();
SDA.SelectCommand.ExecuteNonQuery();
con.Close();
MessageBox.Show("succes deleted");

  /****************************************************************/
3-Datagridview
3.1-Dans le cas d’oracle
OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;User ID=admin;Password=Oo123456;Unicode=True");

        private void load(object sender, EventArgs e)
        {
            con.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select * from contact", con);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
OleDbCommand cmd = new OleDbCommand("insert into contact      values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')",con);
            cmd.ExecuteNonQuery();
            con.Close();
            load(null, null);//apelle de procedure pour remplire de datagridview
        }

3.2-Dans le cas sql server
private void button2_Click(object sender, EventArgs e)
        {   
            string qr;
            qr = "DELETE FROM contact where mob = " + textBox1.Text + ";";
     SqlConnection con = new SqlConnection("Data Source=SRV-STAT\\SQLEXPRESS;Initial   Catalog=contact;Integrated Security=True");
            SqlDataAdapter SDA = new SqlDataAdapter(qr, con);
            
            con.Open();
            SDA.SelectCommand.ExecuteNonQuery();


            //-----------load------//


            SqlDataAdapter oda = new SqlDataAdapter("Select * from contact", con);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;

            //---------------------------//

            con.Close();
            
            MessageBox.Show("رخصة السياقة رقم  "+textBox1.Text+" حذفت من قاعدة البيانات بنجاح");

        }
        
/*************************************************************/

4-Crystall report

using System.Data.SqlClient;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports;
using System.Collections;
using System.Data.OleDb;

Methode 1


public partial class Freport : Form
    {
        DataSet1TableAdapters.loginTableTableAdapter dl = new DataSet1TableAdapters.loginTableTableAdapter();
        DataSet1 ds = new DataSet1();
        CrystalReport1 cr = new CrystalReport1();

        public Freport()
        {
            InitializeComponent();
        }

        private void Freport_Load(object sender, EventArgs e)
        {
            dl.Fill(ds.loginTable);

            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;

        }
    }











Methode 2

public partial class FCRuser : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=SRV-STAT\SQLEXPRESS;Initial Catalog=C:\USERS\ADMINISTRATOR\DOCUMENTS\VISUAL STUDIO 2010\PROJECTS\LOGINAPP\LOGINAPP\DATALIGIN.MDF;Integrated Security=True");
          
         public FCRuser()
        {
            InitializeComponent();
        }
        private void FCRuser_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From loginTable";
            cmd.ExecuteNonQuery();
            dataliginDataSet ds = new dataliginDataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds.loginTable);
       
        CrystalReport1 myreport = new CrystalReport1();
        
        
            myreport.SetDataSource(ds);
            crystalReportViewer1.ReportSource = myreport;
            con.Close();
        }



/*********************************************************************************/
/*************************************login********************************************/
5-LOGIN
login form(form1)
public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "password") { DialogResult = DialogResult.OK; }
            else { MessageBox.Show("password warong."); }
        }
    }

main  (Program.cs)
static void Main()
        {

            DialogResult result;
            Form1 loginForm1 = new Form1();
            result = loginForm1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Application.Run(new Form2());
            }

        }

/****************************************///login*************************************/

  RESEAUX(TCP/IP)
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace PingTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ping p = new Ping();
            PingReply r;
            string s;
            s = textBox1.Text;
            r = p.Send(s);

            if (r.Status == IPStatus.Success)
            {

                MessageBox.Show("Ping to " +s.ToString() + "\n" 
                       + "["+ r.Address.ToString() + "]" + "\n"
                  + " Successful" + " Response delay = " + "\n" 
                    + r.RoundtripTime.ToString() + " ms" + "\n" 
                    +//r.Status+
                    "يوجد اتصال    ");
            }
            else 
            {
                MessageBox.Show( r.Status+ " لايوجد اتصال    ");
            }
        }  
    }

}



















//**************************Socket ***********************************************/
client
using System;

using System.Windows.Forms;

using System.Net.Sockets;

using System.Text;



namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {

        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();



        public Form1()
        {

            InitializeComponent();

        }



        private void Form1_Load(object sender, EventArgs e)
        {

            msg("Client Started");

            clientSocket.Connect("127.0.0.1", 8888);

            label1.Text = "Client Socket Program - Server Connected ...";

        }



      



        public void msg(string mesg)
        {

            textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + mesg;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox2.Text + "$");

            serverStream.Write(outStream, 0, outStream.Length);

            serverStream.Flush();



            byte[] inStream = new byte[10025];

            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);

            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            msg(returndata);

            textBox2.Text = "";

            textBox2.Focus();

        }

    }

}

server

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Net.Sockets;



namespace ConsoleApplication1
{

    class Program
    {

        static void Main(string[] args)
        {



            TcpListener serverSocket = new TcpListener(8888);

            int requestCount = 0;

            TcpClient clientSocket = default(TcpClient);

            serverSocket.Start();

            Console.WriteLine(" >> Server Started");

            clientSocket = serverSocket.AcceptTcpClient();

            Console.WriteLine(" >> Accept connection from client");

            requestCount = 0;



            while ((true))
            {

                try
                {

                    requestCount = requestCount + 1;

                    NetworkStream networkStream = clientSocket.GetStream();

                    byte[] bytesFrom = new byte[10025];

                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);

                    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);

                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                    Console.WriteLine(" >> Data from client - " + dataFromClient);

                    string serverResponse = "Last Message from client" + dataFromClient;

                    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);

                    networkStream.Write(sendBytes, 0, sendBytes.Length);

                    networkStream.Flush();

                    Console.WriteLine(" >> " + serverResponse);

                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());

                }

            }



            clientSocket.Close();

            serverSocket.Stop();

            Console.WriteLine(" >> exit");

            Console.ReadLine();

        }



    }

}

