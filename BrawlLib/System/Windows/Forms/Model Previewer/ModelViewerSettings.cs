using System;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Wii.Animations;
using System.Collections.Generic;
using System.Drawing;
using BrawlLib.Imaging;

namespace System.Windows.Forms
{
    public class ModelViewerSettingsDialog : Form
    {
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private NumericInputBox ax;
        private NumericInputBox radius;
        private NumericInputBox dx;
        private NumericInputBox sx;
        private NumericInputBox sy;
        private NumericInputBox dy;
        private NumericInputBox azimuth;
        private NumericInputBox ay;
        private NumericInputBox sz;
        private NumericInputBox dz;
        private NumericInputBox elevation;
        private NumericInputBox az;
        private NumericInputBox sw;
        private NumericInputBox dw;
        private NumericInputBox aw;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label10;
        private Label label9;
        private Label label11;
        private Label label13;
        private Label label12;
        private Label label14;
        private NumericInputBox farZ;
        private NumericInputBox nearZ;
        private NumericInputBox yFov;
        private NumericInputBox zScale;
        private NumericInputBox tScale;
        private NumericInputBox rScale;
        private Label label17;
        private Label label16;
        private GroupBox groupBox3;
        private Label lblLineColor;
        private Label lblLineText;
        private Label label20;
        private Label lblOrbColor;
        private Label lblOrbText;
        private Label label15;
        private GroupBox groupBox4;
        private Label lblCol1Color;
        private Label lblCol1Text;
        private Label label24;
        private NumericInputBox maxUndoCount;
        private Label label18;
        private ModelEditControl form;

        public ModelViewerSettingsDialog() { InitializeComponent(); _dlgColor = new GoodColorDialog(); maxUndoCount.Integral = true; }

        public DialogResult ShowDialog(ModelEditControl owner)
        {
            form = owner;

            ax.Value = form.modelPanel1.Ambient._x;
            ay.Value = form.modelPanel1.Ambient._y;
            az.Value = form.modelPanel1.Ambient._z;
            aw.Value = form.modelPanel1.Ambient._w;

            radius.Value = form.modelPanel1.LightPosition._x;
            azimuth.Value = form.modelPanel1.LightPosition._y;
            elevation.Value = form.modelPanel1.LightPosition._z;

            dx.Value = form.modelPanel1.Diffuse._x;
            dy.Value = form.modelPanel1.Diffuse._y;
            dz.Value = form.modelPanel1.Diffuse._z;
            dw.Value = form.modelPanel1.Diffuse._w;

            sx.Value = form.modelPanel1.Specular._x;
            sy.Value = form.modelPanel1.Specular._y;
            sz.Value = form.modelPanel1.Specular._z;
            sw.Value = form.modelPanel1.Specular._w;

            tScale.Value = form.modelPanel1.TranslationScale;
            rScale.Value = form.modelPanel1.RotationScale;
            zScale.Value = form.modelPanel1.ZoomScale;

            yFov.Value = form.modelPanel1._fovY;
            nearZ.Value = form.modelPanel1._nearZ;
            farZ.Value = form.modelPanel1._farZ;

            maxUndoCount.Value = form._allowedUndos;

            UpdateOrb();
            UpdateLine();
            UpdateCol1();

            return base.ShowDialog(owner);
        }

        private unsafe void btnOkay_Click(object sender, EventArgs e)
        {
            form.modelPanel1.Ambient = new Vector4(ax.Value, ay.Value, az.Value, aw.Value);
            form.modelPanel1.LightPosition = new Vector4(radius.Value, azimuth.Value, elevation.Value, 1.0f);
            form.modelPanel1.Diffuse = new Vector4(dx.Value, dy.Value, dz.Value, dw.Value);
            form.modelPanel1.Specular = new Vector4(sx.Value, sy.Value, sz.Value, sw.Value);

            form.modelPanel1.TranslationScale = tScale.Value;
            form.modelPanel1.RotationScale = rScale.Value;
            form.modelPanel1.ZoomScale = zScale.Value;

            form.modelPanel1._fovY = yFov.Value;
            form.modelPanel1._nearZ = nearZ.Value;
            form.modelPanel1._farZ = farZ.Value;

            form._allowedUndos = (int)maxUndoCount.Value;

            //Vector4 Ambient = new Vector4();
            //if (!float.TryParse(ax.Text, out Ambient._x))
            //    Ambient._x = 0.2f;
            //if (!float.TryParse(ay.Text, out Ambient._y))
            //    Ambient._y = 0.2f;
            //if (!float.TryParse(az.Text, out Ambient._z))
            //    Ambient._z = 0.2f;
            //if (!float.TryParse(aw.Text, out Ambient._w))
            //    Ambient._w = 1;
            //form.modelPanel1.Ambient = Ambient;

            //Vector4 Light = new Vector4();
            //if (!float.TryParse(radius.Text, out Light._x))
            //    Light._x = 0;
            //if (!float.TryParse(azimuth.Text, out Light._y))
            //    Light._y = 6;
            //if (!float.TryParse(elevation.Text, out Light._z))
            //    Light._z = 6;
            //Light._w = 1;
            //form.modelPanel1.LightPosition = Light;

            //Vector4 Diffuse = new Vector4();
            //if (!float.TryParse(dx.Text, out Diffuse._x))
            //    Diffuse._x = 0.8f;
            //if (!float.TryParse(dy.Text, out Diffuse._y))
            //    Diffuse._y = 0.8f;
            //if (!float.TryParse(dz.Text, out Diffuse._z))
            //    Diffuse._z = 0.8f;
            //if (!float.TryParse(dw.Text, out Diffuse._w))
            //    Diffuse._w = 1;
            //form.modelPanel1.Diffuse = Diffuse;

            //Vector4 Specular = new Vector4();
            //if (!float.TryParse(sx.Text, out Specular._x))
            //    Specular._x = 0.5f;
            //if (!float.TryParse(sy.Text, out Specular._y))
            //    Specular._y = 0.5f;
            //if (!float.TryParse(sz.Text, out Specular._z))
            //    Specular._z = 0.5f;
            //if (!float.TryParse(sw.Text, out Specular._w))
            //    Specular._w = 1;
            //form.modelPanel1.Specular = Specular;

            //float val;
            //if (!float.TryParse(tScale.Text, out val))
            //    val = 0.05f;
            //form.modelPanel1.TranslationScale = val;
            //if (!float.TryParse(rScale.Text, out val))
            //    val = 0.1f;
            //form.modelPanel1.RotationScale = val;
            //if (!float.TryParse(zScale.Text, out val))
            //    val = 2.5f;
            //form.modelPanel1.ZoomScale = val;

            //if (!float.TryParse(yFov.Text, out val))
            //    val = 45.0f;
            //form.modelPanel1._fovY = val;
            //if (!float.TryParse(nearZ.Text, out val))
            //    val = 1.0f;
            //form.modelPanel1._nearZ = val;
            //if (!float.TryParse(farZ.Text, out val))
            //    val = 20000.0f;
            //form.modelPanel1._farZ = val;

            form.modelPanel1._projectionChanged = true;

            form.modelPanel1.Invalidate();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }

        #region Designer

        private Button btnCancel;
        private Button btnOkay;

        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.ax = new System.Windows.Forms.NumericInputBox();
            this.radius = new System.Windows.Forms.NumericInputBox();
            this.dx = new System.Windows.Forms.NumericInputBox();
            this.sx = new System.Windows.Forms.NumericInputBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sy = new System.Windows.Forms.NumericInputBox();
            this.dy = new System.Windows.Forms.NumericInputBox();
            this.azimuth = new System.Windows.Forms.NumericInputBox();
            this.ay = new System.Windows.Forms.NumericInputBox();
            this.sz = new System.Windows.Forms.NumericInputBox();
            this.dz = new System.Windows.Forms.NumericInputBox();
            this.elevation = new System.Windows.Forms.NumericInputBox();
            this.az = new System.Windows.Forms.NumericInputBox();
            this.sw = new System.Windows.Forms.NumericInputBox();
            this.dw = new System.Windows.Forms.NumericInputBox();
            this.aw = new System.Windows.Forms.NumericInputBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.farZ = new System.Windows.Forms.NumericInputBox();
            this.nearZ = new System.Windows.Forms.NumericInputBox();
            this.yFov = new System.Windows.Forms.NumericInputBox();
            this.zScale = new System.Windows.Forms.NumericInputBox();
            this.tScale = new System.Windows.Forms.NumericInputBox();
            this.rScale = new System.Windows.Forms.NumericInputBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblLineColor = new System.Windows.Forms.Label();
            this.lblLineText = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblOrbColor = new System.Windows.Forms.Label();
            this.lblOrbText = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblCol1Color = new System.Windows.Forms.Label();
            this.lblCol1Text = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.maxUndoCount = new System.Windows.Forms.NumericInputBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(231, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Location = new System.Drawing.Point(150, 400);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 1;
            this.btnOkay.Text = "&Okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // ax
            // 
            this.ax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ax.Location = new System.Drawing.Point(67, 92);
            this.ax.Name = "ax";
            this.ax.Size = new System.Drawing.Size(50, 20);
            this.ax.TabIndex = 3;
            this.ax.Text = "0";
            // 
            // radius
            // 
            this.radius.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.radius.Location = new System.Drawing.Point(12, 41);
            this.radius.Name = "radius";
            this.radius.Size = new System.Drawing.Size(66, 20);
            this.radius.TabIndex = 4;
            this.radius.Text = "0";
            // 
            // dx
            // 
            this.dx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx.Location = new System.Drawing.Point(67, 111);
            this.dx.Name = "dx";
            this.dx.Size = new System.Drawing.Size(50, 20);
            this.dx.TabIndex = 5;
            this.dx.Text = "0";
            // 
            // sx
            // 
            this.sx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sx.Location = new System.Drawing.Point(67, 130);
            this.sx.Name = "sx";
            this.sx.Size = new System.Drawing.Size(50, 20);
            this.sx.TabIndex = 6;
            this.sx.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ambient:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Radius";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Diffuse:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Specular:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(67, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "X";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(116, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Y";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(165, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Z";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(214, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "W";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sy
            // 
            this.sy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sy.Location = new System.Drawing.Point(116, 130);
            this.sy.Name = "sy";
            this.sy.Size = new System.Drawing.Size(50, 20);
            this.sy.TabIndex = 26;
            this.sy.Text = "0";
            // 
            // dy
            // 
            this.dy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dy.Location = new System.Drawing.Point(116, 111);
            this.dy.Name = "dy";
            this.dy.Size = new System.Drawing.Size(50, 20);
            this.dy.TabIndex = 25;
            this.dy.Text = "0";
            // 
            // azimuth
            // 
            this.azimuth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.azimuth.Location = new System.Drawing.Point(77, 41);
            this.azimuth.Name = "azimuth";
            this.azimuth.Size = new System.Drawing.Size(66, 20);
            this.azimuth.TabIndex = 24;
            this.azimuth.Text = "0";
            // 
            // ay
            // 
            this.ay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ay.Location = new System.Drawing.Point(116, 92);
            this.ay.Name = "ay";
            this.ay.Size = new System.Drawing.Size(50, 20);
            this.ay.TabIndex = 23;
            this.ay.Text = "0";
            // 
            // sz
            // 
            this.sz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sz.Location = new System.Drawing.Point(165, 130);
            this.sz.Name = "sz";
            this.sz.Size = new System.Drawing.Size(50, 20);
            this.sz.TabIndex = 30;
            this.sz.Text = "0";
            // 
            // dz
            // 
            this.dz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dz.Location = new System.Drawing.Point(165, 111);
            this.dz.Name = "dz";
            this.dz.Size = new System.Drawing.Size(50, 20);
            this.dz.TabIndex = 29;
            this.dz.Text = "0";
            // 
            // elevation
            // 
            this.elevation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.elevation.Location = new System.Drawing.Point(142, 41);
            this.elevation.Name = "elevation";
            this.elevation.Size = new System.Drawing.Size(66, 20);
            this.elevation.TabIndex = 28;
            this.elevation.Text = "0";
            // 
            // az
            // 
            this.az.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.az.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.az.Location = new System.Drawing.Point(165, 92);
            this.az.Name = "az";
            this.az.Size = new System.Drawing.Size(50, 20);
            this.az.TabIndex = 27;
            this.az.Text = "0";
            // 
            // sw
            // 
            this.sw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sw.Location = new System.Drawing.Point(214, 130);
            this.sw.Name = "sw";
            this.sw.Size = new System.Drawing.Size(50, 20);
            this.sw.TabIndex = 34;
            this.sw.Text = "0";
            // 
            // dw
            // 
            this.dw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dw.Location = new System.Drawing.Point(214, 111);
            this.dw.Name = "dw";
            this.dw.Size = new System.Drawing.Size(50, 20);
            this.dw.TabIndex = 33;
            this.dw.Text = "0";
            // 
            // aw
            // 
            this.aw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.aw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aw.Location = new System.Drawing.Point(214, 92);
            this.aw.Name = "aw";
            this.aw.Size = new System.Drawing.Size(50, 20);
            this.aw.TabIndex = 31;
            this.aw.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.sw);
            this.groupBox1.Controls.Add(this.dw);
            this.groupBox1.Controls.Add(this.aw);
            this.groupBox1.Controls.Add(this.sz);
            this.groupBox1.Controls.Add(this.dz);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radius);
            this.groupBox1.Controls.Add(this.az);
            this.groupBox1.Controls.Add(this.elevation);
            this.groupBox1.Controls.Add(this.sy);
            this.groupBox1.Controls.Add(this.azimuth);
            this.groupBox1.Controls.Add(this.dy);
            this.groupBox1.Controls.Add(this.ay);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sx);
            this.groupBox1.Controls.Add(this.dx);
            this.groupBox1.Controls.Add(this.ax);
            this.groupBox1.Location = new System.Drawing.Point(0, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 167);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lighting";
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Location = new System.Drawing.Point(142, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 20);
            this.label17.TabIndex = 36;
            this.label17.Text = "Elevation";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(77, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 20);
            this.label16.TabIndex = 35;
            this.label16.Text = "Azimuth";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.farZ);
            this.groupBox2.Controls.Add(this.nearZ);
            this.groupBox2.Controls.Add(this.yFov);
            this.groupBox2.Controls.Add(this.zScale);
            this.groupBox2.Controls.Add(this.tScale);
            this.groupBox2.Controls.Add(this.rScale);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 91);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Projection";
            // 
            // farZ
            // 
            this.farZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.farZ.Location = new System.Drawing.Point(247, 57);
            this.farZ.Name = "farZ";
            this.farZ.Size = new System.Drawing.Size(60, 20);
            this.farZ.TabIndex = 11;
            this.farZ.Text = "0";
            // 
            // nearZ
            // 
            this.nearZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nearZ.Location = new System.Drawing.Point(247, 38);
            this.nearZ.Name = "nearZ";
            this.nearZ.Size = new System.Drawing.Size(60, 20);
            this.nearZ.TabIndex = 10;
            this.nearZ.Text = "0";
            // 
            // yFov
            // 
            this.yFov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yFov.Location = new System.Drawing.Point(247, 19);
            this.yFov.Name = "yFov";
            this.yFov.Size = new System.Drawing.Size(60, 20);
            this.yFov.TabIndex = 9;
            this.yFov.Text = "0";
            // 
            // zScale
            // 
            this.zScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zScale.Location = new System.Drawing.Point(109, 57);
            this.zScale.Name = "zScale";
            this.zScale.Size = new System.Drawing.Size(50, 20);
            this.zScale.TabIndex = 8;
            this.zScale.Text = "0";
            // 
            // tScale
            // 
            this.tScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tScale.Location = new System.Drawing.Point(109, 38);
            this.tScale.Name = "tScale";
            this.tScale.Size = new System.Drawing.Size(50, 20);
            this.tScale.TabIndex = 7;
            this.tScale.Text = "0";
            // 
            // rScale
            // 
            this.rScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rScale.Location = new System.Drawing.Point(109, 19);
            this.rScale.Name = "rScale";
            this.rScale.Size = new System.Drawing.Size(50, 20);
            this.rScale.TabIndex = 6;
            this.rScale.Text = "0";
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(158, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 20);
            this.label14.TabIndex = 5;
            this.label14.Text = "Far Z: ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(158, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "Near Z: ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(158, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "Y Field Of View: ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(10, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Zoom Scale: ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(10, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Translation Scale: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(10, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Rotation Scale: ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblLineColor);
            this.groupBox3.Controls.Add(this.lblLineText);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.lblOrbColor);
            this.groupBox3.Controls.Add(this.lblOrbText);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Location = new System.Drawing.Point(0, 258);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 62);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bones";
            // 
            // lblLineColor
            // 
            this.lblLineColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLineColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLineColor.Location = new System.Drawing.Point(263, 35);
            this.lblLineColor.Name = "lblLineColor";
            this.lblLineColor.Size = new System.Drawing.Size(40, 20);
            this.lblLineColor.TabIndex = 8;
            this.lblLineColor.Click += new System.EventHandler(this.lblLineColor_Click);
            // 
            // lblLineText
            // 
            this.lblLineText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLineText.BackColor = System.Drawing.Color.White;
            this.lblLineText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLineText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineText.Location = new System.Drawing.Point(76, 35);
            this.lblLineText.Name = "lblLineText";
            this.lblLineText.Size = new System.Drawing.Size(188, 20);
            this.lblLineText.TabIndex = 10;
            this.lblLineText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Location = new System.Drawing.Point(6, 35);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 20);
            this.label20.TabIndex = 9;
            this.label20.Text = "Line Color:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrbColor
            // 
            this.lblOrbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrbColor.Location = new System.Drawing.Point(263, 16);
            this.lblOrbColor.Name = "lblOrbColor";
            this.lblOrbColor.Size = new System.Drawing.Size(40, 20);
            this.lblOrbColor.TabIndex = 5;
            this.lblOrbColor.Click += new System.EventHandler(this.lblOrbColor_Click);
            // 
            // lblOrbText
            // 
            this.lblOrbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrbText.BackColor = System.Drawing.Color.White;
            this.lblOrbText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrbText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrbText.Location = new System.Drawing.Point(76, 16);
            this.lblOrbText.Name = "lblOrbText";
            this.lblOrbText.Size = new System.Drawing.Size(188, 20);
            this.lblOrbText.TabIndex = 7;
            this.lblOrbText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(6, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 20);
            this.label15.TabIndex = 6;
            this.label15.Text = "Orb Color:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lblCol1Color);
            this.groupBox4.Controls.Add(this.lblCol1Text);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Location = new System.Drawing.Point(0, 326);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(315, 42);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Floor";
            // 
            // lblCol1Color
            // 
            this.lblCol1Color.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCol1Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCol1Color.Location = new System.Drawing.Point(263, 16);
            this.lblCol1Color.Name = "lblCol1Color";
            this.lblCol1Color.Size = new System.Drawing.Size(40, 20);
            this.lblCol1Color.TabIndex = 5;
            this.lblCol1Color.Click += new System.EventHandler(this.lblCol1Color_Click);
            // 
            // lblCol1Text
            // 
            this.lblCol1Text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCol1Text.BackColor = System.Drawing.Color.White;
            this.lblCol1Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCol1Text.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol1Text.Location = new System.Drawing.Point(76, 16);
            this.lblCol1Text.Name = "lblCol1Text";
            this.lblCol1Text.Size = new System.Drawing.Size(188, 20);
            this.lblCol1Text.TabIndex = 7;
            this.lblCol1Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Location = new System.Drawing.Point(6, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(71, 20);
            this.label24.TabIndex = 6;
            this.label24.Text = "Color:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maxUndoCount
            // 
            this.maxUndoCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxUndoCount.Location = new System.Drawing.Point(240, 374);
            this.maxUndoCount.Name = "maxUndoCount";
            this.maxUndoCount.Size = new System.Drawing.Size(66, 20);
            this.maxUndoCount.TabIndex = 37;
            this.maxUndoCount.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(120, 376);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "Undo Buffer Maximum:";
            // 
            // ModelViewerSettingsDialog
            // 
            this.AcceptButton = this.btnOkay;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(315, 432);
            this.Controls.Add(this.maxUndoCount);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModelViewerSettingsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Viewer Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private GoodColorDialog _dlgColor;
        private void lblOrbColor_Click(object sender, EventArgs e)
        {
            _dlgColor.Color = MDL0BoneNode.DefaultNodeColor;
            if (_dlgColor.ShowDialog(this) == DialogResult.OK)
            {
                MDL0BoneNode.DefaultNodeColor = _dlgColor.Color;
                UpdateOrb();
            }
        }

        private void lblLineColor_Click(object sender, EventArgs e)
        {
            _dlgColor.Color = MDL0BoneNode.DefaultBoneColor;
            if (_dlgColor.ShowDialog(this) == DialogResult.OK)
            {
                MDL0BoneNode.DefaultBoneColor = _dlgColor.Color;
                UpdateLine();
            }
        }

        private void lblCol1Color_Click(object sender, EventArgs e)
        {
            _dlgColor.Color = ModelEditControl._floorHue;
            if (_dlgColor.ShowDialog(this) == DialogResult.OK)
            {
                ModelEditControl._floorHue = _dlgColor.Color;
                UpdateCol1();
            }
        }

        private void UpdateOrb()
        {
            lblOrbText.Text = ((ARGBPixel)MDL0BoneNode.DefaultNodeColor).ToString();
            lblOrbColor.BackColor = Color.FromArgb(MDL0BoneNode.DefaultNodeColor.R, MDL0BoneNode.DefaultNodeColor.G, MDL0BoneNode.DefaultNodeColor.B);
        }
        private void UpdateLine()
        {
            lblLineText.Text = ((ARGBPixel)MDL0BoneNode.DefaultBoneColor).ToString();
            lblLineColor.BackColor = Color.FromArgb(MDL0BoneNode.DefaultBoneColor.R, MDL0BoneNode.DefaultBoneColor.G, MDL0BoneNode.DefaultBoneColor.B);
        }
        private void UpdateCol1()
        {
            lblCol1Text.Text = ((ARGBPixel)ModelEditControl._floorHue).ToString();
            lblCol1Color.BackColor = Color.FromArgb(ModelEditControl._floorHue.R, ModelEditControl._floorHue.G, ModelEditControl._floorHue.B);
        }
    }
}
