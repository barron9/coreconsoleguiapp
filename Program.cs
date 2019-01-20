using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Terminal.Gui;

namespace ConsoleApp1
{
   
    class Program
    {
        private static readonly HttpClient client = new HttpClient();


        static void Main()
        {
            Application.Init();
            var top = Application.Top;

            // Creates the top-level window to show
            var rect = new Rect(0, 1, top.Frame.Width, top.Frame.Height - 1);
            var win = new Window(rect, "MyApp");
            top.Add(win);

            // Creates a menubar, the item "New" has a help menu.
            var menu = new MenuBar(new MenuBarItem[] {
            new MenuBarItem ("_File", new MenuItem [] {
                new MenuItem ("_New", "Creates new file", null),
                new MenuItem ("_Close", "", null),
                new MenuItem ("_Quit", "",  ()=> MessageBox.ErrorQuery (50, 5, "Error", "There is nothing to close", "Ok"))
            
            }),
            new MenuBarItem ("_Edit", new MenuItem [] {
                new MenuItem ("_Copy", "", null),
                new MenuItem ("C_ut", "", null),
                new MenuItem ("_Paste", "", null)
            })
        });
            top.Add(menu);

            // Add some controls
            win.Add(
                    new Label(3, 2, "Login: "),
                    new TextField(14, 2, 40, ""),
                    new Label(3, 4, "Password: "),
                    new TextField(14, 4, 40, "") { Secret = true },
                    new CheckBox(3, 6, "Remember me"),
                    new RadioGroup(3, 8, new[] { "_Personal", "_Company" }),
                    new Button(3, 14, "Ok",true),
                    new Button(10, 14, "Cancel"),
                    new Label(3, 18, "Press ESC and 9 to activate the menubar"));
            

            Application.Run();
        }
        static void Mainx(string[] args)
        {
            

            Console.WriteLine("Lütfen link giriniz(Enter): ");

            Console.ReadLine();
            Console.WriteLine("Evet, linki aldık. " );

            Console.WriteLine("İşlem sürüyor Lütfen Bekleyiniz....");
            ThreadWithState tws = new ThreadWithState(
                "This report displays the number {0}.", 42);

            // Create a thread to execute the task, and then
            // start the thread.
            Thread t = new Thread(new ThreadStart(tws.ThreadProc));
            t.Start();
            ServerClass serverObject = new ServerClass();

            // Create the thread object, passing in the
            // serverObject.InstanceMethod method using a
            // ThreadStart delegate.
            Thread InstanceCaller = new Thread(
                new ThreadStart(serverObject.InstanceMethod));

            // Start the thread.
            InstanceCaller.Start();
        
            


            try
            {
                ProcessRepositories().Wait();
                Environment.Exit(-1);

            }
            catch (Exception ex)
            {
                Console.Write($"There was an exception: {ex.ToString()}");
            }
        }
        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://6p6s.com/c.ovpn");

            var msg = await stringTask;
            Console.Write(msg);
        }
    }
}
