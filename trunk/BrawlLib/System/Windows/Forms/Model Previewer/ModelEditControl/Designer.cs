using System;
using BrawlLib.OpenGL;
using System.ComponentModel;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using BrawlLib.Modeling;
using System.Drawing;
using BrawlLib.Wii.Animations;
using System.Collections.Generic;
using BrawlLib.SSBBTypes;
using BrawlLib.IO;
using BrawlLib;
using System.Drawing.Imaging;
using Gif.Components;
using OpenTK.Graphics.OpenGL;
using BrawlLib.Imaging;

namespace System.Windows.Forms
{
    public partial class ModelEditControl : UserControl
    {
        public AnimModelPanel pnlAssets;
        public ModelMovesetPanel pnlMoveset;
        public ModelPanel modelPanel;
        public ModelAnimPanel pnlBones;
        
        #region Designer

        private ColorDialog dlgColor;
        private Button btnAssetToggle;
        private Button btnAnimToggle;
        private System.ComponentModel.IContainer components;
        private Button btnPlaybackToggle;
        public Timer animTimer;
        private Splitter spltAssets;
        private Button btnOptionToggle;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem openModelsToolStripMenuItem;
        private ToolStripMenuItem kinectToolStripMenuItem;
        private ToolStripMenuItem notYetImplementedToolStripMenuItem;
        private ToolStripMenuItem newSceneToolStripMenuItem;
        private ToolStripMenuItem kinectToolStripMenuItem1;
        private ToolStripMenuItem btnUndo;
        private ToolStripMenuItem btnRedo;
        private ToolStripMenuItem backColorToolStripMenuItem;
        private TransparentPanel KinectPanel;
        private ToolStripMenuItem startTrackingToolStripMenuItem;
        private Label label1;
        private ToolStripMenuItem syncKinectToolStripMenuItem;
        private ToolStripMenuItem targetModelToolStripMenuItem;
        private ToolStripMenuItem hideFromSceneToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem hideAllOtherModelsToolStripMenuItem;
        private ToolStripMenuItem deleteAllOtherModelsToolStripMenuItem;
        private ToolStripMenuItem openModelSwitherToolStripMenuItem;
        private ToolStripMenuItem modelToolStripMenuItem;
        private ToolStripMenuItem toggleBones;
        private ToolStripMenuItem togglePolygons;
        private ToolStripMenuItem toggleVertices;
        private ToolStripMenuItem movesetToolStripMenuItem1;
        private ToolStripMenuItem hitboxesOffToolStripMenuItem;
        private ToolStripMenuItem hurtboxesOffToolStripMenuItem;
        private ToolStripMenuItem modifyLightingToolStripMenuItem;
        private ToolStripMenuItem toggleFloor;
        private ToolStripMenuItem resetCameraToolStripMenuItem;
        private ToolStripMenuItem editorsToolStripMenuItem;
        private ToolStripMenuItem showAssets;
        private ToolStripMenuItem showBones;
        private ToolStripMenuItem showAnim;
        private ToolStripMenuItem showOptions;
        private ToolStripMenuItem showMoveset;
        public CHR0Editor chr0Editor;
        public ComboBox models;
        private Panel controlPanel;
        private Splitter spltAnims;
        private Panel panel1;
        public SRT0Editor srt0Editor;
        private ToolStripMenuItem fileTypesToolStripMenuItem;
        private ToolStripMenuItem playCHR0ToolStripMenuItem;
        private ToolStripMenuItem playSRT0ToolStripMenuItem;
        private ToolStripMenuItem playSHP0ToolStripMenuItem;
        private ToolStripMenuItem playPAT0ToolStripMenuItem;
        private ToolStripMenuItem playVIS0ToolStripMenuItem;
        private ToolStripMenuItem openAnimationsToolStripMenuItem;
        private ToolStripMenuItem openMovesetToolStripMenuItem;
        private ToolStripMenuItem btnOpenClose;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        public VIS0Editor vis0Editor;
        public PAT0Editor pat0Editor;
        public SHP0Editor shp0Editor;
        public Panel animEditors;
        private ToolStrip toolStrip1;
        private ToolStripButton chkHitboxes;
        private Panel panel2;
        private ToolStripButton chkHurtboxes;
        private ToolStripButton chkBones;
        private ToolStripButton chkPolygons;
        private ToolStripButton chkVertices;
        private ToolStripButton chkFloor;
        private ToolStripButton button1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator1;
        public ModelPlaybackPanel pnlPlayback;
        private ToolStripMenuItem showPlay;
        private ToolStripMenuItem displayBRRESRelativeAnimationsToolStripMenuItem;
        private Splitter splitter1;
        public Panel panel3;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripButton chkShaders;
        public ToolStripButton btnSaveCam;
        private SCN0Editor scn0Editor;
        public KeyframePanel pnlKeyframes;
        private Splitter splitter2;
        private ToolStripMenuItem showKeyframes;
        public ToolStripMenuItem showCameraCoordinatesToolStripMenuItem;
        private ToolStripMenuItem sCN0ToolStripMenuItem;
        private ToolStripMenuItem displayAmbienceToolStripMenuItem;
        private ToolStripMenuItem displayLightsToolStripMenuItem;
        private ToolStripMenuItem displayFogToolStripMenuItem;
        private ToolStripMenuItem displayCameraToolStripMenuItem;
        private ToolStripMenuItem displayToolStripMenuItem;
        private ToolStripMenuItem stPersonToolStripMenuItem;
        private ToolStripMenuItem editControlToolStripMenuItem;
        private ToolStripMenuItem rotationToolStripMenuItem;
        private ToolStripMenuItem translationToolStripMenuItem;
        private ToolStripMenuItem scaleToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private CLR0Editor clr0Editor;
        private ToolStripMenuItem playCLR0ToolStripMenuItem;
        private ToolStripMenuItem detachViewerToolStripMenuItem;
        private WeightEditor weightEditor;
        private ToolStripMenuItem backgroundToolStripMenuItem;
        private ToolStripMenuItem setColorToolStripMenuItem;
        private ToolStripMenuItem loadImageToolStripMenuItem;
        private ToolStripMenuItem takeScreenshotToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        public ToolStripMenuItem displayFrameCountDifferencesToolStripMenuItem;
        public ToolStripMenuItem alwaysSyncFrameCountsToolStripMenuItem;
        public ToolStripMenuItem syncAnimationsTogetherToolStripMenuItem;
        public ToolStripMenuItem syncTexObjToolStripMenuItem;
        public ToolStripMenuItem syncObjectsListToVIS0ToolStripMenuItem;
        public ToolStripMenuItem disableBonesWhenPlayingToolStripMenuItem;
        public ToolStripMenuItem syncLoopToAnimationToolStripMenuItem;
        private ToolStripMenuItem btnExportToImgNoTransparency;
        private ToolStripMenuItem btnExportToImgWithTransparency;
        private ToolStripMenuItem btnExportToAnimatedGIF;
        private ToolStripMenuItem saveLocationToolStripMenuItem;
        public ToolStripMenuItem ScreenCapBgLocText;
        private ToolStripMenuItem displaySettingToolStripMenuItem;
        private ToolStripMenuItem stretchToolStripMenuItem1;
        private ToolStripMenuItem centerToolStripMenuItem1;
        private ToolStripMenuItem resizeToolStripMenuItem1;
        private ToolStripMenuItem imageFormatToolStripMenuItem;
        private ToolStripMenuItem projectionToolStripMenuItem;
        private ToolStripMenuItem perspectiveToolStripMenuItem;
        public ToolStripMenuItem orthographicToolStripMenuItem;
        private ToolStripMenuItem firstPersonSCN0CamToolStripMenuItem;
        private ToolStripMenuItem btnLoadMoveset;
        private ToolStripMenuItem btnSaveMoveset;
        private VertexEditor vertexEditor;
        private ToolStripMenuItem boundingBoxToolStripMenuItem;
        private ToolStripMenuItem chkDontRenderOffscreen;
        private ToolStripMenuItem saveCurrentSettingsToolStripMenuItem;
        public ToolStripMenuItem clearSavedSettingsToolStripMenuItem;
        public ToolStripMenuItem storeSettingsExternallyToolStripMenuItem;
        private ToolStripMenuItem toggleNormals;
        private ToolStripMenuItem dontHighlightBonesAndVerticesToolStripMenuItem;
        private Splitter spltMoveset;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.btnAssetToggle = new System.Windows.Forms.Button();
            this.btnAnimToggle = new System.Windows.Forms.Button();
            this.btnPlaybackToggle = new System.Windows.Forms.Button();
            this.animTimer = new System.Windows.Forms.Timer(this.components);
            this.spltAssets = new System.Windows.Forms.Splitter();
            this.btnOptionToggle = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openModelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAnimationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenClose = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMovesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.takeScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportToImgNoTransparency = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportToImgWithTransparency = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportToAnimatedGIF = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScreenCapBgLocText = new System.Windows.Forms.ToolStripMenuItem();
            this.imageFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyLightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayFrameCountDifferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysSyncFrameCountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncAnimationsTogetherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncTexObjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncObjectsListToVIS0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableBonesWhenPlayingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncLoopToAnimationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkDontRenderOffscreen = new System.Windows.Forms.ToolStripMenuItem();
            this.dontHighlightBonesAndVerticesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storeSettingsExternallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSavedSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kinectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.showBones = new System.Windows.Forms.ToolStripMenuItem();
            this.showAssets = new System.Windows.Forms.ToolStripMenuItem();
            this.showMoveset = new System.Windows.Forms.ToolStripMenuItem();
            this.showAnim = new System.Windows.Forms.ToolStripMenuItem();
            this.showPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.showKeyframes = new System.Windows.Forms.ToolStripMenuItem();
            this.detachViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displaySettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.centerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orthographicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleFloor = new System.Windows.Forms.ToolStripMenuItem();
            this.resetCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCameraCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleBones = new System.Windows.Forms.ToolStripMenuItem();
            this.togglePolygons = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleVertices = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleNormals = new System.Windows.Forms.ToolStripMenuItem();
            this.boundingBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movesetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hitboxesOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hurtboxesOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playCHR0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playSRT0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playSHP0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playPAT0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playVIS0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playCLR0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sCN0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayAmbienceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayLightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayFogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstPersonSCN0CamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadMoveset = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveMoveset = new System.Windows.Forms.ToolStripMenuItem();
            this.targetModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideFromSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideAllOtherModelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllOtherModelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openModelSwitherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayBRRESRelativeAnimationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kinectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncKinectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notYetImplementedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTrackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spltMoveset = new System.Windows.Forms.Splitter();
            this.models = new System.Windows.Forms.ComboBox();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.chkHitboxes = new System.Windows.Forms.ToolStripButton();
            this.chkHurtboxes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.chkBones = new System.Windows.Forms.ToolStripButton();
            this.chkPolygons = new System.Windows.Forms.ToolStripButton();
            this.chkShaders = new System.Windows.Forms.ToolStripButton();
            this.chkVertices = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.chkFloor = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.ToolStripButton();
            this.btnSaveCam = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.spltAnims = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.KinectPanel = new System.Windows.Forms.TransparentPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.modelPanel = new System.Windows.Forms.ModelPanel();
            this.animEditors = new System.Windows.Forms.Panel();
            this.pnlPlayback = new System.Windows.Forms.ModelPlaybackPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.vis0Editor = new System.Windows.Forms.VIS0Editor();
            this.pat0Editor = new System.Windows.Forms.PAT0Editor();
            this.shp0Editor = new System.Windows.Forms.SHP0Editor();
            this.srt0Editor = new System.Windows.Forms.SRT0Editor();
            this.chr0Editor = new System.Windows.Forms.CHR0Editor();
            this.scn0Editor = new System.Windows.Forms.SCN0Editor();
            this.clr0Editor = new System.Windows.Forms.CLR0Editor();
            this.weightEditor = new System.Windows.Forms.WeightEditor();
            this.vertexEditor = new System.Windows.Forms.VertexEditor();
            this.pnlMoveset = new System.Windows.Forms.ModelMovesetPanel();
            this.pnlBones = new System.Windows.Forms.ModelAnimPanel();
            this.pnlAssets = new System.Windows.Forms.AnimModelPanel();
            this.pnlKeyframes = new System.Windows.Forms.KeyframePanel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.menuStrip1.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.KinectPanel.SuspendLayout();
            this.animEditors.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgColor
            // 
            this.dlgColor.AnyColor = true;
            this.dlgColor.FullOpen = true;
            // 
            // btnAssetToggle
            // 
            this.btnAssetToggle.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAssetToggle.Location = new System.Drawing.Point(249, 24);
            this.btnAssetToggle.Name = "btnAssetToggle";
            this.btnAssetToggle.Size = new System.Drawing.Size(15, 391);
            this.btnAssetToggle.TabIndex = 5;
            this.btnAssetToggle.TabStop = false;
            this.btnAssetToggle.Text = ">";
            this.btnAssetToggle.UseVisualStyleBackColor = false;
            this.btnAssetToggle.Click += new System.EventHandler(this.btnAssetToggle_Click);
            // 
            // btnAnimToggle
            // 
            this.btnAnimToggle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAnimToggle.Location = new System.Drawing.Point(685, 24);
            this.btnAnimToggle.Name = "btnAnimToggle";
            this.btnAnimToggle.Size = new System.Drawing.Size(15, 391);
            this.btnAnimToggle.TabIndex = 6;
            this.btnAnimToggle.TabStop = false;
            this.btnAnimToggle.Text = "<";
            this.btnAnimToggle.UseVisualStyleBackColor = false;
            this.btnAnimToggle.Click += new System.EventHandler(this.btnAnimToggle_Click);
            // 
            // btnPlaybackToggle
            // 
            this.btnPlaybackToggle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPlaybackToggle.Location = new System.Drawing.Point(264, 400);
            this.btnPlaybackToggle.Name = "btnPlaybackToggle";
            this.btnPlaybackToggle.Size = new System.Drawing.Size(421, 15);
            this.btnPlaybackToggle.TabIndex = 8;
            this.btnPlaybackToggle.TabStop = false;
            this.btnPlaybackToggle.UseVisualStyleBackColor = false;
            this.btnPlaybackToggle.Click += new System.EventHandler(this.btnPlaybackToggle_Click);
            // 
            // animTimer
            // 
            this.animTimer.Interval = 1;
            this.animTimer.Tick += new System.EventHandler(this.animTimer_Tick);
            // 
            // spltAssets
            // 
            this.spltAssets.BackColor = System.Drawing.SystemColors.Control;
            this.spltAssets.Location = new System.Drawing.Point(245, 24);
            this.spltAssets.Name = "spltAssets";
            this.spltAssets.Size = new System.Drawing.Size(4, 391);
            this.spltAssets.TabIndex = 9;
            this.spltAssets.TabStop = false;
            this.spltAssets.Visible = false;
            // 
            // btnOptionToggle
            // 
            this.btnOptionToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOptionToggle.Location = new System.Drawing.Point(264, 24);
            this.btnOptionToggle.Name = "btnOptionToggle";
            this.btnOptionToggle.Size = new System.Drawing.Size(421, 15);
            this.btnOptionToggle.TabIndex = 11;
            this.btnOptionToggle.TabStop = false;
            this.btnOptionToggle.UseVisualStyleBackColor = false;
            this.btnOptionToggle.Click += new System.EventHandler(this.btnOptionToggle_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.kinectToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.targetModelToolStripMenuItem,
            this.kinectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(307, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSceneToolStripMenuItem,
            this.openModelsToolStripMenuItem,
            this.openAnimationsToolStripMenuItem,
            this.openMovesetToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newSceneToolStripMenuItem
            // 
            this.newSceneToolStripMenuItem.Name = "newSceneToolStripMenuItem";
            this.newSceneToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newSceneToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.newSceneToolStripMenuItem.Text = "New Scene";
            this.newSceneToolStripMenuItem.Click += new System.EventHandler(this.newSceneToolStripMenuItem_Click);
            // 
            // openModelsToolStripMenuItem
            // 
            this.openModelsToolStripMenuItem.Name = "openModelsToolStripMenuItem";
            this.openModelsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openModelsToolStripMenuItem.Text = "Load Models";
            this.openModelsToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openAnimationsToolStripMenuItem
            // 
            this.openAnimationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenClose,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.openAnimationsToolStripMenuItem.Name = "openAnimationsToolStripMenuItem";
            this.openAnimationsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openAnimationsToolStripMenuItem.Text = "Animations";
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.btnOpenClose.Size = new System.Drawing.Size(186, 22);
            this.btnOpenClose.Text = "Load";
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "Save ";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // openMovesetToolStripMenuItem
            // 
            this.openMovesetToolStripMenuItem.Name = "openMovesetToolStripMenuItem";
            this.openMovesetToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openMovesetToolStripMenuItem.Text = "Load Moveset";
            this.openMovesetToolStripMenuItem.Visible = false;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUndo,
            this.btnRedo,
            this.takeScreenshotToolStripMenuItem,
            this.modifyLightingToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.storeSettingsExternallyToolStripMenuItem,
            this.saveCurrentSettingsToolStripMenuItem,
            this.clearSavedSettingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.editToolStripMenuItem.Text = "Options";
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.btnUndo.Size = new System.Drawing.Size(199, 22);
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Enabled = false;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.btnRedo.Size = new System.Drawing.Size(199, 22);
            this.btnRedo.Text = "Redo";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // takeScreenshotToolStripMenuItem
            // 
            this.takeScreenshotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportToImgNoTransparency,
            this.btnExportToImgWithTransparency,
            this.btnExportToAnimatedGIF,
            this.saveLocationToolStripMenuItem,
            this.imageFormatToolStripMenuItem});
            this.takeScreenshotToolStripMenuItem.Name = "takeScreenshotToolStripMenuItem";
            this.takeScreenshotToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.takeScreenshotToolStripMenuItem.Text = "Take Screenshot";
            // 
            // btnExportToImgNoTransparency
            // 
            this.btnExportToImgNoTransparency.Name = "btnExportToImgNoTransparency";
            this.btnExportToImgNoTransparency.ShortcutKeyDisplayString = "Ctrl+Shift+I";
            this.btnExportToImgNoTransparency.Size = new System.Drawing.Size(292, 22);
            this.btnExportToImgNoTransparency.Text = "With Background";
            this.btnExportToImgNoTransparency.Click += new System.EventHandler(this.btnExportToImgNoTransparency_Click);
            // 
            // btnExportToImgWithTransparency
            // 
            this.btnExportToImgWithTransparency.Name = "btnExportToImgWithTransparency";
            this.btnExportToImgWithTransparency.ShortcutKeyDisplayString = "Ctrl+Alt+I";
            this.btnExportToImgWithTransparency.Size = new System.Drawing.Size(292, 22);
            this.btnExportToImgWithTransparency.Text = "With Transparent Background";
            this.btnExportToImgWithTransparency.Click += new System.EventHandler(this.btnExportToImgWithTransparency_Click);
            // 
            // btnExportToAnimatedGIF
            // 
            this.btnExportToAnimatedGIF.Enabled = false;
            this.btnExportToAnimatedGIF.Name = "btnExportToAnimatedGIF";
            this.btnExportToAnimatedGIF.Size = new System.Drawing.Size(292, 22);
            this.btnExportToAnimatedGIF.Text = "To Animated GIF";
            this.btnExportToAnimatedGIF.Visible = false;
            // 
            // saveLocationToolStripMenuItem
            // 
            this.saveLocationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScreenCapBgLocText});
            this.saveLocationToolStripMenuItem.Name = "saveLocationToolStripMenuItem";
            this.saveLocationToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.saveLocationToolStripMenuItem.Text = "Save Location";
            // 
            // ScreenCapBgLocText
            // 
            this.ScreenCapBgLocText.Name = "ScreenCapBgLocText";
            this.ScreenCapBgLocText.Size = new System.Drawing.Size(110, 22);
            this.ScreenCapBgLocText.Text = "<null>";
            this.ScreenCapBgLocText.Click += new System.EventHandler(this.ScreenCapBgLocText_Click);
            // 
            // imageFormatToolStripMenuItem
            // 
            this.imageFormatToolStripMenuItem.Name = "imageFormatToolStripMenuItem";
            this.imageFormatToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.imageFormatToolStripMenuItem.Text = "Image Format: PNG";
            this.imageFormatToolStripMenuItem.Click += new System.EventHandler(this.imageFormatToolStripMenuItem_Click);
            // 
            // modifyLightingToolStripMenuItem
            // 
            this.modifyLightingToolStripMenuItem.Name = "modifyLightingToolStripMenuItem";
            this.modifyLightingToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.modifyLightingToolStripMenuItem.Text = "Viewer Settings";
            this.modifyLightingToolStripMenuItem.Click += new System.EventHandler(this.modifyLightingToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayFrameCountDifferencesToolStripMenuItem,
            this.alwaysSyncFrameCountsToolStripMenuItem,
            this.syncAnimationsTogetherToolStripMenuItem,
            this.syncTexObjToolStripMenuItem,
            this.syncObjectsListToVIS0ToolStripMenuItem,
            this.disableBonesWhenPlayingToolStripMenuItem,
            this.syncLoopToAnimationToolStripMenuItem,
            this.chkDontRenderOffscreen,
            this.dontHighlightBonesAndVerticesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // displayFrameCountDifferencesToolStripMenuItem
            // 
            this.displayFrameCountDifferencesToolStripMenuItem.CheckOnClick = true;
            this.displayFrameCountDifferencesToolStripMenuItem.Enabled = false;
            this.displayFrameCountDifferencesToolStripMenuItem.Name = "displayFrameCountDifferencesToolStripMenuItem";
            this.displayFrameCountDifferencesToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.displayFrameCountDifferencesToolStripMenuItem.Text = "Warn if frame counts differ";
            this.displayFrameCountDifferencesToolStripMenuItem.Visible = false;
            // 
            // alwaysSyncFrameCountsToolStripMenuItem
            // 
            this.alwaysSyncFrameCountsToolStripMenuItem.CheckOnClick = true;
            this.alwaysSyncFrameCountsToolStripMenuItem.Enabled = false;
            this.alwaysSyncFrameCountsToolStripMenuItem.Name = "alwaysSyncFrameCountsToolStripMenuItem";
            this.alwaysSyncFrameCountsToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.alwaysSyncFrameCountsToolStripMenuItem.Text = "Always sync frame counts";
            this.alwaysSyncFrameCountsToolStripMenuItem.Visible = false;
            // 
            // syncAnimationsTogetherToolStripMenuItem
            // 
            this.syncAnimationsTogetherToolStripMenuItem.Checked = true;
            this.syncAnimationsTogetherToolStripMenuItem.CheckOnClick = true;
            this.syncAnimationsTogetherToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.syncAnimationsTogetherToolStripMenuItem.Name = "syncAnimationsTogetherToolStripMenuItem";
            this.syncAnimationsTogetherToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.syncAnimationsTogetherToolStripMenuItem.Text = "Retrieve corresponding animations";
            this.syncAnimationsTogetherToolStripMenuItem.CheckedChanged += new System.EventHandler(this.syncAnimationsTogetherToolStripMenuItem_CheckedChanged);
            // 
            // syncTexObjToolStripMenuItem
            // 
            this.syncTexObjToolStripMenuItem.CheckOnClick = true;
            this.syncTexObjToolStripMenuItem.Name = "syncTexObjToolStripMenuItem";
            this.syncTexObjToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.syncTexObjToolStripMenuItem.Text = "Sync texture list with object list";
            this.syncTexObjToolStripMenuItem.CheckedChanged += new System.EventHandler(this.syncTexObjToolStripMenuItem_CheckedChanged);
            // 
            // syncObjectsListToVIS0ToolStripMenuItem
            // 
            this.syncObjectsListToVIS0ToolStripMenuItem.CheckOnClick = true;
            this.syncObjectsListToVIS0ToolStripMenuItem.Name = "syncObjectsListToVIS0ToolStripMenuItem";
            this.syncObjectsListToVIS0ToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.syncObjectsListToVIS0ToolStripMenuItem.Text = "Sync objects list edits to VIS0";
            this.syncObjectsListToVIS0ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.syncObjectsListToVIS0ToolStripMenuItem_CheckedChanged);
            // 
            // disableBonesWhenPlayingToolStripMenuItem
            // 
            this.disableBonesWhenPlayingToolStripMenuItem.Checked = true;
            this.disableBonesWhenPlayingToolStripMenuItem.CheckOnClick = true;
            this.disableBonesWhenPlayingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disableBonesWhenPlayingToolStripMenuItem.Name = "disableBonesWhenPlayingToolStripMenuItem";
            this.disableBonesWhenPlayingToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.disableBonesWhenPlayingToolStripMenuItem.Text = "Disable bones when playing";
            // 
            // syncLoopToAnimationToolStripMenuItem
            // 
            this.syncLoopToAnimationToolStripMenuItem.Name = "syncLoopToAnimationToolStripMenuItem";
            this.syncLoopToAnimationToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.syncLoopToAnimationToolStripMenuItem.Text = "Sync loop checkbox to animation header(s)";
            // 
            // chkDontRenderOffscreen
            // 
            this.chkDontRenderOffscreen.CheckOnClick = true;
            this.chkDontRenderOffscreen.Enabled = false;
            this.chkDontRenderOffscreen.Name = "chkDontRenderOffscreen";
            this.chkDontRenderOffscreen.Size = new System.Drawing.Size(302, 22);
            this.chkDontRenderOffscreen.Text = "Don\'t render offscreen objects";
            this.chkDontRenderOffscreen.Visible = false;
            this.chkDontRenderOffscreen.CheckedChanged += new System.EventHandler(this.chkDontRenderOffscreen_CheckedChanged);
            // 
            // dontHighlightBonesAndVerticesToolStripMenuItem
            // 
            this.dontHighlightBonesAndVerticesToolStripMenuItem.CheckOnClick = true;
            this.dontHighlightBonesAndVerticesToolStripMenuItem.Name = "dontHighlightBonesAndVerticesToolStripMenuItem";
            this.dontHighlightBonesAndVerticesToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.dontHighlightBonesAndVerticesToolStripMenuItem.Text = "Don\'t highlight bones and vertices";
            // 
            // storeSettingsExternallyToolStripMenuItem
            // 
            this.storeSettingsExternallyToolStripMenuItem.CheckOnClick = true;
            this.storeSettingsExternallyToolStripMenuItem.Name = "storeSettingsExternallyToolStripMenuItem";
            this.storeSettingsExternallyToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.storeSettingsExternallyToolStripMenuItem.Text = "Store Settings Externally";
            this.storeSettingsExternallyToolStripMenuItem.CheckedChanged += new System.EventHandler(this.storeSettingsExternallyToolStripMenuItem_CheckedChanged);
            // 
            // saveCurrentSettingsToolStripMenuItem
            // 
            this.saveCurrentSettingsToolStripMenuItem.Name = "saveCurrentSettingsToolStripMenuItem";
            this.saveCurrentSettingsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveCurrentSettingsToolStripMenuItem.Text = "Save Current Settings";
            this.saveCurrentSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentSettingsToolStripMenuItem_Click);
            // 
            // clearSavedSettingsToolStripMenuItem
            // 
            this.clearSavedSettingsToolStripMenuItem.Name = "clearSavedSettingsToolStripMenuItem";
            this.clearSavedSettingsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.clearSavedSettingsToolStripMenuItem.Text = "Clear Saved Settings";
            this.clearSavedSettingsToolStripMenuItem.Click += new System.EventHandler(this.clearSavedSettingsToolStripMenuItem_Click);
            // 
            // kinectToolStripMenuItem1
            // 
            this.kinectToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorsToolStripMenuItem,
            this.backColorToolStripMenuItem,
            this.modelToolStripMenuItem,
            this.movesetToolStripMenuItem1,
            this.fileTypesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.kinectToolStripMenuItem1.Name = "kinectToolStripMenuItem1";
            this.kinectToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.kinectToolStripMenuItem1.Text = "View";
            // 
            // editorsToolStripMenuItem
            // 
            this.editorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOptions,
            this.showBones,
            this.showAssets,
            this.showMoveset,
            this.showAnim,
            this.showPlay,
            this.showKeyframes,
            this.detachViewerToolStripMenuItem});
            this.editorsToolStripMenuItem.Name = "editorsToolStripMenuItem";
            this.editorsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.editorsToolStripMenuItem.Text = "Panels";
            // 
            // showOptions
            // 
            this.showOptions.Name = "showOptions";
            this.showOptions.Size = new System.Drawing.Size(162, 22);
            this.showOptions.Text = "Menu Bar";
            this.showOptions.CheckedChanged += new System.EventHandler(this.showOptions_CheckedChanged);
            this.showOptions.Click += new System.EventHandler(this.showOptions_Click);
            // 
            // showBones
            // 
            this.showBones.Name = "showBones";
            this.showBones.Size = new System.Drawing.Size(162, 22);
            this.showBones.Text = "Bones Panel";
            this.showBones.CheckedChanged += new System.EventHandler(this.showAnim_CheckedChanged);
            this.showBones.Click += new System.EventHandler(this.showAnim_Click);
            // 
            // showAssets
            // 
            this.showAssets.Name = "showAssets";
            this.showAssets.Size = new System.Drawing.Size(162, 22);
            this.showAssets.Text = "Assets Panel";
            this.showAssets.CheckedChanged += new System.EventHandler(this.showAssets_CheckedChanged);
            this.showAssets.Click += new System.EventHandler(this.showAssets_Click);
            // 
            // showMoveset
            // 
            this.showMoveset.Name = "showMoveset";
            this.showMoveset.Size = new System.Drawing.Size(162, 22);
            this.showMoveset.Text = "Moveset Panel";
            this.showMoveset.CheckedChanged += new System.EventHandler(this.showMoveset_CheckedChanged);
            this.showMoveset.Click += new System.EventHandler(this.showMoveset_Click_1);
            // 
            // showAnim
            // 
            this.showAnim.Name = "showAnim";
            this.showAnim.Size = new System.Drawing.Size(162, 22);
            this.showAnim.Text = "Animation Panel";
            this.showAnim.CheckedChanged += new System.EventHandler(this.showPlay_CheckedChanged);
            this.showAnim.Click += new System.EventHandler(this.showPlay_Click);
            // 
            // showPlay
            // 
            this.showPlay.Checked = true;
            this.showPlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPlay.Name = "showPlay";
            this.showPlay.Size = new System.Drawing.Size(162, 22);
            this.showPlay.Text = "Playback Panel";
            this.showPlay.CheckedChanged += new System.EventHandler(this.showPlay_CheckedChanged_1);
            this.showPlay.Click += new System.EventHandler(this.showPlay_Click_1);
            // 
            // showKeyframes
            // 
            this.showKeyframes.Name = "showKeyframes";
            this.showKeyframes.Size = new System.Drawing.Size(162, 22);
            this.showKeyframes.Text = "Keyframe Panel";
            this.showKeyframes.CheckedChanged += new System.EventHandler(this.showKeyframes_CheckedChanged);
            this.showKeyframes.Click += new System.EventHandler(this.showKeyframes_Click);
            // 
            // detachViewerToolStripMenuItem
            // 
            this.detachViewerToolStripMenuItem.Enabled = false;
            this.detachViewerToolStripMenuItem.Name = "detachViewerToolStripMenuItem";
            this.detachViewerToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.detachViewerToolStripMenuItem.Text = "Detach Viewer";
            this.detachViewerToolStripMenuItem.Visible = false;
            this.detachViewerToolStripMenuItem.Click += new System.EventHandler(this.detachViewerToolStripMenuItem_Click);
            // 
            // backColorToolStripMenuItem
            // 
            this.backColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundToolStripMenuItem,
            this.editControlToolStripMenuItem,
            this.projectionToolStripMenuItem,
            this.toggleFloor,
            this.resetCameraToolStripMenuItem,
            this.showCameraCoordinatesToolStripMenuItem});
            this.backColorToolStripMenuItem.Name = "backColorToolStripMenuItem";
            this.backColorToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.backColorToolStripMenuItem.Text = "Viewer";
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setColorToolStripMenuItem,
            this.loadImageToolStripMenuItem,
            this.displaySettingToolStripMenuItem});
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            // 
            // setColorToolStripMenuItem
            // 
            this.setColorToolStripMenuItem.Name = "setColorToolStripMenuItem";
            this.setColorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setColorToolStripMenuItem.Text = "Set Color";
            this.setColorToolStripMenuItem.Click += new System.EventHandler(this.setColorToolStripMenuItem_Click);
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // displaySettingToolStripMenuItem
            // 
            this.displaySettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stretchToolStripMenuItem1,
            this.centerToolStripMenuItem1,
            this.resizeToolStripMenuItem1});
            this.displaySettingToolStripMenuItem.Name = "displaySettingToolStripMenuItem";
            this.displaySettingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.displaySettingToolStripMenuItem.Text = "Display Setting";
            // 
            // stretchToolStripMenuItem1
            // 
            this.stretchToolStripMenuItem1.Checked = true;
            this.stretchToolStripMenuItem1.CheckOnClick = true;
            this.stretchToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stretchToolStripMenuItem1.Name = "stretchToolStripMenuItem1";
            this.stretchToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.stretchToolStripMenuItem1.Text = "Stretch";
            this.stretchToolStripMenuItem1.CheckedChanged += new System.EventHandler(this.stretchToolStripMenuItem_CheckedChanged);
            // 
            // centerToolStripMenuItem1
            // 
            this.centerToolStripMenuItem1.CheckOnClick = true;
            this.centerToolStripMenuItem1.Name = "centerToolStripMenuItem1";
            this.centerToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.centerToolStripMenuItem1.Text = "Center";
            this.centerToolStripMenuItem1.CheckedChanged += new System.EventHandler(this.centerToolStripMenuItem_CheckedChanged);
            // 
            // resizeToolStripMenuItem1
            // 
            this.resizeToolStripMenuItem1.CheckOnClick = true;
            this.resizeToolStripMenuItem1.Name = "resizeToolStripMenuItem1";
            this.resizeToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.resizeToolStripMenuItem1.Text = "Resize";
            this.resizeToolStripMenuItem1.CheckedChanged += new System.EventHandler(this.resizeToolStripMenuItem_CheckedChanged);
            // 
            // editControlToolStripMenuItem
            // 
            this.editControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaleToolStripMenuItem,
            this.rotationToolStripMenuItem,
            this.translationToolStripMenuItem});
            this.editControlToolStripMenuItem.Name = "editControlToolStripMenuItem";
            this.editControlToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.editControlToolStripMenuItem.Text = "Bone Control";
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.CheckOnClick = true;
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.ShortcutKeyDisplayString = "E Key";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.scaleToolStripMenuItem.Text = "Scale";
            this.scaleToolStripMenuItem.CheckedChanged += new System.EventHandler(this.scaleToolStripMenuItem_CheckedChanged);
            // 
            // rotationToolStripMenuItem
            // 
            this.rotationToolStripMenuItem.Checked = true;
            this.rotationToolStripMenuItem.CheckOnClick = true;
            this.rotationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            this.rotationToolStripMenuItem.ShortcutKeyDisplayString = "R Key";
            this.rotationToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.rotationToolStripMenuItem.Text = "Rotation";
            this.rotationToolStripMenuItem.CheckedChanged += new System.EventHandler(this.rotationToolStripMenuItem_CheckedChanged);
            // 
            // translationToolStripMenuItem
            // 
            this.translationToolStripMenuItem.CheckOnClick = true;
            this.translationToolStripMenuItem.Name = "translationToolStripMenuItem";
            this.translationToolStripMenuItem.ShortcutKeyDisplayString = "T Key";
            this.translationToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.translationToolStripMenuItem.Text = "Translation";
            this.translationToolStripMenuItem.CheckedChanged += new System.EventHandler(this.translationToolStripMenuItem_CheckedChanged);
            // 
            // projectionToolStripMenuItem
            // 
            this.projectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perspectiveToolStripMenuItem,
            this.orthographicToolStripMenuItem});
            this.projectionToolStripMenuItem.Enabled = false;
            this.projectionToolStripMenuItem.Name = "projectionToolStripMenuItem";
            this.projectionToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.projectionToolStripMenuItem.Text = "Projection";
            this.projectionToolStripMenuItem.Visible = false;
            // 
            // perspectiveToolStripMenuItem
            // 
            this.perspectiveToolStripMenuItem.Checked = true;
            this.perspectiveToolStripMenuItem.CheckOnClick = true;
            this.perspectiveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.perspectiveToolStripMenuItem.Name = "perspectiveToolStripMenuItem";
            this.perspectiveToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.perspectiveToolStripMenuItem.Text = "Perspective";
            this.perspectiveToolStripMenuItem.CheckedChanged += new System.EventHandler(this.perspectiveToolStripMenuItem_CheckedChanged);
            // 
            // orthographicToolStripMenuItem
            // 
            this.orthographicToolStripMenuItem.CheckOnClick = true;
            this.orthographicToolStripMenuItem.Name = "orthographicToolStripMenuItem";
            this.orthographicToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.orthographicToolStripMenuItem.Text = "Orthographic";
            this.orthographicToolStripMenuItem.CheckedChanged += new System.EventHandler(this.orthographicToolStripMenuItem_CheckedChanged);
            // 
            // toggleFloor
            // 
            this.toggleFloor.Name = "toggleFloor";
            this.toggleFloor.ShortcutKeyDisplayString = "F Key";
            this.toggleFloor.Size = new System.Drawing.Size(214, 22);
            this.toggleFloor.Text = "Floor";
            this.toggleFloor.Click += new System.EventHandler(this.toggleFloor_Click);
            // 
            // resetCameraToolStripMenuItem
            // 
            this.resetCameraToolStripMenuItem.Name = "resetCameraToolStripMenuItem";
            this.resetCameraToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+R";
            this.resetCameraToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.resetCameraToolStripMenuItem.Text = "Reset Camera";
            this.resetCameraToolStripMenuItem.Click += new System.EventHandler(this.resetCameraToolStripMenuItem_Click_1);
            // 
            // showCameraCoordinatesToolStripMenuItem
            // 
            this.showCameraCoordinatesToolStripMenuItem.CheckOnClick = true;
            this.showCameraCoordinatesToolStripMenuItem.Name = "showCameraCoordinatesToolStripMenuItem";
            this.showCameraCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showCameraCoordinatesToolStripMenuItem.Text = "Show Camera Coordinates";
            this.showCameraCoordinatesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showCameraCoordinatesToolStripMenuItem_CheckedChanged);
            // 
            // modelToolStripMenuItem
            // 
            this.modelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleBones,
            this.togglePolygons,
            this.toggleVertices,
            this.toggleNormals,
            this.boundingBoxToolStripMenuItem});
            this.modelToolStripMenuItem.Name = "modelToolStripMenuItem";
            this.modelToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.modelToolStripMenuItem.Text = "Model";
            // 
            // toggleBones
            // 
            this.toggleBones.Checked = true;
            this.toggleBones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleBones.Name = "toggleBones";
            this.toggleBones.ShortcutKeyDisplayString = "V Key";
            this.toggleBones.Size = new System.Drawing.Size(159, 22);
            this.toggleBones.Text = "Bones";
            this.toggleBones.Click += new System.EventHandler(this.toggleBonesToolStripMenuItem_Click);
            // 
            // togglePolygons
            // 
            this.togglePolygons.Checked = true;
            this.togglePolygons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.togglePolygons.Name = "togglePolygons";
            this.togglePolygons.ShortcutKeyDisplayString = "P Key";
            this.togglePolygons.Size = new System.Drawing.Size(159, 22);
            this.togglePolygons.Text = "Polygons";
            this.togglePolygons.Click += new System.EventHandler(this.togglePolygonsToolStripMenuItem_Click);
            // 
            // toggleVertices
            // 
            this.toggleVertices.Name = "toggleVertices";
            this.toggleVertices.ShortcutKeyDisplayString = "V Key";
            this.toggleVertices.Size = new System.Drawing.Size(159, 22);
            this.toggleVertices.Text = "Vertices";
            this.toggleVertices.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toggleNormals
            // 
            this.toggleNormals.CheckOnClick = true;
            this.toggleNormals.Name = "toggleNormals";
            this.toggleNormals.Size = new System.Drawing.Size(159, 22);
            this.toggleNormals.Text = "Normals";
            this.toggleNormals.CheckedChanged += new System.EventHandler(this.toggleNormals_CheckedChanged);
            // 
            // boundingBoxToolStripMenuItem
            // 
            this.boundingBoxToolStripMenuItem.CheckOnClick = true;
            this.boundingBoxToolStripMenuItem.Name = "boundingBoxToolStripMenuItem";
            this.boundingBoxToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.boundingBoxToolStripMenuItem.Text = "Bounding Box";
            this.boundingBoxToolStripMenuItem.CheckedChanged += new System.EventHandler(this.boundingBoxToolStripMenuItem_CheckedChanged);
            // 
            // movesetToolStripMenuItem1
            // 
            this.movesetToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hitboxesOffToolStripMenuItem,
            this.hurtboxesOffToolStripMenuItem});
            this.movesetToolStripMenuItem1.Name = "movesetToolStripMenuItem1";
            this.movesetToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.movesetToolStripMenuItem1.Text = "Moveset";
            this.movesetToolStripMenuItem1.Visible = false;
            // 
            // hitboxesOffToolStripMenuItem
            // 
            this.hitboxesOffToolStripMenuItem.Checked = true;
            this.hitboxesOffToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hitboxesOffToolStripMenuItem.Name = "hitboxesOffToolStripMenuItem";
            this.hitboxesOffToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.hitboxesOffToolStripMenuItem.Text = "Hitboxes";
            this.hitboxesOffToolStripMenuItem.CheckedChanged += new System.EventHandler(this.RenderStateChanged);
            this.hitboxesOffToolStripMenuItem.Click += new System.EventHandler(this.hitboxesOffToolStripMenuItem_Click);
            // 
            // hurtboxesOffToolStripMenuItem
            // 
            this.hurtboxesOffToolStripMenuItem.Checked = true;
            this.hurtboxesOffToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hurtboxesOffToolStripMenuItem.Name = "hurtboxesOffToolStripMenuItem";
            this.hurtboxesOffToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.hurtboxesOffToolStripMenuItem.Text = "Hurtboxes";
            this.hurtboxesOffToolStripMenuItem.CheckedChanged += new System.EventHandler(this.RenderStateChanged);
            this.hurtboxesOffToolStripMenuItem.Click += new System.EventHandler(this.hurtboxesOffToolStripMenuItem_Click);
            // 
            // fileTypesToolStripMenuItem
            // 
            this.fileTypesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playCHR0ToolStripMenuItem,
            this.playSRT0ToolStripMenuItem,
            this.playSHP0ToolStripMenuItem,
            this.playPAT0ToolStripMenuItem,
            this.playVIS0ToolStripMenuItem,
            this.playCLR0ToolStripMenuItem,
            this.sCN0ToolStripMenuItem,
            this.firstPersonSCN0CamToolStripMenuItem});
            this.fileTypesToolStripMenuItem.Name = "fileTypesToolStripMenuItem";
            this.fileTypesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.fileTypesToolStripMenuItem.Text = "Animations";
            // 
            // playCHR0ToolStripMenuItem
            // 
            this.playCHR0ToolStripMenuItem.Checked = true;
            this.playCHR0ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playCHR0ToolStripMenuItem.Name = "playCHR0ToolStripMenuItem";
            this.playCHR0ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.playCHR0ToolStripMenuItem.Text = "Play CHR0";
            this.playCHR0ToolStripMenuItem.Click += new System.EventHandler(this.playCHR0ToolStripMenuItem_Click);
            // 
            // playSRT0ToolStripMenuItem
            // 
            this.playSRT0ToolStripMenuItem.Checked = true;
            this.playSRT0ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playSRT0ToolStripMenuItem.Name = "playSRT0ToolStripMenuItem";
            this.playSRT0ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.playSRT0ToolStripMenuItem.Text = "Play SRT0";
            this.playSRT0ToolStripMenuItem.Click += new System.EventHandler(this.playSRT0ToolStripMenuItem_Click);
            // 
            // playSHP0ToolStripMenuItem
            // 
            this.playSHP0ToolStripMenuItem.Checked = true;
            this.playSHP0ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playSHP0ToolStripMenuItem.Name = "playSHP0ToolStripMenuItem";
            this.playSHP0ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.playSHP0ToolStripMenuItem.Text = "Play SHP0";
            this.playSHP0ToolStripMenuItem.Click += new System.EventHandler(this.playSHP0ToolStripMenuItem_Click);
            // 
            // playPAT0ToolStripMenuItem
            // 
            this.playPAT0ToolStripMenuItem.Checked = true;
            this.playPAT0ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playPAT0ToolStripMenuItem.Name = "playPAT0ToolStripMenuItem";
            this.playPAT0ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.playPAT0ToolStripMenuItem.Text = "Play PAT0";
            this.playPAT0ToolStripMenuItem.Click += new System.EventHandler(this.playPAT0ToolStripMenuItem_Click);
            // 
            // playVIS0ToolStripMenuItem
            // 
            this.playVIS0ToolStripMenuItem.Checked = true;
            this.playVIS0ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playVIS0ToolStripMenuItem.Name = "playVIS0ToolStripMenuItem";
            this.playVIS0ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.playVIS0ToolStripMenuItem.Text = "Play VIS0";
            this.playVIS0ToolStripMenuItem.Click += new System.EventHandler(this.playVIS0ToolStripMenuItem_Click);
            // 
            // playCLR0ToolStripMenuItem
            // 
            this.playCLR0ToolStripMenuItem.Checked = true;
            this.playCLR0ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playCLR0ToolStripMenuItem.Name = "playCLR0ToolStripMenuItem";
            this.playCLR0ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.playCLR0ToolStripMenuItem.Text = "Play CLR0";
            // 
            // sCN0ToolStripMenuItem
            // 
            this.sCN0ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayAmbienceToolStripMenuItem,
            this.displayLightsToolStripMenuItem,
            this.displayFogToolStripMenuItem,
            this.displayCameraToolStripMenuItem});
            this.sCN0ToolStripMenuItem.Name = "sCN0ToolStripMenuItem";
            this.sCN0ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.sCN0ToolStripMenuItem.Text = "SCN0";
            this.sCN0ToolStripMenuItem.Visible = false;
            // 
            // displayAmbienceToolStripMenuItem
            // 
            this.displayAmbienceToolStripMenuItem.Name = "displayAmbienceToolStripMenuItem";
            this.displayAmbienceToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.displayAmbienceToolStripMenuItem.Text = "Display Ambience";
            // 
            // displayLightsToolStripMenuItem
            // 
            this.displayLightsToolStripMenuItem.Name = "displayLightsToolStripMenuItem";
            this.displayLightsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.displayLightsToolStripMenuItem.Text = "Display Light";
            // 
            // displayFogToolStripMenuItem
            // 
            this.displayFogToolStripMenuItem.Name = "displayFogToolStripMenuItem";
            this.displayFogToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.displayFogToolStripMenuItem.Text = "Display Fog";
            // 
            // displayCameraToolStripMenuItem
            // 
            this.displayCameraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripMenuItem,
            this.stPersonToolStripMenuItem});
            this.displayCameraToolStripMenuItem.Name = "displayCameraToolStripMenuItem";
            this.displayCameraToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.displayCameraToolStripMenuItem.Text = "Camera";
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // stPersonToolStripMenuItem
            // 
            this.stPersonToolStripMenuItem.CheckOnClick = true;
            this.stPersonToolStripMenuItem.Name = "stPersonToolStripMenuItem";
            this.stPersonToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.stPersonToolStripMenuItem.Text = "1st Person";
            this.stPersonToolStripMenuItem.CheckedChanged += new System.EventHandler(this.stPersonToolStripMenuItem_CheckedChanged);
            // 
            // firstPersonSCN0CamToolStripMenuItem
            // 
            this.firstPersonSCN0CamToolStripMenuItem.CheckOnClick = true;
            this.firstPersonSCN0CamToolStripMenuItem.Name = "firstPersonSCN0CamToolStripMenuItem";
            this.firstPersonSCN0CamToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.firstPersonSCN0CamToolStripMenuItem.Text = "First Person SCN0 Camera";
            this.firstPersonSCN0CamToolStripMenuItem.CheckedChanged += new System.EventHandler(this.stPersonToolStripMenuItem_CheckedChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadMoveset,
            this.btnSaveMoveset});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 20);
            this.toolStripMenuItem1.Text = "Moveset";
            // 
            // btnLoadMoveset
            // 
            this.btnLoadMoveset.Name = "btnLoadMoveset";
            this.btnLoadMoveset.Size = new System.Drawing.Size(100, 22);
            this.btnLoadMoveset.Text = "Load";
            this.btnLoadMoveset.Click += new System.EventHandler(this.btnLoadMoveset_Click);
            // 
            // btnSaveMoveset
            // 
            this.btnSaveMoveset.Name = "btnSaveMoveset";
            this.btnSaveMoveset.Size = new System.Drawing.Size(100, 22);
            this.btnSaveMoveset.Text = "Save";
            this.btnSaveMoveset.Click += new System.EventHandler(this.btnSaveMoveset_Click);
            // 
            // targetModelToolStripMenuItem
            // 
            this.targetModelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideFromSceneToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.hideAllOtherModelsToolStripMenuItem,
            this.deleteAllOtherModelsToolStripMenuItem,
            this.openModelSwitherToolStripMenuItem,
            this.displayBRRESRelativeAnimationsToolStripMenuItem});
            this.targetModelToolStripMenuItem.Name = "targetModelToolStripMenuItem";
            this.targetModelToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.targetModelToolStripMenuItem.Text = "Target Model:";
            // 
            // hideFromSceneToolStripMenuItem
            // 
            this.hideFromSceneToolStripMenuItem.Name = "hideFromSceneToolStripMenuItem";
            this.hideFromSceneToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.hideFromSceneToolStripMenuItem.Text = "Hide from scene";
            this.hideFromSceneToolStripMenuItem.Click += new System.EventHandler(this.hideFromSceneToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.deleteToolStripMenuItem.Text = "Delete from scene";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // hideAllOtherModelsToolStripMenuItem
            // 
            this.hideAllOtherModelsToolStripMenuItem.Name = "hideAllOtherModelsToolStripMenuItem";
            this.hideAllOtherModelsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.hideAllOtherModelsToolStripMenuItem.Text = "Hide all other models";
            this.hideAllOtherModelsToolStripMenuItem.Click += new System.EventHandler(this.hideAllOtherModelsToolStripMenuItem_Click);
            // 
            // deleteAllOtherModelsToolStripMenuItem
            // 
            this.deleteAllOtherModelsToolStripMenuItem.Name = "deleteAllOtherModelsToolStripMenuItem";
            this.deleteAllOtherModelsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.deleteAllOtherModelsToolStripMenuItem.Text = "Delete all other models";
            this.deleteAllOtherModelsToolStripMenuItem.Click += new System.EventHandler(this.deleteAllOtherModelsToolStripMenuItem_Click);
            // 
            // openModelSwitherToolStripMenuItem
            // 
            this.openModelSwitherToolStripMenuItem.Enabled = false;
            this.openModelSwitherToolStripMenuItem.Name = "openModelSwitherToolStripMenuItem";
            this.openModelSwitherToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.openModelSwitherToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.openModelSwitherToolStripMenuItem.Text = "Open Model Switcher";
            this.openModelSwitherToolStripMenuItem.Visible = false;
            this.openModelSwitherToolStripMenuItem.Click += new System.EventHandler(this.openModelSwitherToolStripMenuItem_Click);
            // 
            // displayBRRESRelativeAnimationsToolStripMenuItem
            // 
            this.displayBRRESRelativeAnimationsToolStripMenuItem.Name = "displayBRRESRelativeAnimationsToolStripMenuItem";
            this.displayBRRESRelativeAnimationsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.displayBRRESRelativeAnimationsToolStripMenuItem.Text = "Displaying all animations";
            this.displayBRRESRelativeAnimationsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.displayBRRESRelativeAnimationsToolStripMenuItem_CheckStateChanged);
            this.displayBRRESRelativeAnimationsToolStripMenuItem.Click += new System.EventHandler(this.displayBRRESRelativeAnimationsToolStripMenuItem_Click);
            // 
            // kinectToolStripMenuItem
            // 
            this.kinectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncKinectToolStripMenuItem,
            this.notYetImplementedToolStripMenuItem,
            this.startTrackingToolStripMenuItem});
            this.kinectToolStripMenuItem.Enabled = false;
            this.kinectToolStripMenuItem.Name = "kinectToolStripMenuItem";
            this.kinectToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.kinectToolStripMenuItem.Text = "Kinect";
            this.kinectToolStripMenuItem.Visible = false;
            // 
            // syncKinectToolStripMenuItem
            // 
            this.syncKinectToolStripMenuItem.Enabled = false;
            this.syncKinectToolStripMenuItem.Name = "syncKinectToolStripMenuItem";
            this.syncKinectToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.syncKinectToolStripMenuItem.Text = "Sync Kinect";
            // 
            // notYetImplementedToolStripMenuItem
            // 
            this.notYetImplementedToolStripMenuItem.Enabled = false;
            this.notYetImplementedToolStripMenuItem.Name = "notYetImplementedToolStripMenuItem";
            this.notYetImplementedToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.notYetImplementedToolStripMenuItem.Text = "Register Pose";
            // 
            // startTrackingToolStripMenuItem
            // 
            this.startTrackingToolStripMenuItem.Enabled = false;
            this.startTrackingToolStripMenuItem.Name = "startTrackingToolStripMenuItem";
            this.startTrackingToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.startTrackingToolStripMenuItem.Text = "Start Tracking";
            this.startTrackingToolStripMenuItem.Click += new System.EventHandler(this.startTrackingToolStripMenuItem_Click);
            // 
            // spltMoveset
            // 
            this.spltMoveset.Location = new System.Drawing.Point(138, 24);
            this.spltMoveset.Name = "spltMoveset";
            this.spltMoveset.Size = new System.Drawing.Size(4, 391);
            this.spltMoveset.TabIndex = 18;
            this.spltMoveset.TabStop = false;
            this.spltMoveset.Visible = false;
            // 
            // models
            // 
            this.models.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.models.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.models.FormattingEnabled = true;
            this.models.Items.AddRange(new object[] {
            "All"});
            this.models.Location = new System.Drawing.Point(310, 1);
            this.models.Name = "models";
            this.models.Size = new System.Drawing.Size(138, 21);
            this.models.TabIndex = 21;
            this.models.SelectedIndexChanged += new System.EventHandler(this.models_SelectedIndexChanged);
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.splitter1);
            this.controlPanel.Controls.Add(this.toolStrip1);
            this.controlPanel.Controls.Add(this.panel2);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(1141, 24);
            this.controlPanel.TabIndex = 22;
            this.controlPanel.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(448, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 24);
            this.splitter1.TabIndex = 31;
            this.splitter1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkHitboxes,
            this.chkHurtboxes,
            this.toolStripSeparator2,
            this.chkBones,
            this.chkPolygons,
            this.chkShaders,
            this.chkVertices,
            this.toolStripSeparator1,
            this.chkFloor,
            this.button1,
            this.btnSaveCam});
            this.toolStrip1.Location = new System.Drawing.Point(448, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.toolStrip1.Size = new System.Drawing.Size(693, 24);
            this.toolStrip1.TabIndex = 30;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // chkHitboxes
            // 
            this.chkHitboxes.Checked = true;
            this.chkHitboxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHitboxes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chkHitboxes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkHitboxes.Name = "chkHitboxes";
            this.chkHitboxes.Size = new System.Drawing.Size(57, 21);
            this.chkHitboxes.Text = "Hitboxes";
            this.chkHitboxes.Visible = false;
            this.chkHitboxes.Click += new System.EventHandler(this.hitboxesOffToolStripMenuItem_Click);
            // 
            // chkHurtboxes
            // 
            this.chkHurtboxes.Checked = true;
            this.chkHurtboxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHurtboxes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chkHurtboxes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkHurtboxes.Name = "chkHurtboxes";
            this.chkHurtboxes.Size = new System.Drawing.Size(65, 21);
            this.chkHurtboxes.Text = "Hurtboxes";
            this.chkHurtboxes.Visible = false;
            this.chkHurtboxes.Click += new System.EventHandler(this.hurtboxesOffToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 24);
            this.toolStripSeparator2.Visible = false;
            // 
            // chkBones
            // 
            this.chkBones.Checked = true;
            this.chkBones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chkBones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkBones.Name = "chkBones";
            this.chkBones.Size = new System.Drawing.Size(43, 21);
            this.chkBones.Text = "Bones";
            this.chkBones.CheckedChanged += new System.EventHandler(this.chkBones_CheckedChanged);
            this.chkBones.Click += new System.EventHandler(this.chkBones_Click);
            // 
            // chkPolygons
            // 
            this.chkPolygons.Checked = true;
            this.chkPolygons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPolygons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chkPolygons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkPolygons.Name = "chkPolygons";
            this.chkPolygons.Size = new System.Drawing.Size(60, 21);
            this.chkPolygons.Text = "Polygons";
            this.chkPolygons.CheckStateChanged += new System.EventHandler(this.chkPolygons_CheckStateChanged);
            this.chkPolygons.Click += new System.EventHandler(this.chkPolygons_Click);
            // 
            // chkShaders
            // 
            this.chkShaders.CheckOnClick = true;
            this.chkShaders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chkShaders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkShaders.Name = "chkShaders";
            this.chkShaders.Size = new System.Drawing.Size(52, 21);
            this.chkShaders.Text = "Shaders";
            this.chkShaders.Visible = false;
            this.chkShaders.CheckedChanged += new System.EventHandler(this.chkShaders_CheckedChanged);
            // 
            // chkVertices
            // 
            this.chkVertices.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chkVertices.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkVertices.Name = "chkVertices";
            this.chkVertices.Size = new System.Drawing.Size(52, 21);
            this.chkVertices.Text = "Vertices";
            this.chkVertices.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            this.chkVertices.Click += new System.EventHandler(this.chkVertices_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
            // 
            // chkFloor
            // 
            this.chkFloor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chkFloor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkFloor.Name = "chkFloor";
            this.chkFloor.Size = new System.Drawing.Size(38, 21);
            this.chkFloor.Text = "Floor";
            this.chkFloor.CheckedChanged += new System.EventHandler(this.chkFloor_CheckedChanged);
            this.chkFloor.Click += new System.EventHandler(this.chkFloor_Click);
            // 
            // button1
            // 
            this.button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 21);
            this.button1.Text = "Reset Camera";
            this.button1.Click += new System.EventHandler(this.resetCameraToolStripMenuItem_Click_1);
            // 
            // btnSaveCam
            // 
            this.btnSaveCam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSaveCam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveCam.Name = "btnSaveCam";
            this.btnSaveCam.Size = new System.Drawing.Size(79, 21);
            this.btnSaveCam.Text = "Save Camera";
            this.btnSaveCam.Click += new System.EventHandler(this.btnSaveCam_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.models);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 24);
            this.panel2.TabIndex = 29;
            // 
            // spltAnims
            // 
            this.spltAnims.Dock = System.Windows.Forms.DockStyle.Right;
            this.spltAnims.Location = new System.Drawing.Point(700, 24);
            this.spltAnims.Name = "spltAnims";
            this.spltAnims.Size = new System.Drawing.Size(4, 391);
            this.spltAnims.TabIndex = 23;
            this.spltAnims.TabStop = false;
            this.spltAnims.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.KinectPanel);
            this.panel1.Controls.Add(this.modelPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(264, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 361);
            this.panel1.TabIndex = 25;
            // 
            // KinectPanel
            // 
            this.KinectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KinectPanel.BackColor = System.Drawing.Color.Transparent;
            this.KinectPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.KinectPanel.Controls.Add(this.label1);
            this.KinectPanel.Location = new System.Drawing.Point(376, 0);
            this.KinectPanel.Name = "KinectPanel";
            this.KinectPanel.Size = new System.Drawing.Size(45, 38);
            this.KinectPanel.TabIndex = 14;
            this.KinectPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Open";
            // 
            // modelPanel
            // 
            this.modelPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelPanel.InitialYFactor = 100;
            this.modelPanel.InitialZoomFactor = 5;
            this.modelPanel.Location = new System.Drawing.Point(0, 0);
            this.modelPanel.Name = "modelPanel";
            this.modelPanel.RotationScale = 0.4F;
            this.modelPanel.Size = new System.Drawing.Size(421, 361);
            this.modelPanel.TabIndex = 0;
            this.modelPanel.TranslationScale = 0.05F;
            this.modelPanel.ZoomScale = 2.5F;
            this.modelPanel.PreRender += new System.Windows.Forms.GLRenderEventHandler(this.modelPanel1_PreRender);
            this.modelPanel.PostRender += new System.Windows.Forms.GLRenderEventHandler(this.modelPanel1_PostRender);
            this.modelPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.modelPanel1_MouseDown);
            this.modelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.modelPanel1_MouseMove);
            this.modelPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.modelPanel1_MouseUp);
            // 
            // animEditors
            // 
            this.animEditors.AutoScroll = true;
            this.animEditors.Controls.Add(this.pnlPlayback);
            this.animEditors.Controls.Add(this.panel3);
            this.animEditors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.animEditors.Location = new System.Drawing.Point(0, 415);
            this.animEditors.Name = "animEditors";
            this.animEditors.Size = new System.Drawing.Size(1141, 60);
            this.animEditors.TabIndex = 29;
            this.animEditors.Visible = false;
            // 
            // pnlPlayback
            // 
            this.pnlPlayback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayback.Enabled = false;
            this.pnlPlayback.Location = new System.Drawing.Point(264, 0);
            this.pnlPlayback.MinimumSize = new System.Drawing.Size(290, 54);
            this.pnlPlayback.Name = "pnlPlayback";
            this.pnlPlayback.Size = new System.Drawing.Size(877, 60);
            this.pnlPlayback.TabIndex = 15;
            this.pnlPlayback.Resize += new System.EventHandler(this.pnlPlayback_Resize);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.vis0Editor);
            this.panel3.Controls.Add(this.pat0Editor);
            this.panel3.Controls.Add(this.shp0Editor);
            this.panel3.Controls.Add(this.srt0Editor);
            this.panel3.Controls.Add(this.chr0Editor);
            this.panel3.Controls.Add(this.scn0Editor);
            this.panel3.Controls.Add(this.clr0Editor);
            this.panel3.Controls.Add(this.weightEditor);
            this.panel3.Controls.Add(this.vertexEditor);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(264, 60);
            this.panel3.TabIndex = 29;
            // 
            // vis0Editor
            // 
            this.vis0Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vis0Editor.Location = new System.Drawing.Point(0, 0);
            this.vis0Editor.Name = "vis0Editor";
            this.vis0Editor.Padding = new System.Windows.Forms.Padding(4);
            this.vis0Editor.Size = new System.Drawing.Size(264, 60);
            this.vis0Editor.TabIndex = 26;
            this.vis0Editor.Visible = false;
            // 
            // pat0Editor
            // 
            this.pat0Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pat0Editor.Location = new System.Drawing.Point(0, 0);
            this.pat0Editor.Name = "pat0Editor";
            this.pat0Editor.Size = new System.Drawing.Size(264, 60);
            this.pat0Editor.TabIndex = 27;
            this.pat0Editor.Visible = false;
            // 
            // shp0Editor
            // 
            this.shp0Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shp0Editor.Location = new System.Drawing.Point(0, 0);
            this.shp0Editor.Name = "shp0Editor";
            this.shp0Editor.Size = new System.Drawing.Size(264, 60);
            this.shp0Editor.TabIndex = 28;
            this.shp0Editor.Visible = false;
            // 
            // srt0Editor
            // 
            this.srt0Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.srt0Editor.Location = new System.Drawing.Point(0, 0);
            this.srt0Editor.Name = "srt0Editor";
            this.srt0Editor.Size = new System.Drawing.Size(264, 60);
            this.srt0Editor.TabIndex = 20;
            this.srt0Editor.Visible = false;
            // 
            // chr0Editor
            // 
            this.chr0Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chr0Editor.Location = new System.Drawing.Point(0, 0);
            this.chr0Editor.Name = "chr0Editor";
            this.chr0Editor.Size = new System.Drawing.Size(264, 60);
            this.chr0Editor.TabIndex = 19;
            this.chr0Editor.Visible = false;
            this.chr0Editor.VisibleChanged += new System.EventHandler(this.chr0Editor_VisibleChanged);
            // 
            // scn0Editor
            // 
            this.scn0Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scn0Editor.Location = new System.Drawing.Point(0, 0);
            this.scn0Editor.Name = "scn0Editor";
            this.scn0Editor.Size = new System.Drawing.Size(264, 60);
            this.scn0Editor.TabIndex = 30;
            this.scn0Editor.Visible = false;
            // 
            // clr0Editor
            // 
            this.clr0Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clr0Editor.Location = new System.Drawing.Point(0, 0);
            this.clr0Editor.Name = "clr0Editor";
            this.clr0Editor.Size = new System.Drawing.Size(264, 60);
            this.clr0Editor.TabIndex = 30;
            this.clr0Editor.Visible = false;
            // 
            // weightEditor
            // 
            this.weightEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weightEditor.Location = new System.Drawing.Point(0, 0);
            this.weightEditor.Name = "weightEditor";
            this.weightEditor.Size = new System.Drawing.Size(264, 60);
            this.weightEditor.TabIndex = 31;
            this.weightEditor.Visible = false;
            this.weightEditor.WeightIncrement = 0.1F;
            // 
            // vertexEditor
            // 
            this.vertexEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vertexEditor.Enabled = false;
            this.vertexEditor.Location = new System.Drawing.Point(0, 0);
            this.vertexEditor.Name = "vertexEditor";
            this.vertexEditor.Size = new System.Drawing.Size(264, 60);
            this.vertexEditor.TabIndex = 32;
            this.vertexEditor.Visible = false;
            // 
            // pnlMoveset
            // 
            this.pnlMoveset.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMoveset.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMoveset.Location = new System.Drawing.Point(927, 24);
            this.pnlMoveset.Name = "pnlMoveset";
            this.pnlMoveset.Size = new System.Drawing.Size(214, 391);
            this.pnlMoveset.TabIndex = 17;
            this.pnlMoveset.Visible = false;
            this.pnlMoveset.FileChanged += new System.EventHandler(this.FileChanged);
            // 
            // pnlBones
            // 
            this.pnlBones.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBones.Location = new System.Drawing.Point(142, 24);
            this.pnlBones.Name = "pnlBones";
            this.pnlBones.Size = new System.Drawing.Size(103, 391);
            this.pnlBones.TabIndex = 20;
            this.pnlBones.Visible = false;
            // 
            // pnlAssets
            // 
            this.pnlAssets.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAssets.Location = new System.Drawing.Point(0, 24);
            this.pnlAssets.Name = "pnlAssets";
            this.pnlAssets.Size = new System.Drawing.Size(138, 391);
            this.pnlAssets.TabIndex = 4;
            this.pnlAssets.TargetAnimType = System.Windows.Forms.AnimType.None;
            this.pnlAssets.Visible = false;
            // 
            // pnlKeyframes
            // 
            this.pnlKeyframes.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlKeyframes.FrameCount = -1;
            this.pnlKeyframes.Location = new System.Drawing.Point(704, 24);
            this.pnlKeyframes.Name = "pnlKeyframes";
            this.pnlKeyframes.Size = new System.Drawing.Size(219, 391);
            this.pnlKeyframes.TabIndex = 30;
            this.pnlKeyframes.Visible = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(923, 24);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(4, 391);
            this.splitter2.TabIndex = 31;
            this.splitter2.TabStop = false;
            this.splitter2.Visible = false;
            // 
            // ModelEditControl
            // 
            this.AllowDrop = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOptionToggle);
            this.Controls.Add(this.btnPlaybackToggle);
            this.Controls.Add(this.btnAnimToggle);
            this.Controls.Add(this.spltAnims);
            this.Controls.Add(this.pnlKeyframes);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pnlMoveset);
            this.Controls.Add(this.btnAssetToggle);
            this.Controls.Add(this.spltAssets);
            this.Controls.Add(this.pnlBones);
            this.Controls.Add(this.spltMoveset);
            this.Controls.Add(this.pnlAssets);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.animEditors);
            this.Name = "ModelEditControl";
            this.Size = new System.Drawing.Size(1141, 475);
            this.SizeChanged += new System.EventHandler(this.ModelEditControl_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ModelEditControl_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ModelEditControl_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.KinectPanel.ResumeLayout(false);
            this.KinectPanel.PerformLayout();
            this.animEditors.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Initialization

        public ModelEditControl()
        {
            InitializeComponent();
            pnlAssets._mainWindow =
            pnlBones._mainWindow =
            pnlMoveset._mainWindow =
            pnlPlayback._mainWindow =
            pnlKeyframes._mainWindow =
            chr0Editor._mainWindow =
            srt0Editor._mainWindow =
            shp0Editor._mainWindow =
            pat0Editor._mainWindow =
            vis0Editor._mainWindow =
            scn0Editor._mainWindow =
            clr0Editor._mainWindow =
            weightEditor._mainWindow =
            vertexEditor._mainWindow =
            modelPanel._mainWindow = this;

            pnlKeyframes.visEditor._mainWindow = vis0Editor;

            animEditors.HorizontalScroll.Enabled = addedHeight = (!(animEditors.Width - panel3.Width >= pnlPlayback.MinimumSize.Width));
            if (pnlPlayback.Width <= pnlPlayback.MinimumSize.Width)
            {
                pnlPlayback.Dock = DockStyle.Left;
                pnlPlayback.Width = pnlPlayback.MinimumSize.Width;
            }
            else
                pnlPlayback.Dock = DockStyle.Fill;

            TargetAnimType = AnimType.CHR;

            m_DelegateOpenFile = new DelegateOpenFile(this.OpenFile);

            ScreenCapBgLocText.Text = Application.StartupPath;
        }

        #endregion

        private void pnlPlayback_Resize(object sender, EventArgs e)
        {
            if (pnlPlayback.Width <= pnlPlayback.MinimumSize.Width)
            {
                pnlPlayback.Dock = DockStyle.Left;
                pnlPlayback.Width = pnlPlayback.MinimumSize.Width;
            }
            else
                pnlPlayback.Dock = DockStyle.Fill;
        }

        bool addedHeight = false;
        private void ModelEditControl_SizeChanged(object sender, EventArgs e)
        {
            CheckDimensions();
        }

        public void CheckDimensions()
        {
            if (pnlPlayback.Width <= pnlPlayback.MinimumSize.Width)
            {
                pnlPlayback.Dock = DockStyle.Left;
                pnlPlayback.Width = pnlPlayback.MinimumSize.Width;
            }
            else
                pnlPlayback.Dock = DockStyle.Fill;

            if (_updating)
                return;

            if (animEditors.Width - panel3.Width >= pnlPlayback.MinimumSize.Width)
            {
                pnlPlayback.Width += animEditors.Width - panel3.Width - pnlPlayback.MinimumSize.Width;
                pnlPlayback.Dock = DockStyle.Fill;
            }
            else pnlPlayback.Dock = DockStyle.Left;

            if (panel3.Width + pnlPlayback.Width <= animEditors.Width)
            {
                if (addedHeight)
                {
                    _updating = true;
                    animEditors.Height -= 17;
                    _updating = false;
                    animEditors.HorizontalScroll.Visible = addedHeight = false;
                }
            }
            else
            {
                if (!addedHeight)
                {
                    _updating = true;
                    animEditors.Height += 17;
                    _updating = false;
                    animEditors.HorizontalScroll.Visible = addedHeight = true;
                }
            }
        }
    }

    public class TransparentPanel : Panel
    {
        public TransparentPanel() { SetStyle(ControlStyles.UserPaint, true); }

        bool _transparent = true;

        protected override CreateParams CreateParams
        {
            get
            {
                if (_transparent)
                {
                    CreateParams createParams = base.CreateParams;
                    createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                    return createParams;
                }
                else return base.CreateParams;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)0x84)
                m.Result = (IntPtr)(-1);
            else
                base.WndProc(ref m);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (_transparent)
            {
                // Do not paint background.
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }
    }
}
