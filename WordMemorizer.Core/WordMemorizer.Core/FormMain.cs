using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordMemorizer.Core
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Sunisoft.IrisSkin.SkinEngine skin = new Sunisoft.IrisSkin.SkinEngine();
            // "Warm.ssk";//"MacOS.ssk";//"XPSilver.ssk";// "EmeraldColor1.ssk";//"MidsummerColor3.ssk";
            // Emerald /DiamondBlue/ Page
            // Calmness  /  SteelBlack
            string skinName = "SteelBlack";
            skin.SkinFile = System.Environment.CurrentDirectory + "\\skins\\" + skinName + ".ssk";
            skin.Active = true;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
