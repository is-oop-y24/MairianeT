using Banks.Entities;
using Banks.Services;

namespace Banks.Console
{
    public class Controller
    {
        private View _view = new View();
        private ICentralBank _centralBank = new CentralBank();
        public void Start()
        {
            _view.WriteLine("Что Вы хотите сделать? \n 1. Создать банк \n 2. Создать клиента \n 3. Создать счет \n 4. Совершить транзакцию \n 5. Отменить транзакцию \n 6. Подписаться на уведомления от банка \n 7. Изменить проценты/лимит  \n");
            string answer = _view.ReadLine();
            switch (answer)
            {
                case "1":
                    _view.WriteLine("Введите название банка:");
                    string bankName = _view.ReadLine();
                    BankBuilder builder = new BankBuilder().SetName(bankName);
                    _view.WriteLine("Введите процент:");
                    double bankPercent = _view.ReadDouble();
                    builder.SetPercent(bankPercent);
                    _view.WriteLine("Что еще необходимо указать?");
                    break;
            }
        }
    }
}