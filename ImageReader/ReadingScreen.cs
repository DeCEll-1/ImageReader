using FolderSelect;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.WebRequestMethods;

namespace ImageReader
{
    public partial class ReadingScreen : Form
    {
        public string masterPath { get; set; }
        public List<string> imagePaths { get; set; } = new List<string>();
        public int index { get; set; }
        public int lastWidth { get; set; }
        public int heightOffset { get; set; } = 0;
        public float heightLocationOffset { get; set; } = 0;
        public ReadingScreen()
        {
            InitializeComponent();
            string lastPath = RegistryWorks.GetVariable("LastFolderPath", "NULL");
            if (lastPath == "NULL") return;
            masterPath = lastPath;
            ListDirectory(tv_Folders, lastPath);

            this.MouseWheel += new MouseEventHandler(pnl_Map_MouseWheel);

        }

        private void pnl_Map_MouseWheel(object sender, MouseEventArgs e)
        {
            heightLocationOffset += e.Delta > 0 ? 30f : -30f;

            ResizePB();
        }

        private void ReadingScreen_Load(object sender, EventArgs e)
        {
            pb_Main.Image = Properties.Resources.testTexture;
            ResizePB();

        }
        private void ReadingScreen_ResizeEnd(object sender, EventArgs e)
        {
            ResizePB();



        }
        private void btn_SelectDirectory_Click(object sender, EventArgs e)
        {
            FolderSelectDialog dialog = new FolderSelectDialog();

            if (!dialog.ShowDialog()) return;
            masterPath = dialog.FileName;
            RegistryWorks.SetVariable("LastFolderPath", dialog.FileName);
            ListDirectory(tv_Folders, dialog.FileName);
        }

        public static readonly string[] ImageExtensions = new string[] { ".JPG", ".JPEG", ".JPE", ".BMP", ".PNG", ".WEBP" };
        private async void tv_Folders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lbl_Load.Text = "Loading";
            string temp = tv_Folders.SelectedNode.Text;
            await Task.Run(() => LoadImages(temp));

            lbl_Load.Text = "Loaded";
            SetImage(0);

        }

        private void pb_Main_MouseDown(object sender, MouseEventArgs e)
        {
            Point mouseLoc = e.Location;
            if (mouseLoc.X > pb_Main.Width / 2)
            {
                SetImage(index + 1);
            }
            else
            {
                SetImage(index - 1);
            }
        }

        private void btn_Collapse_Click(object sender, EventArgs e)
        {
            if (tv_Folders.Width != 0)
            {
                lastWidth = tv_Folders.Width;
                tv_Folders.Width = 0;
                (sender as Button).Text = ">";
            }
            else
            {
                tv_Folders.Width = lastWidth;
                (sender as Button).Text = "<";
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {//https://stackoverflow.com/a/31464086


            int zoomAmount = 100;
            float heightOffset = 90f;

            switch (keyData)
            {
                case Keys.NumPad6:
                case Keys.Right:
                    SetImage(index + 1);
                    break;
                case Keys.NumPad4:
                case Keys.Left:
                    SetImage(index - 1);
                    break;
                case Keys.NumPad2:
                case Keys.Down:
                    heightLocationOffset += -heightOffset;
                    break;
                case Keys.NumPad8:
                case Keys.Up:
                    heightLocationOffset += heightOffset;
                    break;
                case Keys.Add:
                    ZoomImage(zoomAmount);
                    break;
                case Keys.NumPad0:
                    heightOffset = 0;
                    heightLocationOffset = 0;
                    break;
                case Keys.Subtract:
                    ZoomImage(-zoomAmount);
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            ResizePB();
            return true;
        }

        #region funcs
        private void SetImage(int index)
        {
            if (imagePaths.Count <= 0) return;
            if (index < 0)
            {
                index = imagePaths.Count - 1;
            }
            else if (index > imagePaths.Count - 1)
            {
                index = 0;
            }
            string path = imagePaths[index];
            Bitmap bitmap = null;
            try
            {
                bitmap = new Bitmap(path);
            }
            catch (Exception)
            {
                // use 'MagickImage()' if you want just the 1st frame of an animated image. 
                // 'MagickImageCollection()' returns all frames
                using (var magickImages = new MagickImage(path))
                {
                    var ms = new MemoryStream();
                    magickImages.Write(ms, MagickFormat.Jpg);
                    bitmap?.Dispose();
                    bitmap = new Bitmap(ms);
                    // keep MemoryStream from being garbage collected while Bitmap is in use
                    bitmap.Tag = ms;
                }
            }

            pb_Main.Image = bitmap;
            this.index = index;
            string[] text = imagePaths[index].Split('\\');
            ((this.MdiParent) as Main).UpdatePage(text[text.Length - 1] + "\nIndex: " + index);
            ResizePB();
            SetOrder();
        }
        private void ResizePB()
        {

            this.PerformLayout();
            SuspendLayout();
            pb_Main.Height = pb_Main.Image.Height;
            pb_Main.Width = pb_Main.Image.Width;

            Rectangle rect = Screen.GetWorkingArea(pnl_Background); // for width
            Size background = pnl_Background.Size;

            float ratio = (float)background.Height / ((float)pb_Main.Image.Height - heightOffset);


            pb_Main.Height = (int)(pb_Main.Height * ratio);
            pb_Main.Width = (int)(pb_Main.Width * ratio);



            pb_Main.Location = new Point((rect.Width - pb_Main.Width) / 2, (int)heightLocationOffset);

            ResumeLayout();

        }
        private void ZoomImage(int amount)
        {
            heightOffset += amount;
            ResizePB();
        }
        private void SetOrder()
        {
            SuspendLayout();
            pb_Main.SendToBack();
            pnl_Background.SendToBack();
            tv_Folders.BringToFront();
            btn_SelectDirectory.BringToFront();
            btn_Collapse.BringToFront();
            ResumeLayout();

        }
        private void ListDirectory(TreeView treeView, string path)
        { // https://stackoverflow.com/a/6239644
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }
        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            //foreach (var file in directoryInfo.GetFiles())
            //    directoryNode.Nodes.Add(new TreeNode(file.Name));
            return directoryNode;
        }
        private async void LoadImages(string nodeName)
        {
            string path = masterPath + "\\" + nodeName;

            if (!Directory.Exists(path)) return;
            imagePaths.Clear();
            string[] imagesArray = Directory.GetFiles(path);
            foreach (string image in imagesArray)
            {
                if (ImageExtensions.Any(s => image.ToUpper().Contains(s)))
                {
                    imagePaths.Add(image);
                    FireMethodOnDifferentThread(this, this.GetType(), "UpdateLoadedPages", new object[] { });
                }
            }



        }
        public void UpdateLoadedPages()
        {
            lbl_LoadedPages.Text = imagePaths.Count.ToString();
        }
        public static void FireMethodOnDifferentThread(object thingToInvokeIn, Type t, string methodToRun, object[] myParams)
        {
            MethodInfo invokeOnDifferentThread = t.GetMethod("Invoke", new[] { typeof(Delegate) });//get the Invoke for the objects thread

            MethodInfo methodToRunI = t.GetMethod(methodToRun);//get the thing we want to run

            object methodInvokerDelegate = (MethodInvoker)delegate { methodToRunI.Invoke(thingToInvokeIn, myParams); };

            invokeOnDifferentThread.Invoke(thingToInvokeIn, new object[1] { methodInvokerDelegate });
        }

        #endregion

        #region resize

        bool resizing = false;
        Point lastMousePosition;

        private void tv_Folders_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the mouse is near the edge (for example, within 10 pixels from the right edge)
            if (e.X >= tv_Folders.Width - 50)
            {
                resizing = true;
                lastMousePosition = e.Location;
            }
        }

        private void tv_Folders_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.X >= tv_Folders.Width - 50)
            {
                Cursor.Current = Cursors.SizeWE;
            }

            if (resizing)
            {
                // Calculate the difference in mouse movement
                int diff = e.X - lastMousePosition.X;

                // Update the panel's width
                tv_Folders.Width += diff;

                // Store the current position
                lastMousePosition = e.Location;
            }
        }

        private void tv_Folders_MouseUp(object sender, MouseEventArgs e)
        {
            resizing = false; // Stop resizing
        }

        #endregion


    }
}
