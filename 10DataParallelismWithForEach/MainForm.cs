using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.IO;

namespace _10DataParallelismWithForEach
{
    public partial class MainForm : Form
    {
        // New Form-level variable.
        private CancellationTokenSource cancelToken =
          new CancellationTokenSource();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnProcessImages_Click(object sender, EventArgs e)
        {
            // Start a new "task" to process the files.
            Task.Factory.StartNew(() =>
            {
                ProcessFiles();
            });
        }

        private void ProcessFiles()
        {
            // Use ParallelOptions instance to store the CancellationToken.
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            // Load up all *.jpg files, and make a new folder for the modified data.
            string[] files = Directory.GetFiles
              (@"C:\Users\brito\Desktop\cosas\imagenes\LEGO\castle", "*.jpg",
              SearchOption.AllDirectories);
            string newDir = @"C:\Users\brito\Desktop\cosas\programacion\tekmexicotraining\codebyhand\testdir";
            Directory.CreateDirectory(newDir);

            try
            {
                // Process the image data in a parallel manner!
                Parallel.ForEach(files, parOpts, currentFile =>
                    {
                        parOpts.CancellationToken.ThrowIfCancellationRequested();

                        string filename = Path.GetFileName(currentFile);

                        using (Bitmap bitmap = new Bitmap(currentFile))
                        {
                            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            bitmap.Save(Path.Combine(newDir, filename));

                            // Eek! This will not work anymore!
                            //  this.Text = string.Format("Processing {0} on thread {1}", filename,
                            //  Thread.CurrentThread.ManagedThreadId);

                            // Invoke on the Form object, to allow secondary threads to access controls
                            // in a thread-safe manner.
                            this.Invoke((Action)delegate
                                {
                                    this.Text = string.Format("Processing {0} on thread {1}", filename,
                                                Thread.CurrentThread.ManagedThreadId);
                                }
                            );
                        }
                    }
                );
            }
            catch (OperationCanceledException ex)
            {
                this.Invoke((Action)delegate
                {
                    this.Text = ex.Message;
                });
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // This will be used to tell all the worker threads to stop!
            cancelToken.Cancel();
        }

    }
}
