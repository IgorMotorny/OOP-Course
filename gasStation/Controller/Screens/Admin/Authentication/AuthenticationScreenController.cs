using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    class AuthenticationScreenController : ScreenController {
        private FileManager _fileManager = new FileManager();
        private ScreenManager _screenManger = new ScreenManager();

        private GasStationView _view;
        private const string PASSWORD_FILE_NAME = "Password.dat";
        private string _validPassword;

        public AuthenticationScreenController() {
            _view = new GasStationView();
        }

        public void InitScreen() {
            Authenticate();
        }
        private void Authenticate() {
            _validPassword = _fileManager.ReadBin<string>(PASSWORD_FILE_NAME);

           
            if (_validPassword != null) {
                bool isPasswordCorrect;

                do {
                    Console.Clear();
                    isPasswordCorrect = GetPassword();

                    if (!isPasswordCorrect) {
                        Console.Clear();
                        _view.print("Password is wrong!");
                        _screenManger.CheckExit("Main");
                    }
                } while (!isPasswordCorrect);

                _screenManger.GoToScreen("Admin menu");
            } else {
                SetPassword();
                _screenManger.GoToScreen("Admin menu");
            }
        } 
        private void SetPassword() {
            string newPassword,
                passwordConfirm;

            do {
                Console.Clear();

                _view.print("Set password: ");
                newPassword = ReadPassword();

                _view.print("\nConfirm password: ");
                passwordConfirm = ReadPassword();

            } while (newPassword != passwordConfirm);

            _fileManager.WriteBin<string>(newPassword, PASSWORD_FILE_NAME);
            _validPassword = newPassword;
        }
        private bool GetPassword() {
            string password;
            
            _view.print("Password: ");
            password = ReadPassword();
            return (password == _validPassword);
        }
        private string ReadPassword() {
            StringBuilder result = new StringBuilder();
            ConsoleKeyInfo key;
            bool isEnter;
            do {
                key = Console.ReadKey();
                isEnter = (key.Key == ConsoleKey.Enter);

                if (key.Key == ConsoleKey.Backspace) {
                    Console.CursorLeft = Console.CursorLeft + 1;
                    continue;
                }

                if (!isEnter) {
                    result.Append(key.KeyChar);
                    Console.CursorLeft = Console.CursorLeft - 1;
                    Console.Write("*");
                }

            } while (!isEnter);
            return result.ToString();
        }
    }
}
