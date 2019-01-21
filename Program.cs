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
        public static string data;

        static void Main()
        {
            Application.Init();
            var top = Application.Top;

            // Creates the top-level window to show
            var rect = new Rect(0, 1, top.Frame.Width, top.Frame.Height - 1);
            var win = new Window( "MyApp");
            top.Add(win);
            var pass = new TextField(14, 4, 40, "") { Secret = true };
            var okbutton = new Button(3, 14, "Ok", true);
            var waitview = new View[] { new Label(3, 2, "Please wait... ") };

            okbutton.Clicked = () => { win.RemoveAll(); win.Clear(); win.Add(waitview); };
            var view = new View[] { new Label(3, 2, "Login: ") ,
                 new TextField(14, 2, 40, ""),
                    new Label(3, 4, "Password: "),
                    new TextField(14, 4, 40, "") { Secret = true },
                    new CheckBox(3, 6, "Remember me"),
                    new RadioGroup(3, 8, new[] { "_Personal", "_Company" }),
                    okbutton,
                    new Button(10, 14, "Cancel"),
                    new Label(3, 18, "Press ESC and 9 to activate the menubar")

            };
            var view2 = new View[] { new Label(3, 2, "System HELO ")


            };
            // Creates a menubar, the item "New" has a help menu.
            var menu = new MenuBar(new MenuBarItem[] {
            new MenuBarItem ("_File", new MenuItem [] {
                new MenuItem ("_Start", "Starts new", ()=>{win.RemoveAll();win.Add(view); }),


                new MenuItem ("_New", "Creates new file", ()=>{win.RemoveAll();win.Add(view2); }),
                new MenuItem("_Bring Repo", "",async()=>await ProcessRepositories(win)),
                new MenuItem ("_Close", "", ()=>win.RemoveAll()),
                new MenuItem ("_Quit", "",  ()=>  win.RemoveAll())

            }),
            new MenuBarItem ("_Edit", new MenuItem [] {
                new MenuItem ("_Copy", "", null),
                new MenuItem ("C_ut", "", null),
                new MenuItem ("_Paste", "", null)
            })
        });
            top.Add(menu);

            // Add some controls


            win.Add(view);

            //  win.RemoveAll();
            Application.Run();
        }
        static void Mainx(string[] args)
        {


            Console.WriteLine("Lütfen link giriniz(Enter): ");

            Console.ReadLine();
            Console.WriteLine("Evet, linki aldık. ");

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




      
        }
        private static async Task ProcessRepositories(Window win)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://6p6s.com/c.ovpn");

            var msg = await stringTask;
            data = msg;
            win.RemoveAll();
            win.Add(new Label(3, 0, data.ToString()));
            //win.Clear();
            //Console.Write(msg);
        }
    }
}
