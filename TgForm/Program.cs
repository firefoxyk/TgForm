using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TgForm.BotConstants;
using TgForm.Models;
using Update = Telegram.Bot.Types.Update;


namespace TgBotWeather
{
    class Program
    {
        static readonly ITelegramBotClient bot = new TelegramBotClient("7132182629:AAFXrOuxh0As0rj0QfcsepiIVWLDYQjv0QI");
        static string usernameAnswer = "";
        static string momsAge = "";
        static string childsAge = "";
        static string postcode = "";
        static string mail = "";
        static string description = "";

        private static int questionNumber = 1;
        private static int questionUpdateNumber = 0;
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            InlineKeyboard keyboard = new();

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.welcome, replyMarkup: keyboard.inlineKeyboard, cancellationToken: cancellationToken);
                    return;
                }
                if (message.Text != null)
                {
                    switch (questionNumber)
                    {
                        case 1:
                            if (Regex.IsMatch(message.Text, @"^[а-яА-Я]+$"))
                            {
                                usernameAnswer = message.Text;
                                questionNumber++;
                                await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.momsAge, cancellationToken: cancellationToken);
                                break;
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat, "Ответ должен содержать только символы русского алфавита", cancellationToken: cancellationToken);
                                break;
                            }
                        case 2:
                            if (Regex.IsMatch(message.Text, @"^\d{2}$") && int.Parse(message.Text) >= 18)
                            {
                                momsAge = message.Text;
                                questionNumber++;
                                await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.childsAge, cancellationToken: cancellationToken);
                                break;
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat, "Ответ должен быть числом из двух цифр больше 18", cancellationToken: cancellationToken);
                                break;
                            }
                        case 3:
                            if (Regex.IsMatch(message.Text, @"^([0-9]|1[0-8]?)$") && int.Parse(message.Text) >= 0)
                            {
                                childsAge = message.Text;
                                questionNumber++;
                                await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.postcode, cancellationToken: cancellationToken);
                                break;
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat, "Ответ должен быть числом из больше 0", cancellationToken: cancellationToken);
                                break;
                            }
                        case 4:
                            if (Regex.IsMatch(message.Text, @"^\d{6}$"))
                            {
                                postcode = message.Text;
                                questionNumber++;
                                await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.mail, cancellationToken: cancellationToken);
                                break;
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat, "Ответ должен быть числом из 6 цифр", cancellationToken: cancellationToken);
                                break;
                            }
                        case 5:
                            if (Regex.IsMatch(message.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                            {
                                mail = message.Text;
                                questionNumber++;
                                await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.description, cancellationToken: cancellationToken);
                                break;
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat, "Ответ должен email-адресом", cancellationToken: cancellationToken);
                                break;
                            }
                        case 6:
                            description = message.Text;
                            questionNumber++;
                            await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.dataValidation, cancellationToken: cancellationToken);
                            await botClient.SendTextMessageAsync(message.Chat,
                                QuestionnaireTexts.UserDataValidation(usernameAnswer, momsAge, childsAge, postcode, mail, description),
                                replyMarkup: keyboard.inlineKeyboardWithButtons, cancellationToken: cancellationToken);
                            break;
                    }
                    switch (questionUpdateNumber)
                    {
                        case 1:
                            if (Regex.IsMatch(message.Text, @"^[а-яА-Я]+$"))
                            {
                                usernameAnswer = message.Text;
                                await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.dataValidation, cancellationToken: cancellationToken);
                                await botClient.SendTextMessageAsync(message.Chat,
                                    QuestionnaireTexts.UserDataValidation(usernameAnswer, momsAge, childsAge, postcode, mail, description),
                                    replyMarkup: keyboard.inlineKeyboardWithButtons, cancellationToken: cancellationToken);
                                break;
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat, "Ответ должен содержать только символы русского алфавита", cancellationToken: cancellationToken);
                                break;
                            }
                        case 2:
                            if (Regex.IsMatch(message.Text, @"^\d{2}$") && int.Parse(message.Text) >= 18)
                            {
                                momsAge = message.Text;
                                await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.dataValidation, cancellationToken: cancellationToken);
                                await botClient.SendTextMessageAsync(message.Chat,
                                    QuestionnaireTexts.UserDataValidation(usernameAnswer, momsAge, childsAge, postcode, mail, description),
                                    replyMarkup: keyboard.inlineKeyboardWithButtons, cancellationToken: cancellationToken);
                                break;
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat, "Ответ должен быть числом из двух цифр больше 18", cancellationToken: cancellationToken);
                                break;
                            }
                        case 3:
                            if (Regex.IsMatch(message.Text, @"^([0-9]|1[0-8]?)$") && int.Parse(message.Text) >= 0)
                            {
                                childsAge = message.Text;
                                await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.dataValidation, cancellationToken: cancellationToken);
                                await botClient.SendTextMessageAsync(message.Chat,
                                    QuestionnaireTexts.UserDataValidation(usernameAnswer, momsAge, childsAge, postcode, mail, description),
                                    replyMarkup: keyboard.inlineKeyboardWithButtons, cancellationToken: cancellationToken);
                                break;
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat, "Ответ должен быть числом из больше 0", cancellationToken: cancellationToken);
                                break;
                            }
                        case 4:
                            if (Regex.IsMatch(message.Text, @"^\d{6}$"))
                            {
                                postcode = message.Text;
                                await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.dataValidation, cancellationToken: cancellationToken);
                                await botClient.SendTextMessageAsync(message.Chat,
                                    QuestionnaireTexts.UserDataValidation(usernameAnswer, momsAge, childsAge, postcode, mail, description),
                                    replyMarkup: keyboard.inlineKeyboardWithButtons, cancellationToken: cancellationToken);
                                break;
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat, "Ответ должен быть числом из 6 цифр", cancellationToken: cancellationToken);
                                break;
                            }
                        case 5:
                            if (Regex.IsMatch(message.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                            {
                                mail = message.Text;
                                await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.dataValidation, cancellationToken: cancellationToken);
                                await botClient.SendTextMessageAsync(message.Chat,
                                    QuestionnaireTexts.UserDataValidation(usernameAnswer, momsAge, childsAge, postcode, mail, description),
                                    replyMarkup: keyboard.inlineKeyboardWithButtons, cancellationToken: cancellationToken);
                                break;
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat, "Ответ должен email-адресом", cancellationToken: cancellationToken);
                                break;
                            }
                        case 6:
                            description = message.Text;
                            await botClient.SendTextMessageAsync(message.Chat, QuestionnaireTexts.dataValidation, cancellationToken: cancellationToken);
                            await botClient.SendTextMessageAsync(message.Chat,
                                QuestionnaireTexts.UserDataValidation(usernameAnswer, momsAge, childsAge, postcode, mail, description),
                                replyMarkup: keyboard.inlineKeyboardWithButtons, cancellationToken: cancellationToken);
                            break;
                    }
                }
            }
            else if (update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                var callbackQuery = update.CallbackQuery;
                switch (callbackQuery.Data)
                {
                    case "fillOutTheTormButton":
                        await botClient.SendTextMessageAsync(callbackQuery.Message.Chat, QuestionnaireTexts.startOfRegistration);
                        await botClient.SendTextMessageAsync(callbackQuery.Message.Chat, QuestionnaireTexts.userName);
                        break;
                    case "changeNameButton":
                        await botClient.SendTextMessageAsync(callbackQuery.Message.Chat, QuestionnaireTexts.userName);
                        questionUpdateNumber = 1;
                        break;
                    case "changeMotherAgeButton":
                        await botClient.SendTextMessageAsync(callbackQuery.Message.Chat, QuestionnaireTexts.userName);
                        questionUpdateNumber = 2;
                        break;
                    case "changeChildAgeButton":
                        await botClient.SendTextMessageAsync(callbackQuery.Message.Chat, QuestionnaireTexts.userName);
                        questionUpdateNumber = 3;
                        break;
                    case "changePostcodeButton":
                        await botClient.SendTextMessageAsync(callbackQuery.Message.Chat, QuestionnaireTexts.userName);
                        questionUpdateNumber = 4;
                        break;
                    case "changeEmailButton":
                        await botClient.SendTextMessageAsync(callbackQuery.Message.Chat, QuestionnaireTexts.userName);
                        questionUpdateNumber = 5;
                        break;
                    case "changeDescriptionButton":
                        await botClient.SendTextMessageAsync(callbackQuery.Message.Chat, QuestionnaireTexts.userName);
                        questionUpdateNumber = 6;
                        break;
                    case "continueButton":
                        var questionnaireData = new UserAnswers
                        {
                            MomName = usernameAnswer,
                            MamAge = momsAge,
                            ChildrenAge = childsAge,
                            Postcode = postcode,
                            Mail = mail,
                            Description = description
                        };
                        string json = Newtonsoft.Json.JsonConvert.SerializeObject(questionnaireData);
                        Console.WriteLine("Сериализованный объект JSON:");
                        Console.WriteLine(json);
                        await botClient.SendTextMessageAsync(callbackQuery.Message.Chat, QuestionnaireTexts.userName);
                        break;
                }
            }
        }
        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { },
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}
