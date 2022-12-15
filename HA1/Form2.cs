using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace HA1
{
    public partial class Form2 : Form
    {
        class User
        {
            public string name;//имя и фамилия пользователя
        }

        class Chat
        {
            public string sender;//отправитель сообщения
            public string message;//текст сообщения
            public override string ToString()
            {
                return sender + "\n" + message + "\n\n";
            }
        }

        public Form2(string fi)
        {
            InitializeComponent();

            User user = new User() { name = fi };
            WebClient client = new WebClient();
            string url = "http://194.87.99.14/auth";
            string enterstr = JsonConvert.SerializeObject(user);
            string jwt = client.UploadString(url, enterstr);
            //Задание 1
            url = "http://194.87.99.14/messages";
            string response = client.UploadString(url, jwt);
            List<Chat> chat = JsonConvert.DeserializeObject<List<Chat>>(response);
            foreach (Chat el in chat)
                messages.Text += el;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
