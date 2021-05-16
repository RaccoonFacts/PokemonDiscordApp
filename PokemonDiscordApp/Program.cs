using System;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using InputSimulatorStandard;
using InputSimulatorStandard.Native;

//Subscribe to me plz RaccoonFacts: https://www.youtube.com/channel/UC0u47g4vunP2ZERk9lwpiAQ
namespace PokemonDiscordApp
{
        public class Program
        {
            InputSimulator simulator = new InputSimulator();
            private DiscordSocketClient _client;


            

            public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

            public async Task MainAsync()
            {
                try
                {

                    _client = new DiscordSocketClient();
                    _client.MessageReceived += CommandHandler;
                    _client.Log += Log;

                    //  You can assign your bot token to a string, and pass that in to connect.
                    //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
                    var token = "PUT TOKEN HERE";

                    // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
                    // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
                    // var token = File.ReadAllText("token.txt");
                    // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

                    await _client.LoginAsync(TokenType.Bot, token);
                    await _client.StartAsync();


                    // Block this task until the program is closed.
                    await Task.Delay(-1);

                }
                catch
                {
                    MainAsync();
                }
            }

            public void serial(object sender, EventArgs e)
            {

            }

            private Task Log(LogMessage msg)
            {


                Console.WriteLine(msg.ToString());
                return Task.CompletedTask;


            }

            private Task CommandHandler(SocketMessage message)
            {

                string command = "";
                int lengthOfCommand = -1;
                string mention = "";
                string[] randomnums = { "69", "6969", "420", "42069", "69696", "420420420", "666", "8008", "455", "404", "8008", "No, go fuck yourself", "I'll give you a 1 to fuck off", "Maybe you should roll off a cliff", "if you keep rolling you will have to call 911" };
                Random r = new Random();
                



                //filter bullshit here
                // if (!message.Content.StartsWith("!"))
                //     return Task.CompletedTask;

                if (message.Author.IsBot)
                {
                    return Task.CompletedTask;
                }
              
                else
                {
                   

                    command = message.Content.ToLower();

                    //command here
                    if (command.Equals("!hello"))
                    {
                        message.Channel.SendMessageAsync($@"Go fuck yourself {message.Author.Mention}");
                    }
                    else if (command.Contains("!time"))
                    {
                        DateTime now = DateTime.Now;
                        message.Channel.SendMessageAsync($@"The time for PUT YOUR NAME  HERE is {now}");
                    }
                    
                    else if (command.Equals("!help"))
                    {
                        message.Channel.SendMessageAsync("I am not going to help you figure it out on your own...but try !controls");
                    }

                   
                    else if (command.Equals("!roll"))
                    {
                        message.Channel.SendMessageAsync(randomnums[r.Next(0, randomnums.Length - 1)]);
                    }



                  
                   

                    else if (command.Contains("!up"))

                    {

                        try
                        {
                            string many = command.Remove(0, 4);
                            int num = Int32.Parse(many);

                            if (num >= 0 && num < 10)
                            {
                                int i = num;
                                message.Channel.SendMessageAsync($@"Up {i}");
                                while (i > 0)
                                {
                                    //_serialPort.WriteLine("1");
                                    simulator.Keyboard.KeyDown(VirtualKeyCode.VK_W);
                                    Thread.Sleep(150);
                                    simulator.Keyboard.KeyUp(VirtualKeyCode.VK_W);
                                    Thread.Sleep(100);
                                    i--;
                                }
                            }

                            else
                            {
                                message.Channel.SendMessageAsync($@"Just going up 1 time");
                                simulator.Keyboard.KeyDown(VirtualKeyCode.VK_W);
                                Thread.Sleep(150);
                                simulator.Keyboard.KeyUp(VirtualKeyCode.VK_W);


                            }
                        }

                        catch
                        {
                            simulator.Keyboard.KeyDown(VirtualKeyCode.VK_W);
                            Thread.Sleep(150);
                            simulator.Keyboard.KeyUp(VirtualKeyCode.VK_W);
                            message.Channel.SendMessageAsync("Up once");
                            ;
                        }
                        // 

                        // message.Channel.SendMessageAsync($@"up");
                    }
                    else if (command.Contains("!down"))
                    {


                        try
                        {
                            string many = command.Remove(0, 6);
                            int num = Int32.Parse(many);

                            if (num >= 0 && num < 10)
                            {
                                int i = num;
                                message.Channel.SendMessageAsync($@"down {i}");

                                while (i > 0)
                                {
                                    // _serialPort.WriteLine("2");
                                    simulator.Keyboard.KeyDown(VirtualKeyCode.VK_S);

                                    Console.WriteLine($@"down {i}");
                                    Thread.Sleep(150);

                                    simulator.Keyboard.KeyUp(VirtualKeyCode.VK_S);
                                    Thread.Sleep(100);
                                    i--;
                                }
                            }

                            else
                            {
                                message.Channel.SendMessageAsync($@"Just going down 1 time");
                                simulator.Keyboard.KeyDown(VirtualKeyCode.VK_S);
                                Thread.Sleep(150);
                                simulator.Keyboard.KeyUp(VirtualKeyCode.VK_S);
                            }

                        }
                        catch
                        {
                            //  _serialPort.WriteLine("2");
                            message.Channel.SendMessageAsync("down once");
                            simulator.Keyboard.KeyDown(VirtualKeyCode.VK_S);
                            Thread.Sleep(150);
                            simulator.Keyboard.KeyUp(VirtualKeyCode.VK_S);
                        }





                    }
                    else if (command.Contains("!left"))
                    {
                        try
                        {
                            string many = command.Remove(0, 6);
                            int num = Int32.Parse(many);

                            if (num >= 0 && num < 10)
                            {
                                int i = num;
                                message.Channel.SendMessageAsync($@"left {i}");
                                while (i > 0)
                                {
                                    simulator.Keyboard.KeyDown(VirtualKeyCode.VK_A);
                                    Thread.Sleep(150);
                                    simulator.Keyboard.KeyUp(VirtualKeyCode.VK_A);
                                    Thread.Sleep(100);

                                    i--;
                                }
                            }

                            else
                            {
                                simulator.Keyboard.KeyDown(VirtualKeyCode.VK_A);
                                Thread.Sleep(150);
                                simulator.Keyboard.KeyUp(VirtualKeyCode.VK_A);
                                message.Channel.SendMessageAsync($@"Just going left 1 time");
                            }

                        }
                        catch
                        {
                            simulator.Keyboard.KeyDown(VirtualKeyCode.VK_A);
                            Thread.Sleep(150);
                            simulator.Keyboard.KeyUp(VirtualKeyCode.VK_A);
                            message.Channel.SendMessageAsync("left once");

                        }






                    }
                    else if (command.Contains("!right"))
                    {
                        try
                        {
                            string many = command.Remove(0, 7);
                            int num = Int32.Parse(many);

                            if (num >= 0 && num < 10)
                            {
                                int i = num;
                                message.Channel.SendMessageAsync($@"right {i}");
                                while (i > 0)
                                {
                                    simulator.Keyboard.KeyDown(VirtualKeyCode.VK_D);
                                    Thread.Sleep(150);
                                    simulator.Keyboard.KeyUp(VirtualKeyCode.VK_D);
                                    Thread.Sleep(100);
                                    i--;
                                }
                            }

                            else
                            {
                                simulator.Keyboard.KeyDown(VirtualKeyCode.VK_D);
                                Thread.Sleep(150);
                                simulator.Keyboard.KeyUp(VirtualKeyCode.VK_D);
                                message.Channel.SendMessageAsync($@"Just going right 1 time");
                            }

                        }
                        catch
                        {
                            
                            simulator.Keyboard.KeyDown(VirtualKeyCode.VK_D);
                            Thread.Sleep(150);
                            simulator.Keyboard.KeyUp(VirtualKeyCode.VK_D);
                            message.Channel.SendMessageAsync("right once");

                        }



                    }
                    else if (command.Equals("!a"))
                    {
                        simulator.Keyboard.KeyDown(VirtualKeyCode.VK_Z);
                        Thread.Sleep(150);
                        simulator.Keyboard.KeyUp(VirtualKeyCode.VK_Z);
                        message.Channel.SendMessageAsync("A button");
                    }
                    else if (command.Equals("!b"))
                    {
                        simulator.Keyboard.KeyDown(VirtualKeyCode.VK_X);
                        Thread.Sleep(150);
                        simulator.Keyboard.KeyUp(VirtualKeyCode.VK_X);
                        message.Channel.SendMessageAsync("B Button");
                    }

                    else if (command.Equals("!lb"))
                    {
                        simulator.Keyboard.KeyDown(VirtualKeyCode.VK_1);
                        Thread.Sleep(150);
                        simulator.Keyboard.KeyUp(VirtualKeyCode.VK_1);
                        message.Channel.SendMessageAsync("Left Bumper");
                    }
                    else if (command.Equals("!rb"))
                    {
                        simulator.Keyboard.KeyDown(VirtualKeyCode.VK_2);
                        Thread.Sleep(150);
                        simulator.Keyboard.KeyUp(VirtualKeyCode.VK_2);
                        message.Channel.SendMessageAsync("Right Bumper");
                    }
                    else if (command.Equals("!start"))
                    {
                        simulator.Keyboard.KeyDown(VirtualKeyCode.VK_3);
                        Thread.Sleep(150);
                        simulator.Keyboard.KeyUp(VirtualKeyCode.VK_3);
                        message.Channel.SendMessageAsync("start");
                    }
                    else if (command.Equals("!select"))
                    {
                        simulator.Keyboard.KeyDown(VirtualKeyCode.VK_4);
                        Thread.Sleep(150);
                        simulator.Keyboard.KeyUp(VirtualKeyCode.VK_4);
                        message.Channel.SendMessageAsync("select");
                    }





                    else if (command.Equals("!controls"))
                    {
                        message.Channel.SendFileAsync("pokemon.png");

                    }

                    // else if (command.Equals("<@"))
                    // {
                    //      message.Channel.SendMessageAsync($@"My name is now \{command}");
                    // }

                 

                    return Task.CompletedTask;
                }





            }
        }
    }


    
