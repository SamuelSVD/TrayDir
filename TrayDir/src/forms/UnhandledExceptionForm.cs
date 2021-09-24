using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayDir.forms
{
    public partial class UnhandledExceptionForm : Form
    {
        public RichTextBox richEdit
        {
            get
            {
                return richTextBox;
            }
        }
        public UnhandledExceptionForm()
        {
            InitializeComponent();
        }
    }
}
