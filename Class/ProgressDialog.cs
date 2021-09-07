namespace Popple
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;
    using Microsoft.WindowsAPICodePack.Taskbar;

    [ SuppressMessage( "ReSharper", "MemberInitializerValueIgnored" ) ]
    public class ProgressDialog : IDisposable
    {
        private readonly BackgroundWorker _worker = new BackgroundWorker();

        private readonly DialogForm _dialog = new DialogForm();

        public event CancelEventHandler Cancelled;

        public event RunWorkerCompletedEventHandler Completed;

        public event ProgressChangedEventHandler ProgressChanged;

        public event DoWorkEventHandler DoWork;

        private bool _disposed;

        public void Dispose()
        {
            Dispose( true );

            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( bool disposing )
        {
            if( !_disposed )
            {
                if( disposing )
                {
                    _worker.Dispose();
                    _dialog.Dispose();
                }

                _disposed = true;
            }
        }

        public ProgressDialog()
        {
            _worker = new BackgroundWorker();
            _worker.ProgressChanged += Worker_ProgressChanged;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            _worker.DoWork += worker_DoWork;
            _worker.WorkerSupportsCancellation = true;
            _worker.WorkerReportsProgress = true;
            _dialog.Cancelled += dialog_Cancelled;
        }

        private void dialog_Cancelled( object sender,
            CancelEventArgs e )
        {
            _worker.CancelAsync();

            Cancelled?.Invoke( this, e );
        }

        private void worker_DoWork( object sender,
            DoWorkEventArgs e )
        {
            if( DoWork != null )
            {
                DoWork( this, e );
                e.Cancel = IsCancelled || e.Cancel;
            }
            else
            {
                MessageBox.Show( "No work to do!", "No Work", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        public void Run()
        {
            if( TaskbarManager.IsPlatformSupported )
            {
                TaskbarManager.Instance.SetProgressState( TaskbarProgressBarState.Normal );
            }

            _worker.RunWorkerAsync();
            _dialog.ShowDialog();
        }

        public void Run( object argument )
        {
            if( TaskbarManager.IsPlatformSupported )
            {
                TaskbarManager.Instance.SetProgressState( TaskbarProgressBarState.Normal );
            }

            _worker.RunWorkerAsync( argument );
            _dialog.ShowDialog();
        }

        private void Worker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            Completed?.Invoke( this, e );

            if( TaskbarManager.IsPlatformSupported )
            {
                TaskbarManager.Instance.SetProgressState( TaskbarProgressBarState.NoProgress );
            }

            _dialog.Close();
        }

        private void Worker_ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
            ProgressChanged?.Invoke( this, e );
        }

        public void ReportProgress( int percentProgress, object userState )
        {
            _worker.ReportProgress( percentProgress, userState );
        }

        public void ReportProgress( int percentProgress )
        {
            _worker.ReportProgress( percentProgress );
        }

        public string Title
        {
            get { return _dialog.Text; }
            set { _dialog.Text = value; }
        }

        public string Message
        {
            get { return _dialog._message.Text; }
            set { _dialog._message.Text = value; }
        }

        public int Progress
        {
            get { return _dialog._progressBar.Value; }
            set
            {
                if( TaskbarManager.IsPlatformSupported )
                {
                    TaskbarManager.Instance.SetProgressValue( value, 100 );
                }

                _dialog._progressBar.Value = value;
            }
        }

        public bool IsCancelled
        {
            get { return _worker.CancellationPending; }
        }

        public ProgressBarStyle Style
        {
            get { return _dialog._progressBar.Style; }
            set { _dialog._progressBar.Style = value; }
        }

        public IWin32Window Window
        {
            get { return _dialog; }
        }
    }
}