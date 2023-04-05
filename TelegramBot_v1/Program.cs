using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Newtonsoft.Json;
using Telegram.Bot.Extensions.Polling;
using System.Net;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot_v1
{
    class Program
    {
      

        static readonly string token = "5638295263:AAF9NqXBUbXujx-v6mukW2_clXSK8iRchnE";
        static ITelegramBotClient Bot = new TelegramBotClient(token);
        public static string SendMessage(string message, long chatID)
        {
            string retval = string.Empty;
            string url = $"https://api.telegram.org/bot{token}/sendMessage?chat_id={chatID}&text={message}";

            using (var webClient = new WebClient())
            {
                retval = webClient.DownloadString(url);
            }

            return retval;
        }

        public static async Task HandleUpdateTelegram(ITelegramBotClient botClient , Update update , CancellationToken  cancellationToken) {
            
           // Console.WriteLine(JsonConvert.SerializeObject(update));

            if (update.Type ==UpdateType.Message)
            {
                var message = update.Message;

                Console.WriteLine($"firtname {message.From.FirstName} \n username = {message.From.Username} \n id = {message.From.Id}\n\tinput text = {message.Text}");

                    if (message.Text.ToLower().Contains("/start"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Салом Салом !");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "ба сомонаи мо ворид шуда \nдоруҳоятонро зудтар ёбед ");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Меню: \n/start \n/ok");



                    #region Multi-row keyboard markup
                    ReplyKeyboardMarkup addMultibutton = new ReplyKeyboardMarkup(
                            new[] {
                              new KeyboardButton[]{ "One", "Two"},
                              new KeyboardButton[]{ "Three", "Four" },
                              new KeyboardButton[]{ "Three", "Four" },
                            }

                        )
                    {
                        ResizeKeyboard = true
                    };
                    #endregion

                    #region Request information
                    /*   ReplyKeyboardMarkup addMultibuttonRequest = new ReplyKeyboardMarkup(
                                new[] {
                                       KeyboardButton.WithRequestLocation("Share Location"),
                                       KeyboardButton.WithRequestContact("Share Contact")  
                                }

                            )
                       {
                           ResizeKeyboard = true
                       };*/
                    #endregion


                    InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(
                      new[]
                      {    
                               new[]
                               {
                                  InlineKeyboardButton.WithSwitchInlineQuery("switch_inline_query"),
                                  InlineKeyboardButton.WithSwitchInlineQueryCurrentChat("switch_inline_query_current_chat"),
                               },
                              new[]
                               {
                                  InlineKeyboardButton.WithCallbackData(text:"11", callbackData:"12"),
                                  InlineKeyboardButton.WithCallbackData(text:"11",callbackData:"123"),
                               },
                               
                               new[]
                               {
                                  InlineKeyboardButton.WithSwitchInlineQueryCurrentChat("switch_inline_query_current_chat"),
                               },
                               new[]
                               {
                                  InlineKeyboardButton.WithSwitchInlineQuery("text"),
                               }
                      }

                  );
                  

                        await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id, 
                        text:" hello doly ", 
                        parseMode: ParseMode.MarkdownV2,
                        replyToMessageId: update.Message.MessageId,
                        replyMarkup: inlineKeyboard,
                       
                        cancellationToken: cancellationToken

                        /*new InlineKeyboardMarkup(
                                inlineKeyboardButton: InlineKeyboardButton.WithUrl(text: "text send me for comment ", url: "https://t.me/i_am_tajik/"))*/
                        );
                  
                   



                    #region Cend arrayPhoto
                    Message[] messages = await botClient.SendMediaGroupAsync(
                       chatId: message.Chat.Id,
                       media: new IAlbumInputMedia[]
                       {
                                    new InputMediaPhoto("https://cdn.pixabay.com/photo/2017/06/20/19/22/fuchs-2424369_640.jpg"),
                                    new InputMediaPhoto("https://cdn.pixabay.com/photo/2017/04/11/21/34/giraffe-2222908_640.jpg"),
                                    new InputMediaPhoto("https://cdn.pixabay.com/photo/2022/01/23/16/21/peacock-flowers-6961319_960_720.jpg"),
                       },
                       cancellationToken: cancellationToken);
                    #endregion
                    #region Send  Document
                  /*  await botClient.SendDocumentAsync(
                            chatId: message.Chat.Id,
                            document: "https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg",
                            caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
                            parseMode: ParseMode.Html,
                            cancellationToken: cancellationToken);*/
                    #endregion
                    #region Send animations
                    /*await botClient.SendAnimationAsync(
    chatId: message.Chat.Id,
    animation: "https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-waves.mp4",
    caption: "Waves",
    cancellationToken: cancellationToken);*/
                    #endregion
                    #region Native Poll Messages
                   /* await botClient.SendPollAsync(
                             chatId: message.Chat.Id,
                               question: "Хизматрасонии моро баҳогузори кунед ?",
                               options: new[]
                               {
                                   "бад",
                                   "хуб",
                                   "оли",
                               },
                               cancellationToken: cancellationToken
                        );
*/
                    #endregion
                    #region Stop a poll
                   /* await botClient.StopPollAsync(
    chatId: message.Chat.Id,
    messageId: message.MessageId,
    cancellationToken: cancellationToken);*/
                    #endregion
                    #region Send Contact 
                 /*   await botClient.SendContactAsync(
    chatId: message.Chat.Id,
    phoneNumber: "+1234567890",
    firstName: "Han",
    vCard: "BEGIN:VCARD\n" +
           "VERSION:3.0\n" +
           "N:Solo;Han\n" +
           "ORG:Scruffy-looking nerf herder\n" +
           "TEL;TYPE=voice,work,pref:+1234567890\n" +
           "EMAIL:hansolo@mfalcon.com\n" +
           "END:VCARD",
    cancellationToken: cancellationToken);*/
                    #endregion
                    #region Send Venue MAP
                  /*  await botClient.SendVenueAsync(
    chatId: message.Chat.Id,
    latitude: 50.0840172f,
    longitude: 14.418288f,
    title: "Man Hanging out",
    address: "Husova, 110 00 Staré Město, Czechia"
    );*/
                    #endregion
                    #region Send Region 
                   /* await botClient.SendLocationAsync(
                        chatId: message.Chat.Id,
                        heading: 1,
                         latitude: 33.747252f,
                        longitude: -112.633853f,
                         cancellationToken: cancellationToken
                        );*/
                    #endregion


                    return;
                    }
                    if (message.Text.ToLower().Contains("/helpme"))
                    {
                        await botClient.SendStickerAsync(message.Chat.Id,sticker: "https://tlgrm.eu/_/stickers/ccd/a8d/ccda8d5d-d492-4393-8bb7-e33f77c24907/1.webp");
                        return;
                    }
                if (update.Type==UpdateType.CallbackQuery)
                {
                    CallbackQuery callbackQuery = update.CallbackQuery;
                    await botClient.AnswerCallbackQueryAsync(callbackQuery.Id, "ok");
                }
                await botClient.SendTextMessageAsync(message.Chat.Id, "Муштарии муҳтарам айни ҳол бот кор намекунад\n метавонед ба мо муроҷиат кунед:\n TEL: 900711522");
            }
        }

        public static   async Task HandleErrorTelegram(ITelegramBotClient  botClient , Exception ex , CancellationToken cancellationToken)
        {
            Console.WriteLine(JsonConvert.SerializeObject(ex));
            var message = ex.Message;
            await botClient.SendTextMessageAsync(message, "Муштарии муҳтарам айни ҳол бот кор намекунад\n метавонед ба мо муроҷиат кунед:\n TEL: 900711522");
        }


       
        static void Main(string[] args)
        {
            Console.WriteLine("OPent bot "+Bot.GetMeAsync().Result.Id);



            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiveOpiton = new ReceiverOptions
            {
                AllowedUpdates = { }
            };
            

            Bot.StartReceiving(
                HandleUpdateTelegram,
                HandleErrorTelegram,
                receiveOpiton,
                cancellationToken
                );


            Console.ReadKey();
        }
    }
}
