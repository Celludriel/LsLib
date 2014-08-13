// Type: Glasses.GlassesEditor
// Assembly: Glasses, Version=1.0.7.0, Culture=neutral, PublicKeyToken=null
// MVID: 093399A3-A356-4FDA-B1D2-1CE6B3AABC60
// Assembly location: D:\Apps\Steam\SteamApps\common\The Divinity Engine\TheDivinityEngine.exe

using EoCPlugin;
using KeywordPlugin;
using LSFrameworkPlugin;
using LSMaterialPlugin;
using LSToolFramework;
using StoryPlugin;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Glasses
{
    public class GlassesEditor : Form
    {
        private DockPanel panMain;
        private Container components;
        private bool allowShutdown;
        private bool closing;

        public GlassesEditor()
        {
            this.InitializeComponent();
            this.allowShutdown = false;
            this.closing = false;
        }

        ~GlassesEditor()
        {
            ToolFramework.Instance.ServiceManagerInstance.StopServices();
            ((PluginService)ToolFramework.Instance.ServiceManagerInstance.GetService(typeof(PluginService))).RemoveAll();
            if (this.components != null)
                this.components.Dispose();
        }

        private void InitializeComponent()
        {
            DockPanelSkin dockPanelSkin = new DockPanelSkin();
            AutoHideStripSkin autoHideStripSkin = new AutoHideStripSkin();
            DockPaneStripSkin dockPaneStripSkin = new DockPaneStripSkin();
            DockPaneStripGradient paneStripGradient = new DockPaneStripGradient();
            DockPaneStripToolWindowGradient toolWindowGradient = new DockPaneStripToolWindowGradient();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GlassesEditor));

            this.panMain = new DockPanel();
            this.SuspendLayout();
            this.panMain.ActiveAutoHideContent = (IDockContent)null;
            this.panMain.Dock = DockStyle.Fill;
            this.panMain.DockBackColor = SystemColors.Control;
            this.panMain.DockLeftPortion = 0.15;
            this.panMain.DocumentStyle = DocumentStyle.DockingWindow;
            this.panMain.Location = new Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new Size(1183, 580);

            DockPanelGradient hideStripGradient = new DockPanelGradient();
            hideStripGradient.EndColor = SystemColors.ControlLight;
            hideStripGradient.StartColor = SystemColors.ControlLight;
            autoHideStripSkin.DockStripGradient = hideStripGradient;

            TabGradient tabGradient = new TabGradient();
            tabGradient.EndColor = SystemColors.Control;
            tabGradient.StartColor = SystemColors.Control;
            tabGradient.TextColor = SystemColors.ControlDarkDark;
            autoHideStripSkin.TabGradient = tabGradient;
            autoHideStripSkin.TextFont = new Font("Segoe UI", 9f);
            dockPanelSkin.AutoHideStripSkin = autoHideStripSkin;

            TabGradient activeTabGradient = new TabGradient();
            activeTabGradient.EndColor = SystemColors.ControlLightLight;
            activeTabGradient.StartColor = SystemColors.ControlLightLight;
            activeTabGradient.TextColor = SystemColors.ControlText;
            paneStripGradient.ActiveTabGradient = activeTabGradient;

            DockPanelGradient dockStripGradient = new DockPanelGradient();
            dockStripGradient.EndColor = SystemColors.Control;
            dockStripGradient.StartColor = SystemColors.Control;
            paneStripGradient.DockStripGradient = dockStripGradient;

            TabGradient inactiveTabGradient = new TabGradient();
            inactiveTabGradient.EndColor = SystemColors.ControlLightLight;
            inactiveTabGradient.StartColor = SystemColors.ControlLightLight;
            inactiveTabGradient.TextColor = SystemColors.ControlText;
            paneStripGradient.InactiveTabGradient = inactiveTabGradient;
            dockPaneStripSkin.DocumentGradient = paneStripGradient;
            dockPaneStripSkin.TextFont = new Font("Segoe UI", 9f);

            TabGradient activeCaptionGradient = new TabGradient();
            activeCaptionGradient.EndColor = SystemColors.ActiveCaption;
            activeCaptionGradient.LinearGradientMode = LinearGradientMode.Vertical;
            activeCaptionGradient.StartColor = SystemColors.GradientActiveCaption;
            activeCaptionGradient.TextColor = SystemColors.ActiveCaptionText;
            toolWindowGradient.ActiveCaptionGradient = activeCaptionGradient;

            TabGradient toolActiveGradient = new TabGradient();
            toolActiveGradient.EndColor = SystemColors.Control;
            toolActiveGradient.StartColor = SystemColors.Control;
            toolActiveGradient.TextColor = SystemColors.ControlText;
            toolWindowGradient.ActiveTabGradient = toolActiveGradient;

            DockPanelGradient toolStripGradient = new DockPanelGradient();
            toolStripGradient.EndColor = SystemColors.ControlLight;
            toolStripGradient.StartColor = SystemColors.ControlLight;
            toolWindowGradient.DockStripGradient = toolStripGradient;

            TabGradient toolInactiveGradient = new TabGradient();
            toolInactiveGradient.EndColor = SystemColors.InactiveCaption;
            toolInactiveGradient.LinearGradientMode = LinearGradientMode.Vertical;
            toolInactiveGradient.StartColor = SystemColors.GradientInactiveCaption;
            toolInactiveGradient.TextColor = SystemColors.InactiveCaptionText;
            toolWindowGradient.InactiveCaptionGradient = toolInactiveGradient;

            TabGradient toolInactiveTabGradient = new TabGradient();
            toolInactiveTabGradient.EndColor = Color.Transparent;
            toolInactiveTabGradient.StartColor = Color.Transparent;
            toolInactiveTabGradient.TextColor = SystemColors.ControlDarkDark;
            toolWindowGradient.InactiveTabGradient = toolInactiveTabGradient;

            dockPaneStripSkin.ToolWindowGradient = toolWindowGradient;
            dockPanelSkin.DockPaneStripSkin = dockPaneStripSkin;
            this.panMain.Skin = dockPanelSkin;
            this.panMain.TabIndex = 0;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1183, 580);
            this.Controls.Add((Control)this.panMain);
            // this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
            this.IsMdiContainer = true;
            this.Name = "TheDivinityEngine";
            this.Text = "The Divinity Engine - Pluggable Edition :)";
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(GlassesEditorLoad);
            this.KeyPress += new KeyPressEventHandler(GlassesEditor_KeyPress);
            this.KeyUp += new KeyEventHandler(GlassesEditor_KeyUp);
            this.FormClosing += new FormClosingEventHandler(GlassesEditor_FormClosing);
            this.KeyDown += new KeyEventHandler(GlassesEditor_KeyDown);
            this.ResumeLayout(false);
        }

        private void GlassesEditorLoad(object _param1, EventArgs _param2)
        {
            this.Start();
        }

        private void GlassesEditor_FormClosing(object __unnamed000, FormClosingEventArgs e)
        {
            SaveService saveService = (SaveService)ToolFramework.Instance.ServiceManagerInstance.GetService(typeof(SaveService));
            if (saveService != null && !saveService.Stop())
                e.Cancel = true;
            else if (!this.allowShutdown)
            {
                if (ToolFramework.Instance.Game != null)
                    ToolFramework.Instance.Game.Exit();
                e.Cancel = true;
                this.closing = true;
            }
            else
            {
                TickService tickService = (TickService)ToolFramework.Instance.ServiceManagerInstance.GetService(typeof(TickService));
                if (tickService != null)
                    tickService.Stop();
            }
        }

        private void OnAppStopped(object _param1, EventArgs _param2)
        {
            this.allowShutdown = true;
            if (this.closing)
                this.Close();
        }

        private void OnModuleLoaded(object _param1, EventArgs _param2)
        {
            StoryEditorPlugin.SetOsirisManager(EoCPluginClass.GetOsirisManager());
        }

        public void AddBuiltinPlugins(PluginService pluginService)
        {
            pluginService.AddPlugin((IPlugin)new AutoSavePlugin());
            pluginService.AddPlugin((IPlugin)new FrameworkPlugin());
            pluginService.AddPlugin((IPlugin)new RootTemplatePlugin());
            pluginService.AddPlugin((IPlugin)new EoCPluginClass());
            pluginService.AddPlugin((IPlugin)new ModulePlugin());
            pluginService.AddPlugin((IPlugin)new ResourceManagerPlugin());
            pluginService.AddPlugin((IPlugin)new AtmospherePlugin());
            pluginService.AddPlugin((IPlugin)new TerrainPlugin());
            pluginService.AddPlugin((IPlugin)new AIPlugin());
            pluginService.AddPlugin((IPlugin)new CharactersPlugin());
            pluginService.AddPlugin((IPlugin)new ItemsPlugin());
            pluginService.AddPlugin((IPlugin)new LightPlugin());
            pluginService.AddPlugin((IPlugin)new InvalidObjectPlugin());
            pluginService.AddPlugin((IPlugin)new DecalPlugin());
            pluginService.AddPlugin((IPlugin)new DummyPlugin());
            pluginService.AddPlugin((IPlugin)new ReferencePlugin());
            pluginService.AddPlugin((IPlugin)new TriggersPlugin());
            pluginService.AddPlugin((IPlugin)new WallConstructionPlugin());
            pluginService.AddPlugin((IPlugin)new LevelPlugin());
            pluginService.AddPlugin((IPlugin)new MaterialPlugin());
            pluginService.AddPlugin((IPlugin)new ScriptPlugin());
            pluginService.AddPlugin((IPlugin)new PrefabPlugin());
            pluginService.AddPlugin((IPlugin)new InstancePlugin());
            pluginService.AddPlugin((IPlugin)new StoryEditorPlugin());
            pluginService.AddPlugin((IPlugin)new SelectDoubleVisuals());
            pluginService.AddPlugin((IPlugin)new KeywordPluginClass());
            pluginService.AddPlugin((IPlugin)new TranslatedStringKeyPlugin());
            pluginService.AddPlugin((IPlugin)new TextureAtlasPlugin());
            pluginService.AddPlugin((IPlugin)new ViewModePlugin());
            pluginService.AddPlugin((IPlugin)new OBJExporterPlugin());
            pluginService.AddPlugin((IPlugin)new EoCWorldMapRendererPlugin());
            pluginService.AddPlugin((IPlugin)new PublishPlugin());
            pluginService.AddPlugin((IPlugin)new ModPlugin());
            pluginService.AddPlugin((IPlugin)new AutoTemplatePlacer());
            pluginService.AddPlugin((IPlugin)new FixPlugin());
            pluginService.AddPlugin((IPlugin)new SpeakerPlugin());
        }

        public void DiscoverAndAddPlugins(PluginService pluginService)
        {
            DirectoryInfo pluginsDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Larian Studios\\Divinity Original Sin\\EditorPlugins");

            if (pluginsDir.Exists)
            {
                foreach (var file in pluginsDir.GetFiles("*Plugin.dll"))
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFrom(file.FullName);
                        foreach (Type type in assembly.GetTypes())
                        {
                            if (type.IsSubclassOf(typeof(IPlugin)) && type.IsPublic && !type.IsAbstract)
                            {
                                IPlugin plugin = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null) as IPlugin;
                                pluginService.AddPlugin(plugin);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Failed to initialize plugin " + file.Name + ":" + Environment.NewLine + Environment.NewLine + e.ToString(), "Plugin load failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public void Start()
        {
            ToolFramework instance = ToolFramework.Instance;
            instance.MainForm = (Form)this;
            instance.MainDockPanel = this.panMain;
            instance.Init();

            PluginService pluginService = (PluginService)ToolFramework.Instance.ServiceManagerInstance.GetService(typeof(PluginService));
            AddBuiltinPlugins(pluginService);
            DiscoverAndAddPlugins(pluginService);

            instance.StatusBar = new EntityStatusBar();
            instance.StatusBar.Dock = DockStyle.Bottom;
            instance.MainDockPanel.Controls.Add((Control)ToolFramework.Instance.StatusBar);

            instance.ServiceManagerInstance.StartServices();

            IGame game = instance.Game;
            game.AppStopped += new EventHandler(this.OnAppStopped);
            game.ModuleLoaded += new EventHandler(this.OnModuleLoaded);
            game.ModuleLoaded += new EventHandler(ModBackend.Instance.OnModuleLoaded);
            game.ModuleUnloaded += new EventHandler(ModBackend.Instance.OnModuleUnLoaded);

            KeywordPluginClass keywordPluginClass = (KeywordPluginClass)((PluginService)ToolFramework.Instance.ServiceManagerInstance.GetService(typeof(PluginService))).GetPlugin(typeof(KeywordPluginClass));
            if (keywordPluginClass != null)
                keywordPluginClass.SetKeywordManager(EoCPluginClass.GetKeywordManager());
            StoryPanel.RegisterCustomAutoCompleteMenuAction(3, "Insert Item Template", new EventHandler(MStoryTemplateCompletion.Instance.InsertItemTemplate));
            StoryPanel.RegisterCustomAutoCompleteMenuAction(3, "Insert Character Template", new EventHandler(MStoryTemplateCompletion.Instance.InsertCharacterTemplate));
            ((ToolBarService)ToolFramework.Instance.ServiceManagerInstance.GetService(typeof(ToolBarService))).DisableUI();
        }

        private void GlassesEditor_KeyDown(object sender, KeyEventArgs e)
        {
            ServiceManager serviceManagerInstance = ToolFramework.Instance.ServiceManagerInstance;
            if (serviceManagerInstance != null)
                serviceManagerInstance.KeyDown(sender, e);
        }

        private void GlassesEditor_KeyUp(object sender, KeyEventArgs e)
        {
            ServiceManager serviceManagerInstance = ToolFramework.Instance.ServiceManagerInstance;
            if (serviceManagerInstance != null)
                serviceManagerInstance.KeyUp(sender, e);
        }

        private void GlassesEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServiceManager serviceManagerInstance = ToolFramework.Instance.ServiceManagerInstance;
            if (serviceManagerInstance != null)
                serviceManagerInstance.KeyPress(sender, e);
        }
    }
}
