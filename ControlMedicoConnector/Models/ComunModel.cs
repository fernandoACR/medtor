using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlMedicoConnector.Models
{
    public class ComunModel
    {
        public enum RolesUsuario
        {
            Administrador = 1,
            Medico = 2,
            Paciente = 3,
            Usuario = 4
        };

        public enum EstatusCitaEnum
        {
            POR = 1,
            AGE = 2,
            CNC = 4,
        };

        public enum EstatusOrdenEnum
        {
            ENTR = 3,
            REC = 4,
            PRO = 5,
            ENTO = 7
        }

        public class MyColorTable : ProfessionalColorTable
        {
            private Color menuItemSelectedColor;
            public MyColorTable(Color color) : base()
            {
                menuItemSelectedColor = color;
            }
            public override Color MenuItemSelected
            {
                get { return menuItemSelectedColor; }
            }
        }

        public class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                //Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                //if (e.Item.Selected)
                //{

                //    Color c = e.Item.Selected ? Color.LightSkyBlue : Color.Beige;
                //    using (SolidBrush brush = new SolidBrush(c))
                //    {
                //        var a = e.Item;
                //        foreach (ToolStripMenuItem x in e.ToolStrip.Items)
                //        {
                //            foreach (ToolStripDropDownItem it in x.DropDownItems)
                //            {
                //                it.BackColor = Color.FromArgb(100, 175, 158);
                //            }
                //        }
                //        //e.Item.BackColor = Color.Red;
                //        e.Graphics.FillRectangle(brush, rc);
                //    }
                //}
                //foreach (ToolStripMenuItem x in e.ToolStrip.Items)
                //{
                //    foreach (ToolStripDropDownItem it in x.DropDownItems)
                //    {
                //        it.BackColor = Color.FromArgb(0, 104, 133);
                //    }
                //}
                //if (!e.Item.Selected)
                //{
                    
                    
                //    //e.Graphics.FillRectangle(Brushes.LightSkyBlue, rc);
                //    e.Graphics.DrawRectangle(Pens.Black, 1, 0, rc.Width - 2, rc.Height - 1);
                //    e.Item.BackColor = Color.FromArgb(100, 175, 158);
                //    foreach (ToolStripMenuItem x in e.ToolStrip.Items)
                //    {
                //        foreach (ToolStripDropDownItem it in x.DropDownItems)
                //        {
                //            it.BackColor = Color.FromArgb(0, 104, 133);
                //        }
                //    }
                //}
                //else
                //{
                //    base.OnRenderMenuItemBackground(e);
                //    //Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                //    e.Graphics.FillRectangle(Brushes.LightSkyBlue, rc);
                //    e.Graphics.DrawRectangle(Pens.Black, 1, 0, rc.Width - 2, rc.Height - 1);
                //    e.Item.BackColor = Color.FromArgb(0, 104, 133);
                //    foreach (ToolStripMenuItem x in e.ToolStrip.Items)
                //    {
                //        foreach (ToolStripDropDownItem it in x.DropDownItems)
                //        {
                //            it.BackColor = Color.FromArgb(0, 104, 133);
                //        }
                //    }
                //}
            }
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                base.OnRenderItemText(e);
                //if (!e.Item.Selected)
                //{
                //    e.Item.ForeColor = Color.Red;
                //}
                //else
                //{
                //    e.Item.ForeColor = Color.Black;
                //}
                e.Item.ForeColor = Color.White;
            }
        }
        //public class MenuStripAllowsCustomHighlight : MenuStrip
        //{
        //    public MenuStripAllowsCustomHighlight()
        //    {
        //        this.Renderer = new MyRenderer();
        //    }

        //}    
    }
}
