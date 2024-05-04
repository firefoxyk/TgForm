using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgForm.BotConstants
{
    public class QuestionnaireTexts
    {
        public const string welcome = "Привет, Мама! Мы рады приветствовать тебя в нашем приложении, где ты можешь познакомиться с другими мамами для веселых встреч и прогулок с детьми. Здесь ты найдешь поддержку, новых друзей и вдохновение для приятного времяпрепровождения с малышами. Давай создадим яркие воспоминания вместе! 😊👩‍👧‍👦🌳";
        public const string reactionToAnUnknownPhrase = "Извините, я не смог понять вашу фразу. Можете переформулировать или задать вопрос по-другому? Я готов помочь вам! 😊🤖";
        public const string endingTheDialogue = "Было приятно пообщаться с вами! Если у вас возникнут еще какие-либо вопросы или потребуется помощь, не стесняйтесь обращаться. Желаю вам прекрасного дня! До свидания! 👋🌟\r\n";
        public const string startOfRegistration = "Привет, мама! Чтобы найти подходящих для тебя и твоего ребенка компании, давай начнем с заполнения небольшой анкеты. Поделись немного о себе и о том, что тебе нравится делать в свободное время вместе с детьми. Это поможет нам подобрать тебе идеальных партнерок для встреч и прогулок. Давай создадим уютное сообщество для ярких маминых эмоций! 🤗🌼\r\n";
        public const string userName = "Пожалуйста, введите ваше имя, чтобы мы могли обращаться к вам по имени и помогать вам создавать замечательные воспоминания вместе! 🌸\r\n";
        public const string momsAge = "Пожалуйста, укажите ваш возраст.\r\n";
        public const string childsAge = "Пожалуйста, укажите вашего ребенка. Если ребенку меньше года, то укажите 0.\r\n";
        public const string postcode = "Укажите, пожалуйста, свой почтовый индекс, чтобы мы могли помочь вам найти мам-соседей для встреч и прогулок в вашем районе. \r\n";
        public const string mail = "Для получения уведомлений пожалуйста, укажите ваш email. \r\n";
        public const string description = "Расскажите о себе: какие у вас интересы, хобби, что вам нравится делать в свободное время с детьми? Чем вы увлекаетесь и что бы вы хотели делиться с другими мамами? ";
        public const string dataValidation = "Проверьте правильность данных. Если все верно, нажмите «Продолжить», или выберите какое поле необходимо исправить\r\n";
        public static string UserDataValidation(string usernameAnswer, string momsAge, string childsAge, string postcode, string mail, string description)
        {
            return $"Имя: {usernameAnswer}\r\nВозраст мамы: {momsAge}\r\nВозраст ребенка: {childsAge}\r\nПочтовый индекс: {postcode}\r\nПочта: {mail}\r\nОписание: {description}";
        }


        public const string confirmation = "Я загрузила информацию в нашу базу данных! После верификации она будет доступна другим мамам 🌸\r\n";

    }
}
