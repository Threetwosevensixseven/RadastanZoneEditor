using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RadastanZoneEditor.Classes;

namespace RadastanZoneEditor.Forms
{
  public partial class frmColour : Form
  {
    private Control parentControl;
    private ULAplusColour ulaPlusColour = new ULAplusColour(0, new CLUT());
    private frmMain parentForm;
    private int colourIndex;

    public frmColour()
    {
      InitializeComponent();
    }

    private void frmColour_FormClosing(object sender, FormClosingEventArgs e)
    {
      Hide();
      e.Cancel = true;
    }

    public void ShowMe(Control Control, frmMain ParentForm)
    {
      parentControl = Control;
      parentForm = ParentForm;
      if (parentControl != null)
      {
        if (parentControl.Tag is int)
          colourIndex = (int)parentControl.Tag;
        else
          colourIndex = -1;
        pnlOriginal.BackColor = parentControl.BackColor;
        pnlNew.BackColor = parentControl.BackColor;
        ulaPlusColour = new ULAplusColour(0, new CLUT());
        SetUlaPlusColour(parentControl.BackColor);
      }
      if (!Visible)
        Show();
      Focus();
      BringToFront();
    }

    private void SetUlaPlusColour(Color Colour)
    {
      ulaPlusColour.OriginalRGB = Colour;
      trkRed.Value = ulaPlusColour.Red;
      lblRed.Text = ulaPlusColour.Red.ToString();
      trkGreen.Value = ulaPlusColour.Green;
      lblGreen.Text = ulaPlusColour.Green.ToString();
      trkBlue.Value = ulaPlusColour.Blue;
      lblBlue.Text = ulaPlusColour.Blue.ToString();
      SetHSV();
      parentForm.SetCurrentColour(colourIndex, ulaPlusColour.ULAplusRGB);
    }

    private void trkRed_ValueChanged(object sender, EventArgs e)
    {
      ulaPlusColour.Red = trkRed.Value;
      lblRed.Text = ulaPlusColour.Red.ToString();
      pnlNew.BackColor = ulaPlusColour.ULAplusRGB;
      SetHSV();
      parentForm.SetCurrentColour(colourIndex, ulaPlusColour.ULAplusRGB);
    }

    private void trkGreen_ValueChanged(object sender, EventArgs e)
    {
      ulaPlusColour.Green = trkGreen.Value;
      lblGreen.Text = ulaPlusColour.Green.ToString();
      pnlNew.BackColor = ulaPlusColour.ULAplusRGB;
      SetHSV();
      parentForm.SetCurrentColour(colourIndex, ulaPlusColour.ULAplusRGB);
    }

    private void trkBlue_ValueChanged(object sender, EventArgs e)
    {
      ulaPlusColour.Blue = trkBlue.Value;
      lblBlue.Text = ulaPlusColour.Blue.ToString();
      pnlNew.BackColor = ulaPlusColour.ULAplusRGB;
      SetHSV();
      parentForm.SetCurrentColour(colourIndex, ulaPlusColour.ULAplusRGB);
    }

    private void pnlOriginal_Click(object sender, EventArgs e)
    {
      SetUlaPlusColour(pnlOriginal.BackColor);
    }

    private void SetHSV()
    {
      //trkHue.Value = ulaPlusColour.Hue;
      //lblHue.Text = trkHue.Value.ToString() + "°";
      //trkSaturation.Value = ulaPlusColour.Saturation;
      //lblSaturation.Text = trkSaturation.Value.ToString() + "%";
      //trkValue.Value = ulaPlusColour.Value;
      //lblValue.Text = trkValue.Value.ToString() + "%";
    }

    private void SetRGB()
    {
      trkRed.Value = ulaPlusColour.Red;
      lblRed.Text = ulaPlusColour.Red.ToString();
      trkGreen.Value = ulaPlusColour.Green;
      lblGreen.Text = ulaPlusColour.Green.ToString();
      trkBlue.Value = ulaPlusColour.Blue;
      lblBlue.Text = ulaPlusColour.Blue.ToString();
    }

    private void trkHue_ValueChanged(object sender, EventArgs e)
    {
      ulaPlusColour.SetHue(trkHue.Value);
      SetHSV();
      //SetRGB();
    }

    private void trkSaturation_ValueChanged(object sender, EventArgs e)
    {
      ulaPlusColour.SetSaturation(trkSaturation.Value);
      SetHSV();
      //SetRGB();
    }

    private void trkValue_ValueChanged(object sender, EventArgs e)
    {
      ulaPlusColour.SetValue(trkValue.Value);
      SetHSV();
      //SetRGB();
    }
  }
}
