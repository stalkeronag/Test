using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRPC.Interfaces;
using MyRPC.Server;

namespace MyRPC.Commands
{
    public class TestChatCommand : ICommand
    {
        public string[] Args { get; set; }
        public string[] Flags { get; set; }
        public string Name { get; set; }

        private IConnection connection;

        private string[] phrases;

        public TestChatCommand(IConnection connection)
        {
            this.connection = connection;
            phrases = new string[10]
            {
                "Я на лошади. Ты на белом коне, и я на белом коне",
                "Братишка, братишка,  как поспал? Проголодался, наверное…",
                "Самолёты какие были? Какой самый известный самолёт на тихоокеанском театре военных действий?",
                "Какие корабли? КАКИЕ КОРАБЛИ? Аризона, Вест-Вирджиния, Оклахома и Мэрилэнд",
                "Да ладно тебе, что ты сердишься? Сердиться будешь — себе дороже, понимаешь? Мы здесь вдвоём с тобой.",
                "Да это китайская пытка",
                "Не, ну я так понял, что ты так… ты рассказываешь мне, я так понял, что тебе понравилось говно",
                "Хорошая история, просто…",
                "Не могу спать в эту сторону, потому что там течёт вода, я не засну. Я хочу спать в эту сторону.",
                "Я уж покушал, я тебе…"
            };
        }


        public async Task Execute(HandlerBytes handler)
        {
            Random random = new Random();
            string res;
            do
            {
                int number = random.Next(0, 9);
                byte[] answer = Encoding.UTF8.GetBytes(phrases[number]);
                await handler.Invoke(answer);
                byte[] bytes = await connection.Read();
                res = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(res);
            }
            while (res != "Exit");
            await handler.Invoke(Encoding.UTF8.GetBytes("Ты понимаешь что ты уже все"));
        }
    }
}
