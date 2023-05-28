# TicTacToeWebApp

Приложение для онлайн игры в Крестики-Нолики!

Реализовано при помощи Blazor Server, в качестве хранилища данных используется Sqlite. 
Реализована аутентификация и авторизаяция пользователей при помощи Identity.
Для каждого пользователя хранится история игр, включая ходы.
Чтобы протестировать приложение: 
1. Можно раскомментировать строку, указав свой ip-адрес
//builder.WebHost.UseUrls("http://192.168.0.104:9876", "http://localhost:9876");
А также закомментировать эту строку:
app.UseHttpsRedirection();

2. Использовать один компьютер, на котором открыть url на разных браузерах.

Буду рад вашим отзывам!

[изображение](https://github.com/Ivasnet/TicTacToeWebApp/assets/70843270/85878d49-073f-41ea-892a-b8a7fc3efabd)