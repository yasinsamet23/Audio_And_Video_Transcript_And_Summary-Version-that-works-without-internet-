using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Audio_And_Video_Transcript_And_Summary
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string selectedFilePath = "";

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a video or voice file";
                openFileDialog.Filter = "Video or Audio Files|*.mp4;*.mp3;*.wav;*.m4a;*.avi;*.mov;*.mkv";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;
                    MessageBox.Show("Selected File: " + selectedFilePath, "File Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblSelectedFile.Text = "Selected File : " + Path.GetFileName(selectedFilePath);
                }
            }
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Please select a file first.");
                return;
            }

            pgbConvertTime.Style = ProgressBarStyle.Marquee;
            pgbConvertTime.Visible = true;

            string scriptPath = Path.Combine(basePath, "transcribe.py");

            var output = await Task.Run(() =>
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "python";
                    process.StartInfo.Arguments = $"\"{scriptPath}\" \"{selectedFilePath}\"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    string stdOutput = process.StandardOutput.ReadToEnd();
                    string stdError = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    return string.IsNullOrWhiteSpace(stdOutput) ? "Error: " + stdError : stdOutput;
                }
                catch (Exception ex)
                {
                    return "An error occurred during processing: " + ex.Message;
                }
            });

            pgbConvertTime.Visible = false;
            txtConvertedText.Text = output;
        }

        private async void btnSummarize_Click(object sender, EventArgs e)
        {
            string transcriptText = txtConvertedText.Text;
            if (string.IsNullOrWhiteSpace(transcriptText))
            {
                MessageBox.Show("First, transcribe the audio.");
                return;
            }

            string tempTxtPath = Path.Combine(Path.GetTempPath(), "transcript.txt");
            File.WriteAllText(tempTxtPath, transcriptText);

            string summarizeScriptPath = Path.Combine(basePath, "summarize.py");

            pgvSummarizeTime.Style = ProgressBarStyle.Marquee;
            pgvSummarizeTime.Visible = true;

            var output = await Task.Run(() =>
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "python";
                    process.StartInfo.Arguments = $"\"{summarizeScriptPath}\" \"{tempTxtPath}\"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    string stdOutput = process.StandardOutput.ReadToEnd();
                    string stdError = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    return string.IsNullOrWhiteSpace(stdOutput) ? "Error: " + stdError : stdOutput;
                }
                catch (Exception ex)
                {
                    return "An error occurred during summarization: " + ex.Message;
                }
            });

            pgvSummarizeTime.Visible = false;
            txtSummarize.Text = output;
        }
    }
}
