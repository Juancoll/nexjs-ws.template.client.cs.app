using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace demo.wsclient
{
    public partial class MainWindow : Window
    {
        #region [ properties ]
        public List<WSServiceDescriptor> Services = new List<WSServiceDescriptor>
        {
            new WSServiceDescriptor
            {
                Name = "demo",
                Hubs = new List<HubDescriptor>
                {
                    new HubDescriptor { IsAuth = false, Service = "demo", Name = "onUpdate", Credentials = "null"  },
                    new HubDescriptor { IsAuth = true, Service = "demo", Name = "onUpdateCredentials", Credentials = "{}"  },
                    new HubDescriptor { IsAuth = true, Service = "demo", Name = "onUpdateCredentialsData", Credentials = "[{}]"  },
                    new HubDescriptor { IsAuth = true, Service = "demo", Name = "onUpdateData", Credentials = "null"  },
                },
                Rests = new List<RestDescriptor>
                {
                    new RestDescriptor { IsAuth = false, Service = "demo", Name = "emitEvents", Data="{}", Credentials = "null"  },
                    new RestDescriptor { IsAuth = true, Service = "demo", Name = "funcA", Data="{ name: \"My string\", surname: \"My string\", age: 2020 }", Credentials = "null"  },
                    new RestDescriptor { IsAuth = true, Service = "demo", Name = "funcB", Data="{ data: {} }", Credentials = "\"My string\""  },
                    new RestDescriptor { IsAuth = true, Service = "demo", Name = "funcC", Data="{}", Credentials = "2020"  },
                    new RestDescriptor { IsAuth = false, Service = "demo", Name = "funcD", Data="{ data: \"My string\" }", Credentials = "null"  },
                    new RestDescriptor { IsAuth = false, Service = "demo", Name = "funcE", Data="{ data: \"My string\" }", Credentials = "null"  },
                    new RestDescriptor { IsAuth = true, Service = "demo", Name = "changeUser", Data="{ name: \"My string\", surname: \"My string\", player: {}, org: {} }", Credentials = "null"  },
                }
            },
            new WSServiceDescriptor
            {
                Name = "custom",
                Hubs = new List<HubDescriptor>
                {
                },
                Rests = new List<RestDescriptor>
                {
                    new RestDescriptor { IsAuth = false, Service = "custom", Name = "check", Data="{}", Credentials = "null"  },
                    new RestDescriptor { IsAuth = false, Service = "custom", Name = "removeCollection", Data="{}", Credentials = "null"  },
                    new RestDescriptor { IsAuth = false, Service = "custom", Name = "createManyUsers", Data="{}", Credentials = "null"  },
                }
            },
            new WSServiceDescriptor
            {
                Name = "db",
                Hubs = new List<HubDescriptor>
                {
                },
                Rests = new List<RestDescriptor>
                {
                    new RestDescriptor { IsAuth = false, Service = "db", Name = "check", Data="{}", Credentials = "null"  },
                    new RestDescriptor { IsAuth = false, Service = "db", Name = "removeCollection", Data="{}", Credentials = "null"  },
                    new RestDescriptor { IsAuth = false, Service = "db", Name = "createManyUsers", Data="{}", Credentials = "null"  },
                }
            },
            new WSServiceDescriptor
            {
                Name = "jobs",
                Hubs = new List<HubDescriptor>
                {
                },
                Rests = new List<RestDescriptor>
                {
                    new RestDescriptor { IsAuth = false, Service = "jobs", Name = "runJob", Data="{}", Credentials = "null"  },
                    new RestDescriptor { IsAuth = false, Service = "jobs", Name = "start", Data="{}", Credentials = "null"  },
                    new RestDescriptor { IsAuth = false, Service = "jobs", Name = "stop", Data="{}", Credentials = "null"  },
                }
            },
            new WSServiceDescriptor
            {
                Name = "orgs",
                Hubs = new List<HubDescriptor>
                {
                },
                Rests = new List<RestDescriptor>
                {
                    new RestDescriptor { IsAuth = false, Service = "orgs", Name = "funcA", Data="{ options: {} }", Credentials = "null"  },
                    new RestDescriptor { IsAuth = true, Service = "orgs", Name = "funcB", Data="{ name: \"My string\" }", Credentials = "null"  },
                }
            },
            new WSServiceDescriptor
            {
                Name = "users",
                Hubs = new List<HubDescriptor>
                {
                },
                Rests = new List<RestDescriptor>
                {
                    new RestDescriptor { IsAuth = false, Service = "users", Name = "list", Data="{}", Credentials = "null"  },
                    new RestDescriptor { IsAuth = false, Service = "users", Name = "findById", Data="{}", Credentials = "null"  },
                    new RestDescriptor { IsAuth = false, Service = "users", Name = "findOne", Data="{}", Credentials = "null"  },
                    new RestDescriptor { IsAuth = false, Service = "users", Name = "findMany", Data="{}", Credentials = "null"  },
                    new RestDescriptor { IsAuth = false, Service = "users", Name = "updateQuery", Data="{}", Credentials = "null"  },
                    new RestDescriptor { IsAuth = false, Service = "users", Name = "updateModel", Data="{}", Credentials = "null"  },
                }
            },
        };
        #endregion

        #region [ constructor ]
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => UpdateView(Services);          
        }
        #endregion

        #region [ private ]
        private void UpdateView(List<WSServiceDescriptor> services)
        {
            _uiTab.Items.Clear();
            services.ForEach(x => _uiTab.Items.Add(new TabItem { Header = x.Name, Content = new WSServiceControl(x) }));
        }
        #endregion

        #region [ Auth ]
        private async void Button_register(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("[ui] auth.register");
                await Context.Instance.wsapi.Auth.Register(new { email = "admin@nex-group.io", password = "123456" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[error] {ex.Message}");
            }
        }
        private async void Button_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("[ui] auth.register");
                await Context.Instance.wsapi.Auth.Login(new { email = "admin@nex-group.io", password = "123456" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[error] {ex.Message}");
            }
        }
        private async void Button_Logout(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("[ui] auth.register");
                await Context.Instance.wsapi.Auth.Logout();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[error] {ex.Message}");
            }
        }
        private async void Button_authenticate(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("[ui] auth.register");
                await Context.Instance. wsapi.Auth.Authenticate(Context.Instance.wsapi.Auth.AuthInfo.token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[error] {ex.Message}");
            }
        }
        #endregion

        #region [ Socket ]
        private void Button_Connect(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("[ui] Connect");
                Context.Instance.wsapi.Ws.Connect("ws://localhost:3000/wsapi", "/");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[error] {ex.Message}");
            }
        }

        private void Button_Disconnect(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("[ui] Disconnect");
                Context.Instance.wsapi.Ws.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[error] {ex.Message}");
            }
        }
        private void Button_NestJS_Test(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("[ui] nestjs test");
                Context.Instance.wsapi.Ws.Emit("test");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[error] {ex.Message}");
            }
        }

        private void Button_NestJS_Test_Exception(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("[ui] nestjs test Exception");
                Context.Instance.wsapi.Ws.Emit("testException");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[error] {ex.Message}");
            }
        }
        #endregion     
    }
}
