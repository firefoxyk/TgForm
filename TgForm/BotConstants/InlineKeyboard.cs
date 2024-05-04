using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TgForm.BotConstants
{
    public class InlineKeyboard
    {
        public InlineKeyboardMarkup inlineKeyboardWithButtons = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Продолжить", "continueButton")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Имя", "changeNameButton"),
                InlineKeyboardButton.WithCallbackData("Возраст мамы", "changeMotherAgeButton"),
                InlineKeyboardButton.WithCallbackData("Возраст ребенка", "changeChildAgeButton"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Почтовый индекс", "changePostcodeButton"),
                InlineKeyboardButton.WithCallbackData("Почта", "changeEmailButton"),
                InlineKeyboardButton.WithCallbackData("Описание", "changeDescriptionButton"),
            }
        });

        public InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Заполнить анкету", "fillOutTheTormButton"),
            }
        });
    }
}
