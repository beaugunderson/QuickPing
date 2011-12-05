using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace QuickPingControls
{
    public class PingStatusControl : Control
    {
        private Task _task;

        #region Properties
        public static readonly DependencyProperty AddressProperty =
            DependencyProperty.Register("Address", 
                typeof (string),
                typeof (PingStatusControl), 
                new PropertyMetadata(default(string)));

        public string Address
        {
            get
            {
                return (string)GetValue(AddressProperty);
            }

            set
            {
                SetValue(AddressProperty, value);
            }
        }
        #endregion

        public void Start()
        {
            //Console.WriteLine("Starting ping of address {0}", Address);

            string address = Address;

            _task = new Task(delegate
            {
                var ping = new Ping();

                while (true)
                {
                    var reply = ping.Send(address, 1000);

                    if (reply == null)
                    {
                        throw new Exception("reply was null");
                    }

                    //Console.WriteLine(reply);

                    if (reply.Status == IPStatus.Success)
                    {
                        Dispatcher.BeginInvoke((Action)delegate
                        {
                            Background =
                                new SolidColorBrush(Colors.Green);
                        });
                    }
                    else
                    {
                        Dispatcher.BeginInvoke((Action)delegate
                        {
                            Background =
                                new SolidColorBrush(Colors.Red);
                        });
                    }

                    Thread.Sleep(2000);
                }
            });

            _task.Start();
        }

        public PingStatusControl(string address)
        {
            Address = address;

            BorderBrush = new SolidColorBrush(Colors.Black);
        }

        static PingStatusControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PingStatusControl), new FrameworkPropertyMetadata(typeof(PingStatusControl)));
        }
    }
}