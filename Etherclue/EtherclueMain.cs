using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etherclue
{
    public partial class EtherclueMain : Form
    {
        
        clsSocket socket;
        public EtherclueMain()
        {
            InitializeComponent();
        }

        private void EtherclueMain_Shown(object sender, EventArgs e)
        {
            
        }

        private void CheckCommand(Command cmd)
        {
            if(Program.debug)
                MessageBox.Show(cmd.GottenRequest());
            //socket.Send(new Command(cmd.GottenRequest(), true).SendRequest());
        }

        private void EtherclueMain_Load(object sender, EventArgs e)
        {
            if (!Program.debug)
            {
                this.Hide();
            }
            socket = new clsSocket("moots.me", 1337);
            socket.Send(new Command("Hello World", true).SendRequest());
            CheckCommand(new Command(socket.Receive(), false));
        }

        private void EtherclueMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            socket.Close();
        }
    }
}
