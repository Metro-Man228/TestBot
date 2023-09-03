using System;
using System.IO;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using System.Net.Http;

class Program
{
    //Первым делом вставьте в консоль ключ-токен от бота для использования 
    private static string BotKey = Console.ReadLine();
    private static readonly TelegramBotClient Bot = new TelegramBotClient($"{BotKey}");

    static void Main(string[] args)
    {
        if (args.Length > 0) { BotKey = args[0]; }

        Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
        Bot.OnMessage += BotOnMessageReceived;

        Bot.StartReceiving();
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        Bot.StopReceiving();
        
    }

    // Вторым вставьте свой id чтобы получать сведения о заказе
    private static string ownerId = Console.ReadLine();
    


    private static string city1_info = "Тольятти";
        private static string city1_house1_info = "За стеклом";
        private static string city1_house2_info = "Пирожок";
        private static string city1_house3_info = "Плато";
        private static string city1_house4_info = "Альтус";
        private static string city1_house5_info = "Кукушка";
        private static string city1_house6_info = "Арут";
        private static string city1_house7_info = "Вкусно и точка";
        private static string city1_house8_info = "";
    private static string city2_info = "Воронеж";
    private static string tovar1_info = "пицца";
    private static string tovar2_info = "другая пицца";


    // объявляем переменные для пекаря
    private static string city; 
    private static string pizzaHouse;
    private static string tovar;
    private static string feature;
    private static int price;
    private static int pr;
    private static int number;

    // \r\n

    private static async void BotOnMessageReceived(object sender, MessageEventArgs e)
    {
        
        
        if (e.Message.Text == "/start")
        {
            var message = e.Message;

            // Самое начало
            

            Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"), chatId: message.Chat.Id, caption: $"Внимание всем:" );
            Bot.SendTextMessageAsync( chatId: message.Chat.Id, text: $"Это первое сообщение для оформления заказа!",
                           replyMarkup: new InlineKeyboardMarkup(new[]
                            {
                                new[]
                                {
                                    InlineKeyboardButton.WithCallbackData("начать", "02")
                                }
                            })
                            );
            city = "не выбран";
            pizzaHouse = "В черте города";
            tovar = "не выбран";
            feature = "не выбран";
            price = 0;
            pr = 0;

        }
    }

        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs e)
    {
        var userName = $"{e.CallbackQuery.From.FirstName} {e.CallbackQuery.From.LastName}";
        

        if (e.CallbackQuery.Data == "02")
        {
            city = "не выбран";
            pizzaHouse = "В черте города";
            tovar = "не выбран";
            feature = "не выбран";
            price = 0;
            pr = 0;
            // Начало покупок
            Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                            chatId: e.CallbackQuery.Message.Chat.Id,
                            caption: $"Выберите город {userName}!",
                            replyMarkup: new InlineKeyboardMarkup(new[]
                            {
                                new[] { InlineKeyboardButton.WithCallbackData($"{city1_info}", "city1_nav") },
                                new[] { InlineKeyboardButton.WithCallbackData($"{city2_info}", "city2_nav") },
                             
                            }));
            // Удаление старого сообщения
            Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            else if (e.CallbackQuery.Data == "city1_nav")
            {
               
                // Город1
                city = "город1!";
                Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                                chatId: e.CallbackQuery.Message.Chat.Id,
                                caption: $"Выберите пиццерию!",
                                replyMarkup: new InlineKeyboardMarkup(new[]
                                {
                                    new[] { InlineKeyboardButton.WithCallbackData($"{city1_house1_info}", "house1_1") },
                                    new[] { InlineKeyboardButton.WithCallbackData($"{city1_house2_info}", "house1_2") },
                                    new[] { InlineKeyboardButton.WithCallbackData($"{city1_house3_info}", "house1_3") },
                                    new[] { InlineKeyboardButton.WithCallbackData($"{city1_house4_info}", "house1_4") },
                                    new[] { InlineKeyboardButton.WithCallbackData($"{city1_house5_info}", "house1_5") },
                                    new[] { InlineKeyboardButton.WithCallbackData($"{city1_house6_info}", "house1_6") },
                                    new[] { InlineKeyboardButton.WithCallbackData($"{city1_house7_info}", "house1_7") },
                                    new[] { InlineKeyboardButton.WithCallbackData($"{city1_house8_info}", "house1_8") },
                                    new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "02") }
                                })
                                );
                // Удаление старого сообщения
                Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
            }

                    else if (e.CallbackQuery.Data == "house1_1")
                    {
                        pizzaHouse = "первое здание";
                        Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                                        chatId: e.CallbackQuery.Message.Chat.Id,
                                        caption: $"Выберите товар:",
                                        replyMarkup: new InlineKeyboardMarkup(new[]
                                        {
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar1_info}", "tovar_nav1") },
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar2_info}", "tovar_nav2") },
                                            new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "city1_nav") }
                                        }));
                        // Удаление старого сообщения
                        Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
                    }

                    else if (e.CallbackQuery.Data == "house1_2")
                    {
                        pizzaHouse = "второе здание";
                        Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                                        chatId: e.CallbackQuery.Message.Chat.Id,
                                        caption: $"Выберите товар:",
                                        replyMarkup: new InlineKeyboardMarkup(new[]
                                        {
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar1_info}", "tovar_nav1") },
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar2_info}", "tovar_nav2") },
                                            new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "city1_nav") }
                                        }));
                        // Удаление старого сообщения
                        Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
                    }

                    else if (e.CallbackQuery.Data == "house1_3")
                    {
                        pizzaHouse = "третье здание";
                        Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                                        chatId: e.CallbackQuery.Message.Chat.Id,
                                        caption: $"Выберите товар:",
                                        replyMarkup: new InlineKeyboardMarkup(new[]
                                        {
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar1_info}", "tovar_nav1") },
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar2_info}", "tovar_nav2") },
                                            new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "city1_nav") }
                                        }));
                        // Удаление старого сообщения
                        Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
                    }

                    else if (e.CallbackQuery.Data == "house1_4")
                    {
                        pizzaHouse = "четвертое здание";
                        Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                                        chatId: e.CallbackQuery.Message.Chat.Id,
                                        caption: $"Выберите товар:",
                                        replyMarkup: new InlineKeyboardMarkup(new[]
                                        {
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar1_info}", "tovar_nav1") },
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar2_info}", "tovar_nav2") },
                                            new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "city1_nav") }
                                        }));
                        // Удаление старого сообщения
                        Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
                    }
        
                    else if (e.CallbackQuery.Data == "house1_5")
                    {
                        pizzaHouse = "пятое здание";
                        Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                                        chatId: e.CallbackQuery.Message.Chat.Id,
                                        caption: $"Выберите товар:",
                                        replyMarkup: new InlineKeyboardMarkup(new[]
                                        {
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar1_info}", "tovar_nav1") },
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar2_info}", "tovar_nav2") },
                                            new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "city1_nav") }
                                        }));
                        // Удаление старого сообщения
                        Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
                    }

                    else if (e.CallbackQuery.Data == "house1_6")
                    {
                        pizzaHouse = "шестое здание";
                        Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                                        chatId: e.CallbackQuery.Message.Chat.Id,
                                        caption: $"Выберите товар:",
                                        replyMarkup: new InlineKeyboardMarkup(new[]
                                        {
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar1_info}", "tovar_nav1") },
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar2_info}", "tovar_nav2") },
                                            new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "city1_nav") }
                                        }));
                        // Удаление старого сообщения
                        Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
                    }

                    else if (e.CallbackQuery.Data == "house1_7")
                    {
                        pizzaHouse = "седьмое здание";
                        // Нижний Новгород Советский
                        Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                                        chatId: e.CallbackQuery.Message.Chat.Id,
                                        caption: $"Выберите товар:",
                                        replyMarkup: new InlineKeyboardMarkup(new[]
                                        {
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar1_info}", "tovar_nav1") },
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar2_info}", "tovar_nav2") },
                                            new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "city1_nav") }
                                        }));
                        // Удаление старого сообщения
                        Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
                    }

                    else if (e.CallbackQuery.Data == "house1_8")
                    {
                        pizzaHouse = "восьмое здание";
                        // Нижний Новгород Сормовский
                        Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                                        chatId: e.CallbackQuery.Message.Chat.Id,
                                        caption: $"Выберите товар:",
                                        replyMarkup: new InlineKeyboardMarkup(new[]
                                        {
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar1_info}", "tovar_nav1") },
                                            new[] { InlineKeyboardButton.WithCallbackData($"{tovar2_info}", "tovar_nav2") },
                                            new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "city1_nav") }
                                        }));
                        // Удаление старого сообщения
                        Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
                    }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        else if (e.CallbackQuery.Data == "city2_nav")
        {
            city = "город 2";
            pizzaHouse = "Единственная пиццерия";
            Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                            chatId: e.CallbackQuery.Message.Chat.Id,
                            caption: $"Выберите товар: ",
                            replyMarkup: new InlineKeyboardMarkup(new[]
                            {
                                new[] { InlineKeyboardButton.WithCallbackData($"{tovar1_info}", "tovar_nav1") },
                                new[] { InlineKeyboardButton.WithCallbackData($"{tovar2_info}", "tovar_nav2") },
                                new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "02") }
                            }));
            // Удаление старого сообщения
            Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        else if (e.CallbackQuery.Data == "tovar_nav1")
        {
            tovar = "Товар 1"; price = price + 10;
            Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                            chatId: e.CallbackQuery.Message.Chat.Id,
                            caption: $"Выберите способ доставки товара 1 (цена +10)",
                            replyMarkup: new InlineKeyboardMarkup(new[]
                            {
                                new[] { InlineKeyboardButton.WithCallbackData("на вынос", "outside") },
                                new[] { InlineKeyboardButton.WithCallbackData("внутри", "inside") },
                                new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "02") }
                            }));
            // Удаление старого сообщения
            Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
        }

        else if (e.CallbackQuery.Data == "tovar_nav2")
        {
            tovar = "Товар 2";
            Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                            chatId: e.CallbackQuery.Message.Chat.Id,
                            caption: $"Выберите способ доставки товара 2",
                            replyMarkup: new InlineKeyboardMarkup(new[]
                            {
                                new[] { InlineKeyboardButton.WithCallbackData("на вынос", "outside") },
                                new[] { InlineKeyboardButton.WithCallbackData("внутри", "inside") },
                                new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "02") }
                            }));
            // Удаление старого сообщения
            Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
        }

        else if (e.CallbackQuery.Data == "outside" || e.CallbackQuery.Data == "inside")
        {
            if (e.CallbackQuery.Data == "outside") { feature = "снаружи"; }
            else if (e.CallbackQuery.Data == "inside") { feature = "внутри"; }
            
            // Статистика
            Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                            chatId: e.CallbackQuery.Message.Chat.Id,
                            caption: $"проверьте все ли верно прежде чем отправлять заказ.\r\n Город: {city} \r\n пиццерия: {pizzaHouse} \r\n Товар: {tovar} \r\n способ доставки: {feature}" +
                            $"\r\n Цена {price}",
                            replyMarkup: new InlineKeyboardMarkup(new[]
                            {
                                new[] { InlineKeyboardButton.WithCallbackData("все верно", "succesful") },
                                new[] { InlineKeyboardButton.WithCallbackData("Вернуться назад", "02") }
                            }));
            // Удаление старого сообщения
            Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
        }

        else if (e.CallbackQuery.Data == "succesful")
        {
            pr = 1; 
            Bot.SendPhotoAsync(photo: new InputOnlineFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3eBHbH23maXkelx-1jshOyMb_cdV-JLFviHK0shZ7&s"),
                            chatId: e.CallbackQuery.Message.Chat.Id,
                            caption: $"Поздравляю! заказ отправлен.",
                            replyMarkup: new InlineKeyboardMarkup(new[]
                            {
                                new[] { InlineKeyboardButton.WithCallbackData("Вернуться к покупкам", "02") }
                            }));
            // Удаление старого сообщения
            Bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.CallbackQuery.Message.MessageId);
        }



        if (pr == 1)
        {
           
           // отправка заказа повару
           Bot.SendTextMessageAsync(chatId: $"{ownerId}" , 
           text: $"Пользовать выбрал \r\n Город: {city} \r\n пиццерия: {pizzaHouse} \r\n Товар: {tovar} \r\n способ доставки: {feature}" +
           $"\r\n Цена {price}");
        }

    }



}
